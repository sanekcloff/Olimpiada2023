using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Entities
{
    public class SanatoriumProgram
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public int QuantityOfProcedures { get; set; }
        public int MinQuantityDays { get; set; }
        public string Description { get; set; } = null!;
        public decimal Cost { get; set; }

        public ICollection<Contract> Contracts { get; set; } = null!;
    }
}
