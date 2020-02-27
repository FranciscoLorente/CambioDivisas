using System.Collections.Generic;
using System.Threading.Tasks;

namespace CambioDivisas.Services.Repositorios
{
    public interface IGenericRepository<T> where T : class
    {
        Task CargarDatos();
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        Task Delete(object id);
        Task Save();
    }
}
