using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CambioDivisas.Models;
using CambioDivisas.Services.Repositorios.RatesRepository;

namespace CambioDivisas.Controllers
{
    public class RatesController : BaseController
    {
        private IRatesRepository _repositorio;

        public RatesController()
        {
            _repositorio = new RatesRepository();
        }

        public RatesController(IRatesRepository respositorio)
        {
            _repositorio = respositorio;
        }

        // GET: Rates
        public async Task<ActionResult> Index()
        {
            await _repositorio.CargarDatos();
            return View(await _repositorio.GetAll());
        }

        // GET: Rates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates rates = await _repositorio.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,From,To,Rate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Insert(rates);
                await _repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(rates);
        }

        // GET: Rates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates rates = await _repositorio.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,From,To,Rate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Update(rates);
                await _repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(rates);
        }

        // GET: Rates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates rates = await _repositorio.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Delete/5
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
