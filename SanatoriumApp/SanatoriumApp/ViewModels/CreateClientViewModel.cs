using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.ViewModels
{
    internal class CreateClientViewModel : ViewModelBase
    {
        private string _lastName = null!;
        private string _firstName = null!;
        private string _middleName = null!;
        private DateTime _dateOfBirth = DateTime.Now;
        private string _gender = null!;
        private string _passportSeries = null!;
        private string _passportNumber = null!;
        
        public string LastName 
        { 
            get => _lastName; 
            set => Set(ref _lastName, value, nameof(LastName)); 
        }
        public string FirstName 
        { 
            get => _firstName; 
            set => Set(ref _firstName, value, nameof(FirstName));
        }
        public string MiddleName 
        { 
            get => _middleName; 
            set => Set(ref _middleName, value, nameof(MiddleName)); 
        }
        public DateTime DateOfBirth 
        { 
            get => _dateOfBirth; 
            set => Set(ref _dateOfBirth, value, nameof(DateOfBirth)); 
        }
        public string Gender
        {
            get => _gender;
            set => Set(ref _gender, value, nameof(Gender));
        }
        public string PassportSeries 
        { 
            get => _passportSeries; 
            set => Set(ref _passportSeries, value, nameof(PassportSeries)); 
        }
        public string PassportNumber 
        { 
            get => _passportNumber; 
            set => Set(ref _passportNumber, value, nameof(PassportNumber)); 
        }

        public CreateClientViewModel()
        {

        }
    }
}
