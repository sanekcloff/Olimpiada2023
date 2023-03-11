using SanatoriumApp.Models;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Services
{
    internal static class SanatoriumProgramService
    {
        internal static List<SanatoriumProgram> GetAllSanatoriumPrograms()
        {
            using(var context = new ApplicationDbContext()) { return context.SanatoriumPrograms.ToList(); }
        }
    }
}
