using System.ComponentModel.DataAnnotations;

namespace CambioDivisas.Models
{
    public class TransaccionMetadata
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Sku { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; }
    }

    [MetadataType(typeof(TransaccionMetadata))]
    public partial class Transacciones { }
}