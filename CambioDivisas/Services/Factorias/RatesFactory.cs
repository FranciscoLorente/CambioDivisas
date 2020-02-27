using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CambioDivisas.InfraestructuraTransversal.Excepciones;
using CambioDivisas.Models;

namespace CambioDivisas.Services.Factorias
{
    public class RatesFactory : IRatesFactory
    {
        public List<Rates> CrearListaRates(List<Rates> lista)
        {
            List<Rates> listaGenerada = new List<Rates>();

            try
            {
                foreach (var item in lista)
                {
                    var Rate = new Rates
                    {
                        ID = item.ID,
                        From = item.From,
                        To = item.To,
                        Rate = item.Rate
                    };

                    listaGenerada.Add(Rate);
                }

                return listaGenerada;
            }
            catch(Exception exc)
            {
                throw new RatesFactoryException("Error al crear la lista de cambios de moneda", exc);
            }
        }
    }
}