using CambioDivisas.Models;
using CambioDivisas.Models.ViewModel;
using System.Collections.Generic;

namespace CambioDivisas.Services.Repositorios.TransaccionesRepository
{
    public interface ITransaccionesRepository: IGenericRepository<Transacciones>
    {
        List<ListadoSkuVM> ListadoTransaccionesDeSku();
        List<Transacciones> ListadoTransacciones(string sku);
    }
}
