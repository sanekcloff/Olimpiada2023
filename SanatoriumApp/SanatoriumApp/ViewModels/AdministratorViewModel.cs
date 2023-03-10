using Microsoft.EntityFrameworkCore;
using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.ViewModels
{
    class AdministratorViewModel:ViewModelBase
    {
        #region Fields & Properties
        private List<Client> _clients = null!;
        private List<SanatoriumRoom> _sanatoriumRooms = null!;
        private List<SanatoriumProgram> _sanatoriumPrograms = null!;

        internal List<Client> Clients { get => _clients; set => _clients = value; }
        internal List<SanatoriumRoom> SanatoriumRooms { get => _sanatoriumRooms; set => _sanatoriumRooms = value; }
        internal List<SanatoriumProgram> SanatoriumPrograms { get => _sanatoriumPrograms; set => _sanatoriumPrograms = value; }
        #endregion
        public AdministratorViewModel(Client client)
        {
            using (var context = new ApplicationDbContext())
            {
                Clients = context.Clients
                    .Include(u => u.User)
                    .ToList();
                SanatoriumRooms = context.SanatoriumRooms
                    .Include(src=>src.SanatoriumRoomCategory)
                    .ToList();
                SanatoriumPrograms = context.SanatoriumPrograms
                    .ToList();
            }
        }
    }
}
