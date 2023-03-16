using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Entities
{
    class SanatoriumRoomCategory
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public decimal Coefficient { get; set; }

        public ICollection<SanatoriumRoom> SanatoriumRooms { get; set; } = null!;
    }
}
