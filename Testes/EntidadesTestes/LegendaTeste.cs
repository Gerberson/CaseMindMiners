using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.EntidadesTestes
{
    [TestClass]
    public class LegendaTeste
    {
        [TestMethod]
        public void DeveRetornarVerdadiroQuandoAClasseEstiverValida()
        {
            string texto = "Olá Marcos!!";
            Legenda legenda = new Legenda(texto);

            Assert.AreEqual(true, legenda.IsValid);
        }

        [TestMethod]
        public void DeveRetornarFalsoQuandoAClasseEstiverInvalida()
        {
            string texto = "";
            Legenda legenda = new Legenda(texto);

            Assert.AreEqual(false, legenda.IsValid);
        }
    }
}
