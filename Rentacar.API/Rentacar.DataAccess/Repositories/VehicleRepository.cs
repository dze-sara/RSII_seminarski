using Microsoft.EntityFrameworkCore;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.DataAccess.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly RentacarContext _context;
        public VehicleRepository(RentacarContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Vehicle>> FilterVehicles(int? transmissionType, DateTime? bookingStartDate, DateTime? bookingEndDate, int? vehicleType)
        {
            var query = _context.Vehicles
                                .Include(x => x.Bookings)
                                .AsQueryable();

            if (transmissionType.HasValue)
            {
                query.Where(x => x.TransmissionType == transmissionType.Value);
            }

            if (vehicleType.HasValue)
            {
                query.Where(x => x.Model.VehicleTypeId == vehicleType.Value);
            }

            if (bookingStartDate.HasValue && bookingEndDate.HasValue)
            {
                query.Where(x => !x.Bookings.Any(booking => DateSpansOverlap(booking.StartDate, booking.EndDate, bookingStartDate.Value, bookingEndDate.Value)));
            }

            return await query.ToListAsync();
        }

        private bool DateSpansOverlap(DateTime bookingStartDate, DateTime bookingEndDate, DateTime filterStartDate, DateTime filterEndDate)
        {
            // There are two situations where bookings don't overlap: when the filter span is completely before or completely after the booking
            // There are four situations where the bookings do overlap: 
            // 1. Filter cuts into begining of the booking, 
            // 2. end of the booking, 
            // 3. filter is inside the booking span, 
            // 4. filter encompasss the whole booking span
            // Since these two cases are complementary, it is easier to check if they don't overlap, and just negate the condition
            return !(filterStartDate < bookingEndDate || filterEndDate < bookingStartDate);
        }

        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            AssertionHelper.AssertInt(vehicleId);

            return await _context.Vehicles
                                 .Include(x => x.Model)
                                 .ThenInclude(x => x.VehicleType)
                                 .FirstOrDefaultAsync(x => x.VehicleId == vehicleId);
        }

        public async Task<ICollection<Vehicle>> GetVehicles()
        {
            List<Vehicle> vehicles = await _context.Vehicles.ToListAsync();
            return vehicles;
        }
    }
}
