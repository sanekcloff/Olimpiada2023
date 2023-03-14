using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Services
{
    internal static class ClientService
    {
        internal static List<Client> GetAllClients()
        {
            using (var context = new ApplicationDbContext()) { return context.Clients.ToList(); }
        }
        internal static void AddClient(Client client)
        {
            using (var context = new ApplicationDbContext()) 
            { 
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }
        internal static void RemoveClient(Client client)
        {
            using (var context = new ApplicationDbContext()) 
            { 
                context.Clients.Remove(client); 
                context.SaveChanges();
            }
        }
    }
}
