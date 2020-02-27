using CambioDivisas.DAL;
using CambioDivisas.Services.JsonConverter;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CambioDivisas.Services.Repositorios
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected CambioDivisasContext _contexto;
        protected DbSet<T> _tabla;
        protected IJsonConverter<T> _conversor;

        public GenericRepository()
        {
            _contexto = new CambioDivisasContext();
            _tabla = _contexto.Set<T>();
            _conversor = new GenericNewtonJsonConverter<T>();
        }

        public GenericRepository(CambioDivisasContext contexto)
        {
            _contexto = contexto;
            _tabla = _contexto.Set<T>();
            _conversor = new GenericNewtonJsonConverter<T>();
        }

        public GenericRepository(CambioDivisasContext contexto, IJsonConverter<T> conversor)
        {
            _contexto = contexto;
            _tabla = _contexto.Set<T>();
            _conversor = conversor;
        }

        public abstract Task CargarDatos();

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _tabla.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await _tabla.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
            _tabla.Add(obj);
        }

        public virtual void Update(T obj)
        {
            _tabla.Attach(obj);
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task Delete(object id)
        {
            T existing = await _tabla.FindAsync(id);
            _tabla.Remove(existing);
        }

        public virtual async Task Save()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}