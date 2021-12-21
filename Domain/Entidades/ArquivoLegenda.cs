using Flunt.Notifications;
using Shared.Extentions;

namespace Domain.Entidades
{
    public class ArquivoLegenda : Notifiable<Notification>
    {
        public int Id { get; private set; }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set 
            {
                _nome = value;
                ValidarNome(_nome);
            }
        }

        protected void ValidarNome(string nome)
        {
            if (nome.Length < 5)
                AddNotification("Nome", "O nome do arquivo deve ter no minimo 5 caracteres");
        }
    }
}
