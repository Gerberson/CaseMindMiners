using Microsoft.AspNetCore.Mvc;
using Repository.DTO.ArquivoSRT;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Controller]
    public class ArquivoSRTController : ControllerBase
    {
        private readonly IArquivosSRTRepository _arquivosSRTRepository;
        public ArquivoSRTController(IArquivosSRTRepository arquivosSRTRepository)
        {
            _arquivosSRTRepository = arquivosSRTRepository;
        }

        [HttpGet]
        [Route("ListarArquivosSRT")]
        public ActionResult<List<ArquivoSRTDTO>> ListarArquivosSRT()
        {
            try
            {
                var arquivos = _arquivosSRTRepository.ListarTodosArquivosSRT();
                return Ok(new
                {
                    Succeso = true,
                    Menssagem = "Arquivos listados com sucesso.",
                    Data = arquivos.Select(x => new { x.Id, x.Nome })
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Succeso = false,
                    Menssagem = $"O correu um erro ao listar todos arquivos. Error: {e.Message}",
                    Data = new { }
                });
            }
        }

        [HttpPost]
        [Route("DeslocarTimerCode/{id}")]
        public ActionResult DeslocarTimerCode(int id, [FromBody] DeslocamentoTimerCodeDTO deslocamentoDto)
        {
            try
            {
                var arquivo = _arquivosSRTRepository.DeslocarTimerCode(id, deslocamentoDto);
                return Ok(new
                {
                    Succeso = true,
                    Menssagem = $"Timers Code deslocados com sucesso. Path: {_arquivosSRTRepository.PathArquivosDeslocados()}",
                    Data = new { }
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Succeso = false,
                    Menssagem = $"O correu um erro ao realizar o deslocamento dos Timers Code. Error: {e.Message}",
                    Data = new { }
                });
            }
        }
    }
}
