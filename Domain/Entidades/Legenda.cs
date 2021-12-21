using Flunt.Notifications;
using Shared.Extentions;

namespace Domain.Entidades
{
    public class Legenda : Notifiable<Notification>
    {
        public int Id { get; private set; }
        public string Texto { get; private set; }

        public Legenda()
        {

        }

        public Legenda(string texto)
        {
            Texto = texto;
            
            if (Texto.IsNullOrEmpty())
            {
                AddNotification("Texto", "O texto não pode estar nulo.");
            }
        }
    }
}
