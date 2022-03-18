using Microsoft.EntityFrameworkCore;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Repositories
{
    public class FilterRepository : IFilterRepository
    {
        private readonly RentacarContext _context;

        public FilterRepository(RentacarContext context)
        {
            _context = context;
        }

        public async Task<Make> GetMake(string makeName)
        {
            return await _context.Makes.Where(x => x.MakeName == makeName).FirstOrDefaultAsync();
        }

        public async Task<List<Make>> GetMakesForFilter()
        {
            return await _context.Makes.ToListAsync();
        }

        public async Task<List<Model>> GetModelsForFilter()
        {
            return await _context.Models.ToListAsync();
        }

        public async Task<List<Model>> GetModelsForMake(int makeId)
        {
            return await _context.Models.Where(x => x.MakeId == makeId).ToListAsync();
        }

        public async Task<List<VehicleType>> GetVehicleTypesForFilter()
        {
            return await _context.VehicleTypes.ToListAsync();
        }
    }
}
