using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Entities
{
    public class Contract
    {

        public Contract()
        {
                
        }

        public Contract(DateTime dateOfConclusion, DateTime dateOfCheckIn, DateTime dateOfCheckOut, decimal paymentAmount, PaymentMethod paymentMethod, Client client, SanatoriumProgram sanatoriumProgram, SanatoriumRoom sanatoriumRoom)
        {
            DateOfConclusion = dateOfConclusion;
            DateOfCheckIn = dateOfCheckIn;
            DateOfCheckOut = dateOfCheckOut;
            PaymentAmount = paymentAmount;
            PaymentMethod = paymentMethod;
            Client = client;
            SanatoriumProgram = sanatoriumProgram;
            SanatoriumRoom = sanatoriumRoom;
        }

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
