using System.ComponentModel.DataAnnotations;

namespace CambioDivisas.Models.ViewModel
{
    public class ListadoSkuVM
    {
        [Key]
        public string Sku { get; set; }
        public decimal SumaTotal { get; set; }
        public string Moneda { get; set; }
    }
}