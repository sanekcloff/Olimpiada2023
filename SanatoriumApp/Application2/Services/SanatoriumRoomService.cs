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
    public class SanatoriumRoomService
    {
        private ApplicationDbContext _ctx;

        public SanatoriumRoomService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<SanatoriumRoom> GetSanatoriumRooms()
        {
            return _ctx.SanatoriumRooms
                .Include(sr => sr.SanatoriumRoomCategory)
                .ToList();
        }
        public void Update(SanatoriumRoom room, bool isBusy)
        {
            room.Status = isBusy;
            _ctx.SanatoriumRooms.Update(room);
            _ctx.SaveChanges();
        }
    }
}
