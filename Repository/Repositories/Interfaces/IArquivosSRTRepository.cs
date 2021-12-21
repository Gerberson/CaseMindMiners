using Domain.Entidades;
using Repository.DTO.ArquivoSRT;
using System.Collections.Generic;

namespace Repository.Repositories.Interfaces
{
    public interface IArquivosSRTRepository
    {
        List<ArquivoSRTDTO> ListarTodosArquivosSRT();
        ArquivoSRT DeslocarTimerCode(int id, DeslocamentoTimerCodeDTO deslocamentoDto);
        string PathArquivosDeslocados();
    }
}
