namespace SecurityOffice.Models
{
    public class EmployeeAttendance
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int EmployeeId { get; set; }  
        public Employee? Employee { get; set; }

       
    }
}
