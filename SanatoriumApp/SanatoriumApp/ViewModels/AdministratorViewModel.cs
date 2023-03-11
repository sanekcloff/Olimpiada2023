using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using SanatoriumApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.ViewModels
{
    internal class AdministratorViewModel:ViewModelBase
    {
        #region Fields & Properties
        private List<Client> _clients = null!;
        private List<SanatoriumProgram> _sanatoriumPrograms= null!;
        private List<SanatoriumRoom> _sanatoriumRooms = null!;

        private Client _selectedClient = null!;
        private SanatoriumProgram _selectedProgram= null!;
        private SanatoriumRoom _selectedRoom= null!;

        public List<Client> Clients 
        { 
            get => _clients; 
            set => Set(ref _clients, value, nameof(Clients)); 
        }
        public List<SanatoriumProgram> SanatoriumPrograms 
        { 
            get => _sanatoriumPrograms; 
            set => Set(ref _sanatoriumPrograms, value, nameof(SanatoriumPrograms)); 
        }
        public List<SanatoriumRoom> SanatoriumRooms 
        { 
            get => _sanatoriumRooms; 
            set => Set(ref _sanatoriumRooms, value, nameof(SanatoriumRooms)); 
        }
        public Client SelectedClient 
        { 
            get => _selectedClient; 
            set => Set(ref _selectedClient, value, nameof(SelectedClient)); 
        }
        public SanatoriumProgram SelectedProgram 
        { 
            get => _selectedProgram; 
            set => Set(ref _selectedProgram, value, nameof(SelectedProgram)); 
        }
        public SanatoriumRoom SelectedRoom 
        { 
            get => _selectedRoom; 
            set => Set(ref _selectedRoom, value, nameof(SelectedRoom )); 
        }
        #endregion
        public AdministratorViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                Clients = new List<Client>(ClientService.GetAllClients());
                SanatoriumPrograms= new List<SanatoriumProgram>(SanatoriumProgramService.GetAllSanatoriumPrograms());
                SanatoriumRooms= new List<SanatoriumRoom>(SanatoriumRoomService.GetAllSanatoriumRooms());
            }
        }

        
    }
}
