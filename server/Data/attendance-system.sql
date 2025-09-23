DROP DATABASE IF EXISTS AttendanceDb;
CREATE DATABASE AttendanceDb;

USE AttendanceDb;

CREATE TABLE Users(
    Id VARCHAR(36) PRIMARY KEY DEFAULT (UUID()),
    UserCode INT NOT NULL UNIQUE,
    Name VARCHAR(100) NOT NULL,
    Role VARCHAR(5) NOT NULL CHECK (Role IN ('admin','user')),
    Status VARCHAR(7) NOT NULL DEFAULT 'absent' CHECK (Status IN ('present','absent')),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Schedules (
    Id VARCHAR(36) PRIMARY KEY DEFAULT (UUID()),
    Name VARCHAR(100) NOT NULL,
    UserCode INT NOT NULL UNIQUE,
    Mon_Shift1 VARCHAR(20), Mon_Shift2 VARCHAR(20), Mon_Shift3 VARCHAR(20), Mon_Break VARCHAR(20),
    Tue_Shift1 VARCHAR(20), Tue_Shift2 VARCHAR(20), Tue_Shift3 VARCHAR(20), Tue_Break VARCHAR(20),
    Wed_Shift1 VARCHAR(20), Wed_Shift2 VARCHAR(20), Wed_Shift3 VARCHAR(20), Wed_Break VARCHAR(20),
    Thu_Shift1 VARCHAR(20), Thu_Shift2 VARCHAR(20), Thu_Shift3 VARCHAR(20), Thu_Break VARCHAR(20),
    Fri_Shift1 VARCHAR(20), Fri_Shift2 VARCHAR(20), Fri_Shift3 VARCHAR(20), Fri_Break VARCHAR(20),
    Sat_Shift1 VARCHAR(20), Sat_Shift2 VARCHAR(20), Sat_Shift3 VARCHAR(20), Sat_Break VARCHAR(20),
    Sun_Shift1 VARCHAR(20), Sun_Shift2 VARCHAR(20), Sun_Shift3 VARCHAR(20), Sun_Break VARCHAR(20)
);

CREATE TABLE Logs (
    Id VARCHAR(36) PRIMARY KEY DEFAULT (UUID()),
    UserId VARCHAR(36) NOT NULL,
    Status VARCHAR(7) NOT NULL CHECK (Status IN ('present','absent')),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

DELIMITER $$

CREATE TRIGGER AddLog
AFTER UPDATE ON Users
FOR EACH ROW
BEGIN
    IF NEW.Role <> 'admin' AND NEW.Status <> OLD.Status THEN
        INSERT INTO Logs (UserId, Status)
        VALUES (OLD.Id, NEW.Status);
    END IF;
END$$

DELIMITER ;

DELIMITER $$


CREATE TRIGGER InsertUser
AFTER INSERT ON Schedules
FOR EACH ROW
BEGIN
    INSERT INTO Users (UserCode, Name, Role)
    VALUES (NEW.UserCode, NEW.Name, 'user');
END$$

DELIMITER ;

DELIMITER $$

CREATE TRIGGER DeleteSchedule
AFTER DELETE ON Users
FOR EACH ROW
BEGIN
    DELETE FROM Schedules 
    WHERE UserCode = OLD.UserCode;
END$$

DELIMITER ;

DELIMITER $$

CREATE EVENT ResetStatus
ON SCHEDULE EVERY 1 DAY
STARTS CONCAT(CURDATE() + INTERVAL 1 DAY, ' 00:00:00')
DO
BEGIN
    UPDATE Users
    SET status = 'absent'
    WHERE status = 'present';
END$$

DELIMITER ;

CREATE TRIGGER UpdateLog
AFTER UPDATE ON Users
FOR EACH ROW
BEGIN
    IF OLD.Status = 'present' THEN
        DELETE FROM Logs
        WHERE DATE(Logs.CreatedAt) = CURDATE() AND
        Id = (
            SELECT Id FROM (
                SELECT Id
                FROM Logs
                WHERE UserId = OLD.Id
                ORDER BY CreatedAt DESC
                LIMIT 1 
            ) AS t
        );
    END IF;
END $$

DELIMITER ;


