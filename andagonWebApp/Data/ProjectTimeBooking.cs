namespace andagonWebApp.Data
{
    public class ProjectTimeBooking
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long TaskId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public long Minutes { get; set; }
        public string? Description { get; set; }
        public bool SaveAsWorkTime { get; set; }
        public double amount
        {
            get { return (double)Minutes / 60.0; }
            set { Minutes = (long)(value * 60); }
        }
        public string Hours
        {
            get
            {
                var hours = Minutes / 60;
                var minutes = Minutes % 60;
                return $"{hours:D2}:{minutes:D2}";
            }
            set
            {
                var parts = value.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[0], out var hours) && int.TryParse(parts[1], out var minutes))
                {
                    Minutes = hours * 60 + minutes;
                }
                else
                {
                    throw new FormatException("Invalid time format. Expected format is HH:mm.");
                }
            }
        }
    }
}
