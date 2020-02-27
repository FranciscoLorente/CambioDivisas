using CambioDivisas.InfraestructuraTransversal.Excepciones;
using CambioDivisas.Models;
using System;
using System.Collections.Generic;

namespace CambioDivisas.Services.Factorias
{
    public class TransaccionesFactory: ITransaccionesFactory
    {
        public List<Transacciones> CrearListaTransacciones(List<Transacciones> lista)
        {
            List<Transacciones> listaGenerada = new List<Transacciones>();

            try
            {
                foreach (var item in lista)
                {
                    var Rate = new Transacciones
                    {
                        ID = item.ID,
                        Sku = item.Sku,
                        Amount = item.Amount,
                        Currency = item.Currency
                    };

                    listaGenerada.Add(Rate);
                }

                return listaGenerada;
            }
            catch (Exception exc)
            {
                throw new TransaccionesFactoryException("Error al crear la lista de las transacciones", exc);
            }
        }
    }
}