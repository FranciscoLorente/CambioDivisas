using CambioDivisas.Services.Repositorios.RatesRepository;
using CambioDivisas.Services.Repositorios.TransaccionesRepository;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CambioDivisas.Controllers.Consultas
{
    public class ListadoSkuVMController : BaseController
    {
        IRatesRepository _ratesRepositorio;
        ITransaccionesRepository _transaccionesRepositorio;

        public ListadoSkuVMController()
        {
            _ratesRepositorio = new RatesRepository();
            _transaccionesRepositorio = new TransaccionesRespository();
        }

        public ListadoSkuVMController(IRatesRepository ratesRepositorio, ITransaccionesRepository transaccionesRepositorio)
        {
            _ratesRepositorio = ratesRepositorio;
            _transaccionesRepositorio = transaccionesRepositorio;
        }

        // GET: TransaccionesPorSku
        public async Task<ActionResult> Index()
        {
            await _ratesRepositorio.CargarDatos();
            await _transaccionesRepositorio.CargarDatos();
            
            return View(_transaccionesRepositorio.ListadoTransaccionesDeSku());
        }

        public ActionResult VerTransacciones(string sku)
        {
            return View(_transaccionesRepositorio.ListadoTransacciones(sku));
        }
    }
}