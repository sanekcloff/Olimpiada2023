using Application2.Data;
using Application2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Services
{
    static class PaymentMethodService
    {
        public static ICollection<PaymentMethod> GetPaymentMethods()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.PaymentMethods.ToList();
            }
        }
    }
}
