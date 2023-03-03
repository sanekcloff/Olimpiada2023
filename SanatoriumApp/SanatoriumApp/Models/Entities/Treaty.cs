using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models.Entities
{
    internal class Treaty
    {
        public Treaty(int id, DateTime dateOfConclusion, DateTime dateOfCheckIn, DateTime dateOfCheckOut, decimal paymentAmount, decimal paymentMethod, int clientId, Client client, int costPerDayId, CostPerDay costPerDay)
        {
            Id = id;
            DateOfConclusion = dateOfConclusion;
            DateOfCheckIn = dateOfCheckIn;
            DateOfCheckOut = dateOfCheckOut;
            PaymentAmount = paymentAmount;
            PaymentMethod = paymentMethod;
            ClientId = clientId;
            Client = client;
            CostPerDayId = costPerDayId;
            CostPerDay = costPerDay;
        }
        public Treaty()
        {

        }
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
