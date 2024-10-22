namespace SecurityOffice.Dtos
{
    public class EmployeeAttendanceDto
    {
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int EmployeeId { get; set; }
    }
}
