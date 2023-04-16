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
    public class AdminViewModel:ViewModelBase
    {
        // всё для вкладки регистрации клиента
        #region Registration Client properties & fields
        private string _lastName = null!;
        private string _firstName = null!;
        private string _middleName = null!;
        private DateTime _dateOfBirth=DateTime.Now;
        private string _passportNumber = null!;
        private string _passportSeries = null!;
        private string _selectedGender = null!;


        public string LastName { get => _lastName; set => Set(ref _lastName, value, nameof(LastName)); }
        public string FirstName { get => _firstName; set => Set(ref _firstName, value, nameof(FirstName)); }
        public string MiddleName { get => _middleName; set => Set(ref _middleName, value, nameof(MiddleName)); }
        public DateTime DateOfBirth { get => _dateOfBirth; set => Set(ref _dateOfBirth, value, nameof(DateOfBirth)); }
        public string PassportNumber { get => _passportNumber; set => Set(ref _passportNumber, value, nameof(PassportNumber)); }
        public string PassportSeries { get => _passportSeries; set => Set(ref _passportSeries, value, nameof(PassportSeries)); }
        public string SelectedGender { get => _selectedGender; set => Set(ref _selectedGender, value, nameof(SelectedGender)); }

        public List<string> Genders { get; } = new List<string>()
        {
            "М","Ж"
        };
        #endregion

        // всё для формирования контракта, договора
        #region Check In properties & fields
        private List<Client> _clients=null!;
        private List<SanatoriumRoom> _sanatoriumRooms=null!;
        private List<SanatoriumProgram> _sanatoriumPrograms = null!;

        private DateTime _dateOfCheckIn;
        private DateTime _dateOfCheckOut;

        private Client _selectedClient;
        private SanatoriumRoom _selectedSanatoriumRoom;
        private SanatoriumProgram _selectedSanatoriumProgram;

        private decimal _paymentAmount;

        public List<Client> Clients { get => _clients; set => Set(ref _clients, value, nameof(Clients)); }
        public List<SanatoriumRoom> SanatoriumRooms { get => _sanatoriumRooms; set => Set(ref _sanatoriumRooms, value, nameof(SanatoriumRooms)); }
        public List<SanatoriumProgram> SanatoriumPrograms { get => _sanatoriumPrograms; set => Set(ref _sanatoriumPrograms, value, nameof(SanatoriumPrograms)); }

        public DateTime DateOfCheckIn 
        { 
            get => _dateOfCheckIn;
            set 
            {
                Set(ref _dateOfCheckIn, value, nameof(DateOfCheckIn));
                CalculatePaymentAmount(); // вычесление цены оформляемого контракта
            } 
        }
        public DateTime DateOfCheckOut 
        {  
            get => _dateOfCheckOut;
            set 
            {
                Set(ref _dateOfCheckOut, value, nameof(DateOfCheckOut));
                CalculatePaymentAmount(); // вычесление цены оформляемого контракта
            } 
        }

        public Client SelectedClient 
        {  
            get => _selectedClient;  
            set => Set(ref _selectedClient, value, nameof(SelectedClient)); 
        }
        public SanatoriumRoom SelectedSanatoriumRoom 
        { 
            get => _selectedSanatoriumRoom;
            set 
            {
                Set(ref _selectedSanatoriumRoom, value, nameof(SelectedSanatoriumRoom));
                CalculatePaymentAmount(); // вычесление цены оформляемого контракта
            } 
        }
        public SanatoriumProgram SelectedSanatoriumProgram 
        { 
            get => _selectedSanatoriumProgram;
            set 
            {
                Set(ref _selectedSanatoriumProgram, value, nameof(SelectedSanatoriumProgram));
                CalculatePaymentAmount(); // вычесление цены оформляемого контракта
            } 
        }
        
        public decimal PaymentAmount { get => _paymentAmount; set => Set(ref _paymentAmount, value, nameof(PaymentAmount)); }
        #endregion

        // всё фильтров сортировок
        #region Contract properties & fields
        private string _searchClient = null!;
        private string _selectedFilther = null!;
        private string _selectedStatus = null!;
        private decimal _selectedCost;
        private int _selectedSeats;
        private PaymentMethod _selectedPaymentMethod = null!;

        public string SearchClient 
        { 
            get => _searchClient;
            set 
            {
                Set(ref _searchClient, value, nameof(SearchClient));
                Clients = ClientService.Search(value).ToList();
            } 
        }
        public string SelectedFilther 
        { 
            get => _selectedFilther; 
            set
            {
                Set(ref _selectedFilther, value, nameof(SelectedFilther));
                AllFilthers(); // вызов обновления списков
            }
        }
        public string SelectedStatus 
        { 
            get => _selectedStatus;
            set 
            {
                Set(ref _selectedStatus, value, nameof(SelectedStatus));
                AllFilthers(); // вызов обновления списков
            }
        }
        public decimal SelectedCost
        {
            get => _selectedCost;
            set
            {
                Set(ref _selectedCost, value, nameof(SelectedCost));
                AllFilthers(); // вызов обновления списков
            }
        }
        public int SelectedSeats 
        { 
            get => _selectedSeats;
            set 
            {
                Set(ref _selectedSeats, value, nameof(SelectedSeats));
                AllFilthers(); // вызов обновления списков
            } 
        }


        public PaymentMethod SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set
            {
                Set(ref _selectedPaymentMethod, value, nameof(SelectedPaymentMethod));
                CalculatePaymentAmount();
            }
        }


        public List<PaymentMethod> PaymentMethods { get; }

        //ВОПРОС
        public List<string> FiltherValues { get; } = new List<string>()
        {
            "Все категории",
            "Стандартный",
            "Премиум",
            "Люкс"
        };
        public List<string> StatusValues { get; } = new List<string>()
        {
            "Все статусы",
            "Занят",
            "Свободен"
        };

        #endregion

        // Переменные для хранения экзмепляров сервисов
        #region Services
        public ContractService ContractService { get; }
        public ClientService ClientService { get; }
        public SanatoriumRoomService RoomService { get; }
        public SanatoriumProgramService ProgramService { get; }
        public PaymentMethodService PaymentMethodService { get; }
        
        #endregion


        private ApplicationDbContext _context;
        public AdminViewModel()
        {
            //Создание экземпляра контекста
            _context = new ApplicationDbContext();

            //Подгрузка сервисов
            ContractService= new ContractService(_context);
            ClientService = new ClientService(_context);
            RoomService = new SanatoriumRoomService(_context);
            ProgramService= new SanatoriumProgramService(_context);
            PaymentMethodService= new PaymentMethodService(_context);

            //Заполнение листов с помощью методо
            Clients= new List<Client>(ClientService.GetClients());
            SanatoriumRooms = new List<SanatoriumRoom>(RoomService.GetSanatoriumRooms());
            SanatoriumPrograms = new List<SanatoriumProgram>(ProgramService.GetSanatoriumPrograms());
            PaymentMethods = new List<PaymentMethod>(PaymentMethodService.GetPaymentMethods());

            // Объявление начальных дат иначе, стартовые значения будут 01.01.0001
            DateOfCheckIn = DateTime.Now;
            DateOfCheckOut = DateTime.Now.AddDays(1);

            // Объявление начальных значений фильтров, списков
            SelectedGender = Genders[0];
            SelectedPaymentMethod = PaymentMethods[0];
            SelectedFilther = FiltherValues[0];
            SelectedStatus = StatusValues[2];
            PaymentAmount = 0;
        }

        public void ResetValues()
        {
            SelectedGender = Genders[0];
            FirstName = string.Empty;
            LastName = string.Empty;
            MiddleName= string.Empty;
            DateOfBirth= DateTime.Now;
            PassportNumber= string.Empty;
            PassportSeries=string.Empty;
        }
        // Обновление списков, оно происходит после изменения каких либо данных в них
        public void UpdateLists()
        {
            Clients = new List<Client>(ClientService.GetClients());
            AllFilthers();
            SanatoriumPrograms = new List<SanatoriumProgram>(ProgramService.GetSanatoriumPrograms());
        }
        //Обновление списка с учётом фильтров
        public void AllFilthers()
        {
            SanatoriumRooms = FiltherStatus(FiltherSeats(FiltherCosts(FiltherCategories(RoomService
                .GetSanatoriumRooms()
                .ToList()))))
                ;
        }

        #region Room filthers
        public List<SanatoriumRoom> FiltherCategories(List<SanatoriumRoom> sr)
        {
            if (SelectedFilther == FiltherValues[0])
                return sr;
            else
                return sr
                    .Where(sr => sr.SanatoriumRoomCategory.Title == SelectedFilther)
                    .ToList();
        }
        public List<SanatoriumRoom> FiltherCosts(List<SanatoriumRoom> sr)
        {
            if (SelectedCost <= 0)
                return sr;
            else
                return sr
                    .Where(sr => sr.FullCost <= SelectedCost)
                    .ToList();
        }
        public List<SanatoriumRoom> FiltherSeats(List<SanatoriumRoom> sr)
        {
            if (SelectedSeats <= 0)
                return sr;
            else
                return sr
                    .Where(sr => sr.QuantityOfSeats == SelectedSeats)
                    .ToList();
        }
        public List<SanatoriumRoom> FiltherStatus(List<SanatoriumRoom> sr)
        {
            if (SelectedStatus == StatusValues[2])
                return sr
                    .Where(sr=>sr.Status==false)
                    .ToList();
            else if (SelectedStatus == StatusValues[1])
                return sr
                    .Where(sr => sr.Status == true)
                    .ToList();
            else
                return sr;
        }
        #endregion

        #region CostPerDay
        public void CalculatePaymentAmount()
        {
            if (SelectedSanatoriumProgram != null && SelectedSanatoriumRoom != null)
                PaymentAmount = (DateOfCheckOut.DayOfYear - DateOfCheckIn.DayOfYear) * (SelectedSanatoriumRoom.FullCost + SelectedSanatoriumProgram.Cost);
            if (SelectedPaymentMethod!=null && SelectedPaymentMethod.Id == 3)
                PaymentAmount -= PaymentAmount * 0.05M;
        }
        #endregion
    }
}
