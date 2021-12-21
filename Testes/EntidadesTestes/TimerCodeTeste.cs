using Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testes.EntidadesTestes
{
    [TestClass]
    public class TimerCodeTeste
    {
        private readonly int _numeroTimerCodeValido;
        private readonly TimeSpan _deslocamentoValido;
        private readonly TimeSpan _duracaoInicialValido;
        private readonly TimeSpan _duracaoFinalValido;
        private readonly List<Legenda> _legendas = new List<Legenda>();
        private readonly TimerCode _timerCodeValido;
        private readonly TimeSpan _duracaoInicialDeslocado;
        private readonly TimeSpan _duracaoFinalDeslocado;
        private readonly int _numeroTimerCodeInvalido;
        private readonly TimeSpan _deslocamentoInvalido;
        private readonly TimeSpan _duracaoInicialInvalido;
        private readonly TimeSpan _duracaoFinalInvalido;
        private readonly TimerCode _timerCodeInvalido;


        public TimerCodeTeste()
        {
            _deslocamentoValido = new TimeSpan(0, 0, 0, 10, 0);
            _duracaoInicialValido = new TimeSpan(0, 0, 1, 25, 584);
            _duracaoFinalValido = new TimeSpan(0, 0, 1, 31, 056);
            _legendas.Add(new Legenda("Hello Mark!"));
            _numeroTimerCodeValido = 1;
            _timerCodeValido = new TimerCode(_numeroTimerCodeValido, _duracaoInicialValido, _duracaoFinalValido, _legendas);

            _deslocamentoInvalido = new TimeSpan();
            _duracaoInicialInvalido = new TimeSpan();
            _duracaoFinalInvalido = new TimeSpan();
            _legendas.Add(new Legenda("Hello Mark!"));
            _numeroTimerCodeInvalido = 0;
            _timerCodeInvalido = new TimerCode(_numeroTimerCodeInvalido, _duracaoInicialInvalido, _duracaoFinalInvalido, _legendas);

            _duracaoInicialDeslocado = _duracaoInicialValido.Add(_deslocamentoValido);
            _duracaoFinalDeslocado = _duracaoFinalValido.Add(_deslocamentoValido);
        }

        public TimerCodeTeste(TimerCode timerCode, TimeSpan deslocamento)
        {
            _deslocamentoValido = deslocamento;
            _timerCodeValido = timerCode;
            _duracaoInicialDeslocado = _timerCodeValido.DuracaoInicial.Add(_deslocamentoValido);
            _duracaoFinalDeslocado = _timerCodeValido.DuracaoFinal.Add(_deslocamentoValido);
        }

        [TestMethod]
        public void DeveRetornarVerdadiroQuandoAClasseEstiverValida()
        {
            Assert.AreEqual(true, _timerCodeValido.IsValid);
        }

        [TestMethod]
        public void DeveRetornarFalsoQuandoAClasseEstiverInvalida()
        {
            Assert.AreEqual(false, _timerCodeInvalido.IsValid);
        }

        [TestMethod]
        public void DeveRetornarVerdadeiroQuandoDeslocamentoAplicadoEmUmTimerCodeEstiverValido()
        {
            bool testeValido = AplicarDeslocamentoValido();
            Assert.AreEqual(true, testeValido);
        }

        [TestMethod]
        public void DeveRetornarFalsoQuandoDeslocamentoAplicadoEmUmTimerCodeEstiverInvalido()
        {
            bool testeValido = AplicarDeslocamentoInvalido();
            Assert.AreEqual(false, testeValido);
        }

        public bool AplicarDeslocamentoValido()
        {
            _timerCodeValido.AplicarDeslocamento(_deslocamentoValido);

            bool deslocamentoDuracaoInicial = _timerCodeValido.DuracaoInicial == _duracaoInicialDeslocado;
            bool deslocamentoDuracaoFinal = _timerCodeValido.DuracaoFinal == _duracaoFinalDeslocado;
            bool deslocamentoValido = deslocamentoDuracaoInicial && deslocamentoDuracaoFinal;

            return deslocamentoValido;
        }

        public bool AplicarDeslocamentoInvalido()
        {
            _timerCodeValido.AplicarDeslocamento(_deslocamentoValido);

            bool deslocamentoDuracaoInitial = _timerCodeValido.DuracaoInicial == _duracaoInicialDeslocado;
            bool deslocamentoDuracaoFinal = _timerCodeValido.DuracaoFinal == _duracaoFinalDeslocado.Add(new TimeSpan(0, 0, 0, 0, 100));
            bool deslocamentoValido = deslocamentoDuracaoInitial && deslocamentoDuracaoFinal;

            return deslocamentoValido;
        }
    }
}
