﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Entities
{
    class SanatoriumRoom
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public decimal RoomSize { get; set; }
        public int QuantityOfSeats { get; set; }
        public int QuantityOfRooms { get; set; }
        public string RoomAmenities { get; set; } = null!;
        public string RoomWindow { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
        public decimal Cost { get; set; }

        public int SanatoriumRoomCategoryId { get; set; }

        public SanatoriumRoomCategory SanatoriumRoomCategory { get; set; } = null!;

        public ICollection<Contract> Contracts { get; set; } = null!;
    }
}