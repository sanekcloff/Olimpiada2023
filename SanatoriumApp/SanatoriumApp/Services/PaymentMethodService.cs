using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Services
{
    internal static class PaymentMethodService
    {
        public static List<PaymentMethod> GetAllPaymentMethods()
        {
            using (var context = new ApplicationDbContext()) { return context.PaymentMethods.ToList(); }
        }
    }
}
