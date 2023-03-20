using Application2.Data;
using Application2.Entities;
using Application2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.ViewModels
{
    public class ManagerViewModel : ViewModelBase
    {
        #region Context
        private ApplicationDbContext _context;
        #endregion

        #region Services
        public ClientService ClientService { get; }
        public ContractService ContractService { get; }
        public PaymentMethodService PaymentService { get; }
        public SanatoriumProgramService ProgramService { get; }
        public SanatoriumRoomService RoomService { get; }
        #endregion

        #region Lists
        private List<Client> _clients;
        private List<Contract> _contracts;
        public List<Client> Clients { get => _clients; set => Set(ref _clients, value, nameof(Clients)); }
        public List<Contract> Contracts { get => _contracts; set => Set(ref _contracts, value, nameof(Contracts)); }
        #endregion

        #region Fields & Properties
        private DateTime _selectedDate;
        private DateTime _checkIn;
        private DateTime _checkOut;
        private Contract _selectedContract;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                Set(ref _selectedDate, value, nameof(SelectedDate));
                Contracts=SelectedDateChange(ContractService.GetContracts().Where(c => c.SanatoriumRoom.Status == true).ToList()).ToList();
            }
        }
        public DateTime CheckIn 
        { 
            get => _checkIn; 
            set => Set(ref _checkIn, value, nameof(CheckIn)); 
        }
        public DateTime CheckOut 
        { 
            get => _checkOut; 
            set => Set(ref _checkOut, value, nameof(CheckOut)); 
        }
        public Contract SelectedContract 
        { 
            get => _selectedContract; 
            set
            {
                Set(ref _selectedContract, value, nameof(SelectedContract));
            }
        }
        #endregion

        public ManagerViewModel()
        {
            _context= new ApplicationDbContext();

            ClientService = new ClientService(_context);
            ContractService = new ContractService(_context);
            PaymentService = new PaymentMethodService(_context);
            ProgramService = new SanatoriumProgramService(_context);
            RoomService = new SanatoriumRoomService(_context);

            UpdateLists();
        
            SelectedDate=DateTime.Now;
        }

        public ICollection<Contract> SelectedDateChange(List<Contract> contracts)
        {
            return contracts
                .Where(c => c.DateOfCheckOut == SelectedDate)
                .ToList();
        }
        public void ChangeRoomStatus()
        {
            RoomService.Update(SelectedContract.SanatoriumRoom, false);
            UpdateLists();
        }
        private void UpdateLists()
        {
            Clients = new List<Client>(ClientService.GetClients().Where(c=>c.ContractCount>=3));
            Contracts = new List<Contract>(ContractService.GetContracts().Where(c => c.SanatoriumRoom.Status == true));
        }
    }
}
