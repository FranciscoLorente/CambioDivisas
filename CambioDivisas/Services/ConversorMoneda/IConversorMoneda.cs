
using CambioDivisas.Models;
using System.Collections.Generic;

namespace CambioDivisas.Services.ConversorMoneda
{
    public interface IConversorMoneda
    {
        void CargarDatos(List<Rates> listaRates);
        decimal ConvertirValor(decimal valor, string monedaOrigen, string monedaDestino);
    }
}
