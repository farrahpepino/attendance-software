namespace server.Models{
    public class Schedule{
        public string Id {get; set;}
        public string UserId {get; set;}
        public string Day {get; set;}
        public string Shift1 {get; set;}
        public string Shift2 {get; set;}
        public string Shift3 {get; set;}
        public string Break {get; set;}
        public DateTime CreatedAt {get; set;}
    }
}
