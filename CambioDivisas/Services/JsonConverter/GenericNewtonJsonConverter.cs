using CambioDivisas.InfraestructuraTransversal.Excepciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CambioDivisas.Services.JsonConverter
{
    public class GenericNewtonJsonConverter<T>: IJsonConverter<T> where T: class
    {
        public List<T> DeserealizarJson(string contenido)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<T>>(contenido);
            }
            catch(Exception exc)
            {
                throw new JsonConverterException("Error al deserealizar el contenido del Json", exc);
            }
        }
    }
}