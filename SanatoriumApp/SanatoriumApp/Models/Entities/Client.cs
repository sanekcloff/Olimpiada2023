using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models.Entities
{
    internal class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string PassportSeries { get; set; }=null!;
        public string PassportNumber { get; set; } = null!;

        public ICollection<Treaty> Treaties { get; set; } = null!;

        [NotMapped]
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
    }
}
