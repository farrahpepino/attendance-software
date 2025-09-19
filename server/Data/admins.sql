USE AttendanceDb;

DELIMITER $$

CREATE PROCEDURE InsertAdmin(
    IN p_UserCode INT,
    IN p_Name VARCHAR(100),
    IN p_Role VARCHAR(50)
)
BEGIN 
    INSERT INTO Users (UserCode, Name, Role)
    VALUES (p_UserCode, p_Name, p_Role);
END $$

DELIMITER ;

