using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entidades
{
    public class TimerCode : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public int Numero { get; private set; }
        public TimeSpan DuracaoInicial { get; private set; }
        public TimeSpan DuracaoFinal { get; private set; }
        public List<Legenda> Legendas { get; private set; }

        public TimerCode()
        {

        }

        public TimerCode(int numero, TimeSpan durationInicial, TimeSpan durationFinal, List<Legenda> legendas)
        {
            Numero = numero;
            DuracaoInicial = durationInicial;
            DuracaoFinal = durationFinal;
            Legendas = legendas;

            if (Numero <= 0)
                AddNotification("Numero", "O numero deve ser maior do que zero.");
            if (DuracaoInicial == TimeSpan.Zero)
                AddNotification("DuracaoInicial", "Informe uma data inicial valida.");
            if (DuracaoFinal  == TimeSpan.Zero)
                AddNotification("DuracaoFinal", "Informe uma data final valida.");
        }

        public void AplicarDeslocamento(TimeSpan time)
        {
            DuracaoInicial = DuracaoInicial.Add(time);
            DuracaoFinal = DuracaoFinal.Add(time);
        }
    }
}
