using Application2.Data;
using Application2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Services
{
    internal static class ClientService
    {
        internal static List<Client> GetClients()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clients.ToList();
            }
        }
    }
}
