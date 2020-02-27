using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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