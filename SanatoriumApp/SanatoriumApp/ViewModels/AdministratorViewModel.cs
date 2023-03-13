using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using SanatoriumApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        private List<PaymentMethod> _paymentMethods=null!;

        private Client _selectedClient = null!;
        private SanatoriumProgram _selectedProgram= null!;
        private SanatoriumRoom _selectedRoom= null!;
        private PaymentMethod _selectedPaymentMethod= null!;

        private decimal _costPerDay;
        private decimal _paymentAmount;
        private DateTime _dateOfCheckIn;
        private DateTime _dateOfCheckOut;

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
            set
            { 
                if (SelectedProgram != null && SelectedRoom != null && SelectedPaymentMethod != null)
                {
                    TreatiesService.CalculateMinDayOfCheckOut(DateOfCheckIn, SelectedProgram);
                    CostPerDay = CostPerDayService.CalculateCost(SelectedProgram, SelectedRoom, DateOfCheckIn, DateOfCheckOut);
                }  
                Set(ref _selectedProgram, value, nameof(SelectedProgram));
            }
        }
        public SanatoriumRoom SelectedRoom 
        { 
            get => _selectedRoom;
            set 
            {
                if (SelectedProgram != null && SelectedRoom != null && SelectedPaymentMethod != null)
                    CostPerDay =CostPerDayService.CalculateCost(SelectedProgram, SelectedRoom, DateOfCheckIn, DateOfCheckOut);
                Set(ref _selectedRoom, value, nameof(SelectedRoom));
            } 
        }
        public decimal CostPerDay 
        { 
            get => _costPerDay;
            set 
            {
                Set(ref _costPerDay, value, nameof(CostPerDay));
                PaymentAmount = TreatiesService.CalculatePaymentAmount(CostPerDay, SelectedPaymentMethod);
            } 
        }
        public DateTime DateOfCheckIn 
        { 
            get => _dateOfCheckIn;
            set
            {
                Set(ref _dateOfCheckIn, value, nameof(DateOfCheckIn));
                if (SelectedProgram != null && SelectedRoom != null && SelectedPaymentMethod != null)
                {
                    
                    DateOfCheckOut=TreatiesService.CalculateMinDayOfCheckOut(DateOfCheckIn, SelectedProgram);
                    CostPerDay = CostPerDayService.CalculateCost(SelectedProgram, SelectedRoom, DateOfCheckIn, DateOfCheckOut);
                }
            }
        }
        public DateTime DateOfCheckOut 
        { 
            get => _dateOfCheckOut;
            set 
            {
                Set(ref _dateOfCheckOut, value, nameof(DateOfCheckOut));
                if (SelectedProgram!=null && SelectedRoom!=null && SelectedPaymentMethod!=null)
                {
                    
                    if (!TreatiesService.CheckMinDays(SelectedProgram, DateOfCheckIn, DateOfCheckOut))
                    {
                        DateOfCheckOut = TreatiesService.CalculateMinDayOfCheckOut(DateOfCheckIn, SelectedProgram);

                    }
                    CostPerDay = CostPerDayService.CalculateCost(SelectedProgram, SelectedRoom, DateOfCheckIn, DateOfCheckOut);
                }
                
            }
        }
        public PaymentMethod SelectedPaymentMethod 
        { 
            get => _selectedPaymentMethod;
            set
            {
                if (SelectedRoom!=null && SelectedProgram!=null)
                {
                    Set(ref _selectedPaymentMethod, value, nameof(SelectedPaymentMethod));
                    CostPerDay = CostPerDayService.CalculateCost(SelectedProgram, SelectedRoom, DateOfCheckIn, DateOfCheckOut);
                }
            }
                
        }
        public List<PaymentMethod> PaymentMethods 
        { 
            get => _paymentMethods;
            set 
            {
                Set(ref _paymentMethods, value, nameof(PaymentMethods));
            } 
        }
        public decimal PaymentAmount 
        { 
            get => _paymentAmount; 
            set => Set(ref _paymentAmount, value, nameof(PaymentAmount));
        }
        #endregion
        public AdministratorViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                Clients = new List<Client>(ClientService.GetAllClients());
                SanatoriumPrograms= new List<SanatoriumProgram>(SanatoriumProgramService.GetAllSanatoriumPrograms());
                SanatoriumRooms= new List<SanatoriumRoom>(SanatoriumRoomService.GetAllSanatoriumRoomsNotBusyStatus());
                PaymentMethods = new List<PaymentMethod>(PaymentMethodService.GetAllPaymentMethods());
                DateOfCheckIn=DateTime.Now;
                DateOfCheckOut=DateTime.Now;
                SelectedPaymentMethod = PaymentMethods[0];
            }
        }        
    }
}
