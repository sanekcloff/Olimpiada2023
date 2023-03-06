using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models.Entities
{
    internal class Treaty
    {
        public int Id { get; set; }
        public DateTime DateOfConclusion { get; set; }
        public DateTime DateOfCheckIn { get; set; }
        public DateTime DateOfCheckOut { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal PaymentMethod { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public int CostPerDayId { get; set; }
        public CostPerDay CostPerDay { get; set; } = null!;

    }
}
