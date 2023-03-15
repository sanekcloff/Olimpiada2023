using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Entities
{
    internal class UserProfile
    {
        public int Id { get; set; }

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }=null!;

    }
}
