using Flunt.Notifications;

namespace Repository.DTO.ArquivoSRT
{
    public class DeslocamentoTimerCodeDTO
    {
        public int Horas { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }
        public int Milissegundos { get; set; }

        public DeslocamentoTimerCodeDTO()
        {

        }

        public DeslocamentoTimerCodeDTO(int horas, int minutos, int segundos, int milisegundos)
        {
            Horas = horas;
            Minutos = minutos;
            Segundos = segundos;
            Milissegundos = milisegundos;
        }
    }
}
