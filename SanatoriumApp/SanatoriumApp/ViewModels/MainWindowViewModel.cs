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
        public MainWindowViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                var role1 = new Role { Title = "Admin" };
                var user1 = new User { Login = "guest",Password="guest",Role=role1 };
                var client1 = new Client { LastName = "Аксёнов", FirstName = "Александр", MiddleName = "Игоревич", DateOfBirth = new DateTime(2003, 03, 20), Gender = 'М', Passport = "кам", User=user1};
                context.Roles.Add(role1);
                context.Users.Add(user1);
                context.Clients.Add(client1);
                context.SaveChanges();
            }
        }

    }
}
