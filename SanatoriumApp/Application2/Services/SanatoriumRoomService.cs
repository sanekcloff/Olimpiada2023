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
    static class SanatoriumRoomService
    {
        public static ICollection<SanatoriumRoom> GetSanatoriumRooms()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.SanatoriumRooms.Include(sr=>sr.SanatoriumRoomCategory).ToList();
            }
        }
        public static ICollection<SanatoriumRoom> GetSanatoriumRoomsWithStatus()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.SanatoriumRooms.Include(sr => sr.SanatoriumRoomCategory).Where(sr => sr.Status == false).ToList();
            }
        }
    }
}
