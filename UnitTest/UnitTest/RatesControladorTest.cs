using CambioDivisas.Controllers;
using CambioDivisas.Models;
using CambioDivisas.Services.Repositorios.RatesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTest.UnitTest
{
    [TestClass]
    public class RatesControladorTest
    {
        RatesController controlador = new RatesController();

        [TestMethod]
        public async Task PruebaIndex()
        {
            var resultado = await controlador.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);
        }

        [TestMethod]
        public async Task PruebaCrear()
        {
            IRatesRepository repositorio = new RatesRepository();
            Rates rate = new Rates { From = "EUR", To = "USD", Rate = 1.58m };

            var resultado = await controlador.Create(rate);
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);
            var rateGuardado = await repositorio.GetById(rate.ID);
            Assert.IsNotNull(rateGuardado);

            Assert.AreEqual(rate.From, rateGuardado.From);
            Assert.AreEqual(rate.To, rateGuardado.To);
            Assert.AreEqual(rate.Rate, rateGuardado.Rate);

            await repositorio.Delete(rate.ID);
            await repositorio.Save();
        }
    }
}
