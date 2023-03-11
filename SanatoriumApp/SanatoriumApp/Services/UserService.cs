using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Services
{
    internal static class UserService
    {
        internal static List<User> GetAllUsers()
        {
            using (var context = new ApplicationDbContext()) { return context.Users.ToList(); }
        }
    }
}
