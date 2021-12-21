namespace Domain.Entidades.Interfaces
{
    public interface IArquivoLegenda
    {
        abstract void ParseArquivoSRT(string file);
        abstract void MontarArquivoSRT(string path, string filaName);
    }
}
