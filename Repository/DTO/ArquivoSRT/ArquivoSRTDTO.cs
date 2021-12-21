using Flunt.Notifications;
using Shared.Extentions;

namespace Repository.DTO.ArquivoSRT
{
    public class ArquivoSRTDTO : Notifiable<Notification>
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ArquivoSRTDTO()
        {

        }

        public ArquivoSRTDTO(int id, string nome)
        {
            Id = id;
            Nome = nome;

            if (id == 0)
                AddNotification("Id", "Informe o id do arquivo a ser aplicado o deslocamento do timer code.");
            if (nome.IsNullOrEmpty())
                AddNotification("Nome", "Informe o nome do arquivo corretamente");
        }
    }
}
