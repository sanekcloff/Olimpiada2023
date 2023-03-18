using Application2.Data;
using Application2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Services
{
    public class SanatoriumProgramService
    {
        private ApplicationDbContext _ctx;

        public SanatoriumProgramService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<SanatoriumProgram> GetSanatoriumPrograms()
        {
            return _ctx.SanatoriumPrograms.ToList();
        }
    }
}
