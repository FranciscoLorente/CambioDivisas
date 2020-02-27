using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CambioDivisas.InfraestructuraTransversal.Excepciones
{
    public class JsonConverterException: Exception
    {
        public JsonConverterException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}