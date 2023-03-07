using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models.Entities
{
    internal class CostPerDay
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int SanatoriumProgramId { get; set; }
        public SanatoriumProgram SanatoriumProgram { get; set; } = null!;
        public int SanatoriumRoomId { get; set; }
        public SanatoriumRoom SanatoriumRoom { get; set;} = null!;

        public ICollection<Treaty> Treaties { get; set; } = null!;
    }
}
