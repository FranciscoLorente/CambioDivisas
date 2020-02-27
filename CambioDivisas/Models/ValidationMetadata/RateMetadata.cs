using System.ComponentModel.DataAnnotations;

namespace CambioDivisas.Models
{
    public class RateMetadata
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public decimal Rate { get; set; }
    }

    [MetadataType(typeof(RateMetadata))]
    public partial class Rates { }
}