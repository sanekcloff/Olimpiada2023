using Application2.Data;
using Application2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Services
{
    static class SanatoriumProgramService
    {
        public static ICollection<SanatoriumProgram> GetSanatoriumPrograms()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.SanatoriumPrograms.ToList();
            }
        }
    }
}
