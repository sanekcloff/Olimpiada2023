using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models.Entities
{
    internal class CostPerDay
    {
        public CostPerDay(int id, decimal cost, int sanatoriumProgramId, SanatoriumProgram sanatoriumProgram, int sanatoriumRoomId, SanatoriumRoom sanatoriumRoom)
        {
            Id = id;
            Cost = cost;
            SanatoriumProgramId = sanatoriumProgramId;
            SanatoriumProgram = sanatoriumProgram;
            SanatoriumRoomId = sanatoriumRoomId;
            SanatoriumRoom = sanatoriumRoom;
        }
        public CostPerDay()
        {

        }
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int SanatoriumProgramId { get; set; }
        public SanatoriumProgram SanatoriumProgram { get; set; } = null!;
        public int SanatoriumRoomId { get; set; }
        public SanatoriumRoom SanatoriumRoom { get; set;} = null!;

    }
}
