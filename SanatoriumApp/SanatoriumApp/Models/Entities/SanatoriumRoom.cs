﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models.Entities
{
    internal class SanatoriumRoom
    {
        public int Id { get; set; }
        public int SanatoriumRoomCategoryId { get; set; }
        public SanatoriumRoomCategory SanatoriumRoomCategory { get; set; } = null!;
        public int RoomSize { get; set; }
        public int QuantityOfSeats { get; set; }
        public int QuantityOfRooms { get; set; }
        public string RoomAmenities { get; set; } = null!;
        public string WindowView { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;

        public ICollection<ServiceCost> CostPerDays { get; set; } = null!;
    }
}
