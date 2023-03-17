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
    static class ClientService
    {
        public static ICollection<Client> GetClients()
        {
            using (var context = new ApplicationDbContext())
            { 
                return context.Clients.ToList();
            }
        }

        public static bool AddClient(Client client)
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
            using (var context = new ApplicationDbContext()) 
            { 
                context.Clients.Add(client);
                context.SaveChanges();
                MessageBox.Show($"Клиент {client.FullName} успешно добавлен!");
                return true;
            }
        }

        public static ICollection<Client> SearchClient(string searchValue) 
        { 
            using (var context = new ApplicationDbContext())
            {
                if(searchValue!=string.Empty)
                return context.Clients.Where(c=>c.LastName.Contains(searchValue)).ToList();
                else return GetClients();
            }
        }
    }
}
