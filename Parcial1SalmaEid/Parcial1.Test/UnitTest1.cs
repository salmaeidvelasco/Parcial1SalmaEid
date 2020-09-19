using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcial1SalmaEid.Controllers;

namespace Parcial1.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGet()
        {
            //Arrange

            CountriesController controller = new CountriesController();

            //Act

            var lista = controller.GetCountries();

            //Assert
            Assert.IsNotNull(lista);
        }
    }
}
