using System.Collections.Generic;

namespace CambioDivisas.Services.JsonConverter
{
    public interface IJsonConverter<T> where T: class
    {
        List<T> DeserealizarJson(string contenido);
    }
}
