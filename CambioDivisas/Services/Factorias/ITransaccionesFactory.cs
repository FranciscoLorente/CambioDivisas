using CambioDivisas.Models;
using System.Collections.Generic;

namespace CambioDivisas.Services.Factorias
{
    public interface ITransaccionesFactory
    {
        List<Transacciones> CrearListaTransacciones(List<Transacciones> lista);
    }
}
