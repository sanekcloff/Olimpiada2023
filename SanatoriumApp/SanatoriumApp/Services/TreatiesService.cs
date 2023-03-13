using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SanatoriumApp.Services
{
    internal static class TreatiesService
    {
        public static bool CheckMinDays(SanatoriumProgram sanatoriumProgram, DateTime checkIn, DateTime checkOut)
        {
            if((checkOut.Day-checkIn.Day)>=sanatoriumProgram.MinDays) return true;
            return false;
        }
        public static DateTime CalculateMinDayOfCheckOut(DateTime checkIn, SanatoriumProgram sanatoriumProgram)
        {
            return checkIn.AddDays(sanatoriumProgram.MinDays);
        }
        public static decimal CalculatePaymentAmount(decimal cost, PaymentMethod paymentMethod)
        {
            if (paymentMethod.Id == 1) return cost - (cost * 0.05M);
            else return cost;
        }

        public static void AddTreaty(Treaty treaty)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Treaties.Add(treaty);
                context.SaveChanges();
                MessageBox.Show("Договор оформлен!");
            }
        }
    }
}
