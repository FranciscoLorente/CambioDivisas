using CambioDivisas.Models;
using System.Collections.Generic;

namespace CambioDivisas.Services.ConversorMoneda
{
    public class ConversorDeMoneda: IConversorMoneda
    {
        public List<Rates> _listaRates;

        public void CargarDatos(List<Rates> listaRates)
        {
            _listaRates = listaRates;
        }

        public decimal ConvertirValor(decimal valor, string monedaOrigen, string monedaDestino)
        {
            //Aquí se implementa el algoritmo Dijkstra para buscar los datos y calcular el valor correcto.
            return valor;
        }
    }
}