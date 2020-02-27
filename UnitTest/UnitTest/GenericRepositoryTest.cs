using CambioDivisas.Models;
using CambioDivisas.Services.Repositorios.RatesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTest.UnitTest
{
    [TestClass]
    public class GenericRepositoryTest
    {
        Rates rate = new Rates { From = "EUR", To = "USD", Rate = 1.58m };
        IRatesRepository repositorio = new RatesRepository();

        //[TestInitialize]

        [TestMethod]
        public async Task InsertarElemento()
        {
            repositorio.Insert(rate);
            await repositorio.Save();

            var rateGuardado = await repositorio.GetById(rate.ID);
            Assert.IsNotNull(rateGuardado);
            Assert.AreEqual(rate, rateGuardado);

            await repositorio.Delete(rate.ID);
            await repositorio.Save();
        }

        [TestMethod]
        public async Task BorrarElemento()
        {
            repositorio.Insert(rate);
            await repositorio.Delete(rate.ID);
            await repositorio.Save();

            var jugadorGuardado = await repositorio.GetById(rate.ID);
            Assert.IsNull(jugadorGuardado);
        }
    }
}
