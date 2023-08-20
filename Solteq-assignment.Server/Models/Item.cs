namespace Solteq_assignment.Server.Models
{
    public class Item
    {
        public int month { get; set; }
        public string location { get; set; }
        public double value { get; set; }
        public string unit { get; set; } = "kWh";
    }
}
