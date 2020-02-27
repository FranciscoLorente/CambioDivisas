using System;

namespace CambioDivisas.InfraestructuraTransversal.Excepciones
{
    public class RatesFactoryException: Exception
    {
        public RatesFactoryException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}