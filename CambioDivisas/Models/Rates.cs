namespace CambioDivisas.Models
{
    public partial class Rates
    {
        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Rate { get; set; }
    }
}