using Microsoft.EntityFrameworkCore;
using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Services
{
    internal static class SanatoriumRoomService
    {
        internal static List<SanatoriumRoom> GetAllSanatoriumRooms()
        {
            using (var context = new ApplicationDbContext()) { return context.SanatoriumRooms.Include(src=>src.SanatoriumRoomCategory).ToList(); }
        }
        internal static List<SanatoriumRoom> GetAllSanatoriumRoomsBusyStatus()
        {
            using (var context = new ApplicationDbContext()) { return context.SanatoriumRooms.Include(src => src.SanatoriumRoomCategory).Where(sr=>sr.Status== "Не занят").ToList(); }
        }
    }
}
