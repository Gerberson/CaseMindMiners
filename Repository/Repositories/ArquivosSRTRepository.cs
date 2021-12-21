using Domain.Entidades;
using Repository.DTO.ArquivoSRT;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.Repositories
{
    public class ArquivosSRTRepository : IArquivosSRTRepository
    {
        private readonly string _raiz = Path.GetTempFileName();
        private string _diretorioOriginal;
        private string _diretorioDeslocada;
        private string _fileName;
        public ArquivosSRTRepository()
        {
            _diretorioOriginal = Path.Combine(Directory.GetCurrentDirectory().Replace(@"\bin\Debug\netcoreapp3.1", ""), @"Arquivos\Legendas\Original");
            _diretorioDeslocada = Path.Combine(Directory.GetCurrentDirectory().Replace(@"\bin\Debug\netcoreapp3.1", ""), @"Arquivos\Legendas\Deslocada");

            if (!Directory.Exists(_diretorioOriginal))
                Directory.CreateDirectory(_diretorioOriginal);

            if (!Directory.Exists(_diretorioDeslocada))
                Directory.CreateDirectory(_diretorioDeslocada);
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
            string _diretorioOriginal = Path.Combine(Directory.GetCurrentDirectory().Replace(@"\bin\Debug\netcoreapp3.1", ""), @"Arquivos\Legendas\Original");
            string _diretorioDeslocada = Path.Combine(Directory.GetCurrentDirectory().Replace(@"\bin\Debug\netcoreapp3.1", ""), @"Arquivos\Legendas\Deslocada");

            if (!Directory.Exists(_diretorioOriginal))
                Directory.CreateDirectory(_diretorioOriginal);

            if (!Directory.Exists(_diretorioDeslocada))
                Directory.CreateDirectory(_diretorioDeslocada);

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
