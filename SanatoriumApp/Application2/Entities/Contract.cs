using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Entities
{
    class Contract
    {
        public int Id { get; set; }

        public DateTime DateOfConclusion { get; set; }
        public DateTime DateOfCheckIn { get; set; }
        public DateTime DateOfCheckOut { get; set; }
        public decimal PaymentAmount { get; set; }

        public int PaymentMethodId { get; set; }
        public int ClientId { get; set; }
        public int SanatoriumProgramId { get; set; }
        public int SanatoriumRoomId { get; set; }

        public PaymentMethod PaymentMethod { get; set; } = null!;
        public Client Client { get; set; } = null!;
        public SanatoriumProgram SanatoriumProgram { get; set;} = null!;
        public SanatoriumRoom SanatoriumRoom { get; set;} = null!;
    }
}
