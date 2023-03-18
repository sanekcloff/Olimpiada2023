using Application2.Data;
using Application2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Services
{
    public class PaymentMethodService
    {
        private ApplicationDbContext _ctx;

        public PaymentMethodService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<PaymentMethod> GetPaymentMethods()
        {
            return _ctx.PaymentMethods.ToList();
        }
    }
}
