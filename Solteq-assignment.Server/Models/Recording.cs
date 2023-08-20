namespace Solteq_assignment.Server.Models
{
    public class Recording
    {
        public DateTime timestamp { get; set; }
        public string reportingGroup { get; set; }
        public string locationName { get; set; }
        public double value { get; set; }
        public string unit { get; set; }
    }
}
