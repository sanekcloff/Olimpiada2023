using Application2.Data;
using Application2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Services
{
    public class ContractService
    {
        private ApplicationDbContext _ctx;

        public ContractService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICollection<Contract> GetContracts()
        {
            return _ctx.Contracts
                .Include(c => c.Client)
                .Include(sr => sr.SanatoriumRoom)
                    .ThenInclude(src => src.SanatoriumRoomCategory)
                .Include(sp => sp.SanatoriumProgram)
                .Include(pm=>pm.PaymentMethod)
                .ToList();
        }
        public bool Insert(Contract contract)
        {
            if (contract.Client != null
                || contract.SanatoriumProgram!=null
                || contract.SanatoriumRoom!=null)
            {
                _ctx.Contracts.Add(contract);
                _ctx.SaveChanges();
                new SanatoriumRoomService(_ctx).Update(contract.SanatoriumRoom, true);
                return true;
            }   
            else
                return false;
        }
    }
}
