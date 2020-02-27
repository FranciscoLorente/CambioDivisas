using System;

namespace CambioDivisas.InfraestructuraTransversal.Excepciones
{
    public class JsonConverterException: Exception
    {
        public JsonConverterException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}