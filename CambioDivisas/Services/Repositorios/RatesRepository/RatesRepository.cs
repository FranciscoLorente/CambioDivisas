using CambioDivisas.InfraestructuraTransversal.Excepciones;
using CambioDivisas.Models;
using CambioDivisas.Services.Factorias;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CambioDivisas.Services.Repositorios.RatesRepository
{
    public class RatesRepository : GenericRepository<Rates>, IRatesRepository
    {
        protected IRatesFactory _factoria;

        public RatesRepository()
        {
            _factoria = new RatesFactory();
        }

        public RatesRepository(IRatesFactory factoria)
        {
            _factoria = factoria;
        }

        public override async Task CargarDatos()
        {
            string url = "http://quiet-stone-2094.herokuapp.com/rates.json";
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    List<Rates> lista;
                    string contenido = await response.Content.ReadAsStringAsync();
                    {
                        lista = _conversor.DeserealizarJson(contenido);
                    }

                    _tabla.RemoveRange(_tabla);
                    lista = _factoria.CrearListaRates(lista);
                    _tabla.AddRange(lista);

                    await _contexto.SaveChangesAsync();
                }
                catch (HttpRequestException) { }
                catch (Exception exc)
                {
                    throw new RepositoryException("No se han podido cargar los datos en el repositorio.", exc);
                }
            }
        }
    }
}