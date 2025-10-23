using System.Collections.Generic;

namespace DemoLib.Models
{
    public interface IClientsModel
    {
        List<Client> ReadAllClients();

        int GetClientsCount();

        int GenerateNextID();

        void AddClient(Client client);
    }
}
