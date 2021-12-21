using System;
using Shared.Extentions;
using System.Collections.Generic;
using System.IO;
using Domain.Entidades.Interfaces;

namespace Domain.Entidades
{
    public class ArquivoSRT : ArquivoLegenda, IArquivoLegenda, IArquivoSRT
    {
        public int Id { get; private set; }
        public List<TimerCode> TimersCode { get; private set; }
        public ArquivoSRT()
        {
            TimersCode = new List<TimerCode>();

            if (TimersCode == null)
                AddNotification("TimersCode", "O timer code não pode ser nulo.");
        }

        public ArquivoSRT(string file) : this()
        {
            ParseArquivoSRT(file);
        }

        public void ParseArquivoSRT(string file)
        {
            int posicaoTimerCode = 0;
            int posicaoTempo = 0;
            int posicaoLegenda = 0;
            int linhaEmBranco = 0;

            var linhasLegenda = File.ReadAllLines(file);
            for (int linha = 0; linha < linhasLegenda.Length; linha++)
            {
                posicaoTimerCode = linha;
                string numero = linhasLegenda[posicaoTimerCode];

                linha++;
                posicaoTempo = linha;

                var duracao = linhasLegenda[posicaoTempo].Split("-->");
                string durationInitial = duracao[0].Trim();
                string durationFinal = duracao[1].Trim();

                linha++;

                List<Legenda> legendas = new List<Legenda>();

                do
                {
                    posicaoLegenda = linha;

                    string legenda = linhasLegenda[posicaoLegenda];
                    legendas.Add(new Legenda(legenda));

                    linha++;

                } while (linhasLegenda[linha].IsNotNullOrEmpty());

                linhaEmBranco = linha;

                TimerCode timerCode = new TimerCode(numero.ToInt(), durationInitial.ToTimeSpan(), durationFinal.ToTimeSpan(), legendas);
                TimersCode.Add(timerCode);
            }
        }

        public void AplicarDeslocamento(TimeSpan time)
        {
            foreach (var timerCode in TimersCode)
            {
                timerCode.AplicarDeslocamento(time);
            }
        }

        public void MontarArquivoSRT(string path, string filaName)
        {
            string[] lines = { };
            using (StreamWriter file = new StreamWriter(Path.Combine(path, filaName)))
            {
                foreach (var timerCode in TimersCode)
                {
                    file.WriteLine(timerCode.Numero.ToString());
                    file.WriteLine($"{timerCode.DuracaoInicial.ToString(@"hh\:mm\:ss\,fff")} --> {timerCode.DuracaoFinal.ToString(@"hh\:mm\:ss\,fff")}");

                    foreach (var legenda in timerCode.Legendas)
                    {
                        file.WriteLine(legenda.Texto);
                    }
                    file.WriteLine("");
                }
            }
        }
    }
}
