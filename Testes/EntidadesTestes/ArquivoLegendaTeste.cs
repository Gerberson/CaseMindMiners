using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.EntidadesTestes
{
    [TestClass]
    public class ArquivoLegendaTeste
    {
        [TestMethod]
        public void DeveRetornarVerdadiroQuandoAClasseEstiverValida()
        {
            ArquivoLegenda arquivo = new ArquivoLegenda();
            arquivo.Nome = "Venom.srt";

            Assert.AreEqual(true, arquivo.IsValid);
        }

        [TestMethod]
        public void DeveRetornarFalsoQuandoAClasseEstiverInvalida()
        {
            ArquivoLegenda arquivo = new ArquivoLegenda();
            arquivo.Nome = "";

            Assert.AreEqual(false, arquivo.IsValid);
        }
    }
}
