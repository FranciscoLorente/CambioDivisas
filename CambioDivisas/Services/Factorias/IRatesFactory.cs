using CambioDivisas.Models;
using System.Collections.Generic;

namespace CambioDivisas.Services.Factorias
{
    public interface IRatesFactory
    {
        List<Rates> CrearListaRates(List<Rates> lista);
    }
}
