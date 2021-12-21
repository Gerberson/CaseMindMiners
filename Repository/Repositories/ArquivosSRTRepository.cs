using Domain.Entidades;
using Repository.DTO.ArquivoSRT;
using Repository.Repositories.Interfaces;
using Shared.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.Repositories
{
    public class ArquivosSRTRepository : IArquivosSRTRepository
    {
        private string _diretorioOriginal = Path.Combine(Directory.GetCurrentDirectory().Replace(@"\Testes\bin\Debug\netcoreapp3.1", ""), @"Arquivos\Legendas\Original");
        private string _diretorioDeslocada = Path.Combine(Directory.GetCurrentDirectory().Replace(@"\Testes\bin\Debug\netcoreapp3.1", ""), @"Arquivos\Legendas\Deslocada");
        private string _fileName;
        public ArquivosSRTRepository()
        {
            _diretorioOriginal.CriarDiretorio();
            _diretorioDeslocada.CriarDiretorio();
        }

        public ArquivoSRT DeslocarTimerCode(int id, DeslocamentoTimerCodeDTO deslocamentoDto)
        {
            var arquivo = Directory.GetFiles(_diretorioOriginal)[id];
            _fileName = arquivo.Split(@"\").LastOrDefault();
            ArquivoSRT arquivoSRT = new ArquivoSRT(arquivo);
            TimeSpan deslocamento = new TimeSpan(deslocamentoDto.Horas, deslocamentoDto.Minutos, deslocamentoDto.Segundos, deslocamentoDto.Milissegundos);
            arquivoSRT.AplicarDeslocamento(deslocamento);
            arquivoSRT.MontarArquivoSRT(_diretorioDeslocada, _fileName);
            return arquivoSRT;
        }

        public List<ArquivoSRTDTO> ListarTodosArquivosSRT()
        {
            var arquivos = Directory.GetFiles(_diretorioOriginal);

            List<ArquivoSRTDTO> arquivosDTO = new List<ArquivoSRTDTO>();
            int id = 0;
            foreach (var arquivo in arquivos)
            {
                string nome = arquivo.Split(@"\").LastOrDefault();
                arquivosDTO.Add(new ArquivoSRTDTO()
                {
                    Id = id,
                    Nome = nome
                });

                id++;
            }

            return arquivosDTO;
        }

        public string PathArquivosDeslocados() => Path.Combine(_diretorioDeslocada, _fileName);
    }
}
