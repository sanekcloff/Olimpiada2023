using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Services
{
    internal static class CostPerDayService
    {
        public static decimal CalculateCost(SanatoriumProgram sanatoriumProgram, SanatoriumRoom sanatoriumRoom, DateTime checkIn, DateTime checkOut)
        {
            return (checkOut.DayOfYear - checkIn.DayOfYear) * (sanatoriumProgram.Cost + sanatoriumRoom.SanatoriumRoomCategory.Cost);
        }
        public static void AddCostPerDay(ref ServiceCost costPerDay)
        {
            using (var context = new ApplicationDbContext())
            {
                context.CostsPerDays.Add(costPerDay);
                context.SaveChanges();
            }
        }
    }
}
