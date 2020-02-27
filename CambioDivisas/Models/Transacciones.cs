using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CambioDivisas.Models
{
    public partial class Transacciones
    {
        public int ID { get; set; }
        public string Sku { get; set; }
        public decimal Amount {get; set;}
        public string Currency { get; set; }
    }
}