using Rentacar.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Interfaces
{
    public interface IFilterRepository
    {
        public Task<List<Make>> GetMakesForFilter();
        public Task<List<VehicleType>> GetVehicleTypesForFilter();
        public Task<List<Model>> GetModelsForFilter();
        public Task<List<Model>> GetModelsForMake(int makeId);
    }
}
