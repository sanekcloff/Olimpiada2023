using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Entities
{
    public class Client
    {

        public Client()
        {
            Contracts = new HashSet<Contract>();
        }

        public Client(string lastName, string firstName, string middleName, DateTime dateOfBirth, char gender, string passportNumber, string passportSeries)
        {
            Contracts = new HashSet<Contract>();
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PassportNumber = passportNumber;
            PassportSeries = passportSeries;
        }

        public int Id { get; set; }

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string PassportNumber { get; set; }=null!;
        public string PassportSeries { get; set; } = null!;

        public ICollection<Contract> Contracts { get; set; } 

        [NotMapped]
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }
        public int ContractCount { get => Contracts.Count; }
    }
}
