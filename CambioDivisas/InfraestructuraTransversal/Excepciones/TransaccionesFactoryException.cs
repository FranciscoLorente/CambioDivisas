using System;

namespace CambioDivisas.InfraestructuraTransversal.Excepciones
{
    public class TransaccionesFactoryException: Exception
    {
        public TransaccionesFactoryException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}