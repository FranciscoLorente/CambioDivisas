using CambioDivisas.InfraestructuraTransversal.Excepciones;
using CambioDivisas.Models;
using CambioDivisas.Models.ViewModel;
using CambioDivisas.Services.Factorias;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CambioDivisas.Services.ConversorMoneda;

namespace CambioDivisas.Services.Repositorios.TransaccionesRepository
{
    public class TransaccionesRespository : GenericRepository<Transacciones>, ITransaccionesRepository
    {
        protected ITransaccionesFactory _factoria;
        protected IConversorMoneda _conversorMoneda;

        public TransaccionesRespository()
        {
            _factoria = new TransaccionesFactory();
            _conversorMoneda = new ConversorDeMoneda();
        }

        public TransaccionesRespository(ITransaccionesFactory factoria, IConversorMoneda conversor)
        {
            _factoria = factoria;
            _conversorMoneda = conversor;
        }

        public override async Task CargarDatos()
        {
            string url = "http://quiet-stone-2094.herokuapp.com/transactions.json";
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    List<Transacciones> lista;
                    string contenido = await response.Content.ReadAsStringAsync();
                    {
                        lista = _conversor.DeserealizarJson(contenido);
                    }

                    _tabla.RemoveRange(_tabla);
                    lista = _factoria.CrearListaTransacciones(lista);
                    _tabla.AddRange(lista);

                    await _contexto.SaveChangesAsync();
                }
                catch (HttpRequestException){ }
                catch (Exception exc)
                {
                    throw new RepositoryException("No se han podido cargar los datos en el repositorio.", exc);
                }
            }
        }

        public List<ListadoSkuVM> ListadoTransaccionesDeSku()
        {
            _conversorMoneda.CargarDatos(_contexto.Rates.ToList());

            var listadoSku = new List<ListadoSkuVM>();
            var query = from transaccion in _tabla
                        group transaccion by transaccion.Sku into transaccionSku
                        select new
                        {
                            Sku = transaccionSku.Key,
                            SumaTotal = transaccionSku.Sum(x=> x.Amount),
                            //SumaTotal = transaccionSku.Sum(x=>
                            //    _conversorMoneda.ConvertirValor(x.Amount, x.Currency, "EUR")),
                            Moneda = "EUR"
                        };

            foreach(var item in query)
            {
                var sku = new ListadoSkuVM
                {
                    Sku = item.Sku,
                    SumaTotal = item.SumaTotal,
                    Moneda = "EUR"
                };

                listadoSku.Add(sku);
            }

            return listadoSku;
        }

        public List<Transacciones> ListadoTransacciones(string sku)
        {
            var query = from transaccion in _tabla
                        where transaccion.Sku == sku
                        select transaccion;

            foreach(var item in query)
            {
                item.Amount = _conversorMoneda.ConvertirValor(item.Amount, item.Currency, "EUR");
                item.Currency = "EUR";
            }

            return query.ToList();
        }
    }
}