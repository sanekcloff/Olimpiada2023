using Application2.Entities;
using Application2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.ViewModels
{
    internal class MainViewModel:ViewModelBase
    {
        #region properties & fields
        private List<Client> _clients=null!;
        private List<SanatoriumRoom> _sanatoriumRooms=null!;
        private List<SanatoriumProgram> _sanatoriumPrograms = null!;

        private DateTime _dateOfCheckIn;
        private DateTime _dateOfCheckOut;

        private Client _selectedClient;
        private SanatoriumRoom _selectedSanatoriumRoom;
        private SanatoriumProgram _selectedSanatoriumProgram;
        

        public List<Client> Clients 
        { 
            get => _clients; 
            set => Set(ref _clients, value, nameof(Clients)); 
        }
        public List<SanatoriumRoom> SanatoriumRooms 
        { 
            get => _sanatoriumRooms; 
            set => Set(ref _sanatoriumRooms, value, nameof(SanatoriumRooms)); 
        }
        public List<SanatoriumProgram> SanatoriumPrograms 
        { 
            get => _sanatoriumPrograms; 
            set => Set(ref _sanatoriumPrograms, value, nameof(SanatoriumPrograms)); 
        }

        public DateTime DateOfCheckIn 
        { 
            get => _dateOfCheckIn;
            set => Set(ref _dateOfCheckIn,value, nameof(DateOfCheckIn));
        }
        public DateTime DateOfCheckOut 
        { 
            get => _dateOfCheckOut; 
            set => Set(ref _dateOfCheckOut, value, nameof(DateOfCheckOut)); 
        }

        public Client SelectedClient 
        { 
            get => _selectedClient; 
            set => Set(ref _selectedClient, value, nameof(SelectedClient)); 
        }
        public SanatoriumRoom SelectedSanatoriumRoom 
        { 
            get => _selectedSanatoriumRoom; 
            set => Set(ref _selectedSanatoriumRoom, value, nameof(SelectedSanatoriumRoom)); 
        }
        public SanatoriumProgram SelectedSanatoriumProgram 
        { 
            get => _selectedSanatoriumProgram; 
            set => Set(ref _selectedSanatoriumProgram, value, nameof(SelectedSanatoriumProgram)); 
        }
        #endregion
        public MainViewModel()
        {
            DateOfCheckIn=DateTime.Now;
            DateOfCheckOut=DateTime.Now.AddDays(1);

            Clients= new List<Client>(ClientService.GetClients());
        }
    }
}
