using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CambioDivisas.Models;
using CambioDivisas.Services.Repositorios.TransaccionesRepository;

namespace CambioDivisas.Controllers
{
    public class TransaccionesController : BaseController
    {
        private readonly ITransaccionesRepository _repositorio;

        public TransaccionesController()
        {
            _repositorio = new TransaccionesRespository();
        }

        public TransaccionesController(ITransaccionesRepository respositorio)
        {
            _repositorio = respositorio;
        }

        // GET: Transacciones
        public async Task<ActionResult> Index()
        {
            await _repositorio.CargarDatos();
            return View(await _repositorio.GetAll());
        }

        // GET: Transacciones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = await _repositorio.GetById(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // GET: Transacciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Sku,Amount,Currency")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Insert(transacciones);
                await _repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(transacciones);
        }

        // GET: Transacciones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = await _repositorio.GetById(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // POST: Transacciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Sku,Amount,Currency")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Update(transacciones);
                await _repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(transacciones);
        }

        // GET: Transacciones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = await _repositorio.GetById(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _repositorio.Delete(id);
            await _repositorio.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
