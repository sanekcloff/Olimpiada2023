using Application2.Data;
using Application2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Application2.Services
{
    public class ClientService
    {
        private ApplicationDbContext _ctx;

        public ClientService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Client> GetClients()
        {
            return _ctx.Clients
                .ToList();
        }

        public bool Insert(Client client)
        {
            if (client.LastName==string.Empty
                ||client.FirstName==string.Empty
                ||client.MiddleName==string.Empty
                ||client.PassportNumber==string.Empty
                ||client.PassportSeries==string.Empty)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return false;
            }
            _ctx.Clients.Add(client);
            _ctx.SaveChanges();
            MessageBox.Show($"Клиент {client.FullName} успешно добавлен!");
            return true;
        }

        public ICollection<Client> Search(string searchValue) 
        { 
            using (var _ctx = new ApplicationDbContext())
            {
                if(searchValue!=string.Empty)
                    return _ctx.Clients.Where(c=>c.LastName.Contains(searchValue)).ToList();
                else 
                    return GetClients();
            }
        }
    }
}
