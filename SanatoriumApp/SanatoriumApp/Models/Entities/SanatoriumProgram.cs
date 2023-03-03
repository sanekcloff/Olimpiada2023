using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models.Entities
{
    internal class SanatoriumProgram
    {
        public SanatoriumProgram(int id, string title, int quantityOfProcedures, int minDays, string description, decimal cost)
        {
            Id = id;
            Title = title;
            QuantityOfProcedures = quantityOfProcedures;
            MinDays = minDays;
            Description = description;
            Cost = cost;
        }
        public SanatoriumProgram()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int QuantityOfProcedures { get; set; }
        public int MinDays { get; set; }
        public string Description { get; set; } = null!;
        public decimal Cost { get; set; }
    }
}
