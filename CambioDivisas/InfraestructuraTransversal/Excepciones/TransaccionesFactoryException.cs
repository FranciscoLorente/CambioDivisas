using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CambioDivisas.InfraestructuraTransversal.Excepciones
{
    public class TransaccionesFactoryException: Exception
    {
        public TransaccionesFactoryException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}