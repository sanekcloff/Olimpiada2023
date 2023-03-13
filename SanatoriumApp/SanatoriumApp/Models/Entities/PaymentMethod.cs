using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models.Entities
{
    internal class PaymentMethod
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<Treaty> Treaties { get; set; } = null!;
    }
}
