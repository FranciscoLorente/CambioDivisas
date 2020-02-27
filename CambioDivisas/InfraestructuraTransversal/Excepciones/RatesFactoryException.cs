using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CambioDivisas.InfraestructuraTransversal.Excepciones
{
    public class RatesFactoryException: Exception
    {
        public RatesFactoryException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}