using Application2.Data;
using Application2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Services
{
    class SanatoriumRoomService
    {
        private ApplicationDbContext _ctx;

        public SanatoriumRoomService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public ICollection<SanatoriumRoom> GetSanatoriumRooms()
        {
            return _ctx.SanatoriumRooms.Include(sr => sr.SanatoriumRoomCategory).ToList();
        }
        public ICollection<SanatoriumRoom> GetSanatoriumRoomsWithStatus()
        {
            return _ctx.SanatoriumRooms.Include(sr => sr.SanatoriumRoomCategory).Where(sr => sr.Status == false).ToList();
        }
    }
}
