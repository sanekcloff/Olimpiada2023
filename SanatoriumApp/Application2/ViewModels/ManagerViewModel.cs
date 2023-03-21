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
        private List<Contract> _reportContracts;
        public List<Client> Clients { get => _clients; set => Set(ref _clients, value, nameof(Clients)); }
        public List<Contract> Contracts { get => _contracts; set => Set(ref _contracts, value, nameof(Contracts)); }
        public List<Contract> ReportContracts { get => _reportContracts; set => Set(ref _reportContracts, value, nameof(ReportContracts)); }
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
            set
            {
                Set(ref _checkIn, value, nameof(CheckIn));
                UpdateLists();
            }
        }
        public DateTime CheckOut
        {
            get => _checkOut;
            set
            {
                Set(ref _checkOut, value, nameof(CheckOut));
                UpdateLists();
            }
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

        #region Records
        public record ReportClient(Client client, int contractsCount, decimal paymentAmount);
        public record ReportProgram(SanatoriumProgram program, int contractCount, decimal paymentAmount);

        private List<ReportClient> _reportClients;
        private List<ReportProgram> _reportPrograms;
        public List<ReportClient> ReportClients { get => _reportClients; set => Set(ref _reportClients, value, nameof(ReportClients)); }
        public List<ReportProgram> ReportPrograms { get => _reportPrograms; set => Set(ref _reportPrograms, value, nameof(ReportPrograms)); }
        #endregion
        public ManagerViewModel()
        {
            _context= new ApplicationDbContext();

            ClientService = new ClientService(_context);
            ContractService = new ContractService(_context);
            PaymentService = new PaymentMethodService(_context);
            ProgramService = new SanatoriumProgramService(_context);
            RoomService = new SanatoriumRoomService(_context);
        
            SelectedDate=DateTime.Now;
            CheckIn= DateTime.Now;
            CheckOut= DateTime.Now.AddDays(1);

            UpdateLists();
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
            Contracts = new List<Contract>(ContractService.GetContracts().Where(c => c.SanatoriumRoom.Status == true));
            ReportClients = new List<ReportClient>(GetReportClients());
        }
        private decimal CalculatePaymentAmount(Client client)
        {
            var paymentAmount = 0M;
            foreach (var contract in Contracts.Where(c=>c.Client==client && (c.DateOfCheckIn>=CheckIn && c.DateOfCheckOut<=CheckOut)))
            {
                paymentAmount += contract.PaymentAmount;
            }
            return paymentAmount;
        }
        private List<ReportClient> GetReportClients()
        {
            var reportClient=new List<ReportClient>();
            foreach (var contract in Contracts)
            {
                if (!ReportClients.Any(c=>c.client==contract.Client))
                {
                    reportClient.Add(new ReportClient(contract.Client, contract.Client.Contracts.Count(), CalculatePaymentAmount(contract.Client)));
                }
            }
            return reportClient;
        }
    }
}