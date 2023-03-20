using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Entities
{
    public class PaymentMethod
    {
        public PaymentMethod()
        {
            Contracts =  new HashSet<Contract>();
        }

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<Contract> Contracts { get; set; } = null!;
    }
}
