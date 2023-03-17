﻿using Application2.Entities;
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
            "М","М"
        };
        #endregion

        #region Check In properties & fields
        private List<Client> _clients=null!;
        private List<SanatoriumRoom> _sanatoriumRooms=null!;
        private List<SanatoriumProgram> _sanatoriumPrograms = null!;

        private DateTime _dateOfCheckIn;
        private DateTime _dateOfCheckOut;

        private Client _selectedClient;
        private SanatoriumRoom _selectedSanatoriumRoom;
        private SanatoriumProgram _selectedSanatoriumProgram;

        public List<Client> Clients { get => _clients; set => Set(ref _clients, value, nameof(Clients)); }
        public List<SanatoriumRoom> SanatoriumRooms { get => _sanatoriumRooms; set => Set(ref _sanatoriumRooms, value, nameof(SanatoriumRooms)); }
        public List<SanatoriumProgram> SanatoriumPrograms { get => _sanatoriumPrograms; set => Set(ref _sanatoriumPrograms, value, nameof(SanatoriumPrograms)); }

        public DateTime DateOfCheckIn { get => _dateOfCheckIn;set => Set(ref _dateOfCheckIn,value, nameof(DateOfCheckIn)); }
        public DateTime DateOfCheckOut {  get => _dateOfCheckOut; set => Set(ref _dateOfCheckOut, value, nameof(DateOfCheckOut)); }

        public Client SelectedClient {  get => _selectedClient;  set => Set(ref _selectedClient, value, nameof(SelectedClient)); }
        public SanatoriumRoom SelectedSanatoriumRoom { get => _selectedSanatoriumRoom; set => Set(ref _selectedSanatoriumRoom, value, nameof(SelectedSanatoriumRoom)); }
        public SanatoriumProgram SelectedSanatoriumProgram { get => _selectedSanatoriumProgram; set => Set(ref _selectedSanatoriumProgram, value, nameof(SelectedSanatoriumProgram)); }
        #endregion

        #region Contract properties & fields
        private string _searchClient = null!;
        private string _selectedSort = null!;
        private PaymentMethod _selectedPaymentMethod = null!;

        public string SearchClient 
        { 
            get => _searchClient;
            set 
            {
                Set(ref _searchClient, value, nameof(SearchClient));
                Clients = ClientService.SearchClient(value).ToList();
            } 
        }
        public string SelectedSort 
        { 
            get => _selectedSort; 
            set
            {
                Set(ref _selectedSort, value, nameof(SelectedSort));
            }
        }
        public PaymentMethod SelectedPaymentMethod 
        { 
            get => _selectedPaymentMethod; 
            set => Set(ref _selectedPaymentMethod, value, nameof(SelectedPaymentMethod)); 
        }
        public List<PaymentMethod> PaymentMethods { get; }

        // ПОД ВОПРОСОМ
        //public List<string> SortValues { get; } = new List<string>()
        //{
        //    "По категории(возр.)",
        //    "По категории(убыв.)",
        //    "По цене за сутки(возр.)",
        //    "По цене за сутки(убыв.)",
        //    "По кол-ву мест(возр.)",
        //    "По кол-ву мест(убыв.)",
        //    "По статусу(возр.)",
        //    "По статусу(убыв.)",
        //}; 
        #endregion

        public MainViewModel()
        {
            DateOfCheckIn=DateTime.Now;
            DateOfCheckOut=DateTime.Now.AddDays(1);

            Clients= new List<Client>(ClientService.GetClients());
            SanatoriumRooms = new List<SanatoriumRoom>(SanatoriumRoomService.GetSanatoriumRoomsWithStatus());
            SanatoriumPrograms = new List<SanatoriumProgram>(SanatoriumProgramService.GetSanatoriumPrograms());

            SelectedGender = Genders[0];
            PaymentMethods= new List<PaymentMethod>(PaymentMethodService.GetPaymentMethods());
            SelectedPaymentMethod = PaymentMethods[0];
        }

        internal void ResetValues()
        {
            SelectedGender = Genders[0];
            FirstName = string.Empty;
            LastName = string.Empty;
            MiddleName= string.Empty;
            DateOfBirth= DateTime.Now;
            PassportNumber= string.Empty;
            PassportSeries=string.Empty;
        }
    }
}
