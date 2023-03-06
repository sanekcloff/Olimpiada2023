using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SanatoriumApp.ViewModels
{
    internal class MainWindowViewModel
    {
        private List<Client> clients;
        public List<Client> Clients 
        { 
            get => clients; 
            set => clients = value; 
        }
        public MainWindowViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Clients.Add(new Client("Аксёнов","Александр","Игоревич",new DateTime(2003,03,20),'М',"some shit"));
                context.SaveChanges();

                Clients= new List<Client>(context.Clients);
                foreach (var item in Clients)
                {
                    MessageBox.Show($"{item.LastName} {item.FirstName} {item.MiddleName} ({item.DateOfBirth.ToString("d")}; {item.Gender};)");
                }
            }
        }

    }
}
