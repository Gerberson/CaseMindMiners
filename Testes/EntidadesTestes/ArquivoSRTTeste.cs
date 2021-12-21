using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Testes.EntidadesTestes
{
    [TestClass]
    public class ArquivoSRTTeste
    {
        private TimerCodeTeste _timerCodeTeste;
        private bool _testeAprovado = false;
        private readonly static string _diretorioOriginal = Path.Combine(Directory.GetCurrentDirectory().Replace(@"\Testes\bin\Debug\netcoreapp3.1", ""), @"API\Arquivos\Legendas\Original");
        private readonly string[] _files = Directory.GetFiles(_diretorioOriginal);

        public ArquivoSRTTeste()
        {
            _timerCodeTeste = new TimerCodeTeste();
        }

        [TestMethod]
        public void DeveRetornarVerdadeiroQuandoTodosDeslocamentosAplicadosEstiveremValidos()
        {
            foreach (var file in _files)
            {
                ArquivoSRT arquivoSRT = new ArquivoSRT(file);

                bool deslocamentoValido = false;
                foreach (var timerCode in arquivoSRT.TimersCode)
                {
                    TimeSpan deslocamento = new TimeSpan(0, 0, 0, 10, 0);
                    _timerCodeTeste = new TimerCodeTeste(timerCode, deslocamento);
                    deslocamentoValido = _timerCodeTeste.AplicarDeslocamentoValido();
                }

                if (deslocamentoValido)
                    _testeAprovado = true;
                else
                    _testeAprovado = false;
            }

            Assert.AreEqual(true, _testeAprovado);
        }

        [TestMethod]
        public void DeveRetornarFalsoQuandoTodosDeslocamentosAplicadosEstiveremInvalidos()
        {
            foreach (var file in _files)
            {
                ArquivoSRT arquivoSRT = new ArquivoSRT(file);
                bool deslocamentoValido = false;
                foreach (var timerCode in arquivoSRT.TimersCode)
                {
                    TimeSpan deslocamento = new TimeSpan(0, 0, 0, 10, 0);
                    _timerCodeTeste = new TimerCodeTeste(timerCode, deslocamento);
                    deslocamentoValido = _timerCodeTeste.AplicarDeslocamentoInvalido();
                }

                if (deslocamentoValido)
                    _testeAprovado = true;
                else
                    _testeAprovado = false;
            }

            Assert.AreEqual(false, _testeAprovado);
        }
    }
}
