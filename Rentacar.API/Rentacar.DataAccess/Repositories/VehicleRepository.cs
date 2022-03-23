using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Enums;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
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
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;

        public VehicleRepository(RentacarContext context, IMapper mapper, IBookingRepository bookingRepostiory)
        {
            _context = context;
            _mapper = mapper;

            _bookingRepository = bookingRepostiory;
        }
        public async Task<ICollection<Vehicle>> FilterVehicles(int? transmissionType, DateTime? bookingStartDate, DateTime? bookingEndDate, int? vehicleType)
        {
            var query = _context.Vehicles
                                .Include(x => x.Model)
                                .ThenInclude(x => x.VehicleType)
                                .Include(x => x.Model)
                                .ThenInclude(y => y.Make)
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
                var activeBookings = await _bookingRepository.GetLatestActiveBookings();
                query = query.Where(x => !activeBookings.Select(y => y.VehicleId).Contains(x.VehicleId));
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
            List<Vehicle> vehicles = await _context.Vehicles.Include(x => x.Model).ToListAsync();
            return vehicles;
        }

        public async Task<ICollection<Vehicle>> GetVehicles(List<Model> models)
        {
            var topModels = models.Take(3);
            List<Vehicle> vehicles = await _context.Vehicles
                                                   .Include(x => x.Model)
                                                   .ThenInclude(x => x.VehicleType)
                                                   .Include(x => x.Model)
                                                   .ThenInclude(y => y.Make)
                                                   .Where(vehicle => topModels.Select(model => model.ModelId)
                                                                              .Contains(vehicle.ModelId))
                                                   .ToListAsync();
            return vehicles;
        }

        public async Task<ICollection<VehicleBaseDto>> FilterVehicles(VehicleRequestDto request)
        {
            var query = _context.Vehicles
                                .Include(x => x.Bookings)
                                .Include(x => x.Model)
                                .ThenInclude(y => y.Make)
                                .Include(x => x.Model.VehicleType)
                                .AsQueryable();

            if (request.VehicleId > 0)
            {
                query = query.Where(x => x.VehicleId == request.VehicleId);
            }

            if (!string.IsNullOrEmpty(request.Make))
            {
                query = query.Where(x => x.Model.Make.MakeName == request.Make);
            }

            if (!string.IsNullOrEmpty(request.Model))
            {
                query = query.Where(x => x.Model.ModelName == request.Model);
            }

            if (request.MaxPrice > 0)
            {
                query = query.Where(x => x.RatePerDay <= request.MaxPrice);
            }

            if (request.MinPrice > 0)
            {
                query = query.Where(x => x.RatePerDay >= request.MinPrice);
            }

            if (request.Transmission > 0)
            {
                query = query.Where(x => x.TransmissionType == request.Transmission);
            }

            if (request.NumberOfSeats > 0)
            {
                query = query.Where(x => x.Model.NoOfSeats == request.NumberOfSeats);
            }

            if (!string.IsNullOrEmpty(request.VehicleType))
            {
                query = query.Where(x => x.Model.VehicleType.VehicleTypeName == request.VehicleType);
            }

            var queryResponse = new List<VehicleBaseDto>();
            await query.ForEachAsync(x => queryResponse.Add(new VehicleBaseDto()
            {
                VehicleId = x.VehicleId,
                IsActive = x.IsActive,
                Make = x.Model.Make.MakeName,
                Model = x.Model.ModelName,
                NumberOfSeats = x.Model.NoOfSeats,
                RatePerDay = x.RatePerDay,
                TransmissionType = (TransmissionTypeEnum)x.TransmissionType,
                VehicleType = x.Model.VehicleType.VehicleTypeName,
                ImageUrl = x.ImageUrl
            })).ConfigureAwait(false);
            return queryResponse;
        }

        public async Task<Vehicle> AddVehicle(NewVehicleRequest vehicle)
        {
            var model = _context.Models.Where(x => x.ModelId == vehicle.Model.ModelId).FirstOrDefault();
            var newVehicle = new Vehicle()
            {
                IsActive = true,
                Model = model,
                RatePerDay = (decimal)vehicle.PricePerDay,
                TransmissionType = (short)vehicle.Transmission,
                LocationId = 1
            };

            // Validate user
            AssertionHelper.AssertObject(newVehicle);

            // Add user do database
            Vehicle addedVehicle = _context.Vehicles.Add(newVehicle).Entity;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            // Return added user
            return addedVehicle;
        }

        public async Task<Vehicle> UpdateVehicle(int vehicleId, NewVehicleRequest vehicle)
        {
            var existingVehicle = _context.Vehicles.Where(x => x.VehicleId == vehicleId)
                .Include(x => x.Model)
                .ThenInclude(x => x.Make)
                .FirstOrDefault();

            if (existingVehicle == null)
            {
                return null;
            }

            if (vehicle.Model != null)
            {
                var model = _context.Models.Where(x => x.ModelId == vehicle.Model.ModelId).FirstOrDefault();
                existingVehicle.Model = model;
            }

            if (vehicle.PricePerDay != null && vehicle.PricePerDay != 0)
            {
                existingVehicle.RatePerDay = (decimal)vehicle.PricePerDay;
            }

            if (vehicle.Transmission != null && vehicle.Transmission != 0)
            {
                existingVehicle.TransmissionType = (short)vehicle.Transmission;
            }

            var updatedVehicle = _context.Update<Vehicle>(existingVehicle);
            await _context.SaveChangesAsync();

            return updatedVehicle.Entity;
        }

        public async Task<Vehicle> GetVehicleByUserId(int userId)
        {
            Booking lastBooking = await _context.Bookings
                                 .Include(x => x.Vehicle)
                                 .ThenInclude(x => x.Model)
                                 .OrderByDescending(x => x.EndDate)
                                 .FirstOrDefaultAsync(x => x.UserId == userId);
            return lastBooking?.Vehicle ?? await _context.Vehicles.FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteVehicle(int vehicleId)
        {
            var vehicle = _context.Vehicles.Where(x => x.VehicleId == vehicleId).FirstOrDefault();

            if (vehicle == null)
            {
                return false;
            }

            _context.Remove<Vehicle>(vehicle);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<VehiclesReportResponseDto>> VehiclesReport()
        {
            var vehicles = _context.Vehicles
                                    .Include(x => x.Model)
                                    .ThenInclude(x => x.VehicleType)
                                    .Include(x => x.Model)
                                    .ThenInclude(y => y.Make)
                                    .ToList();
            var bookings = _context.Bookings.ToList();

            var response = new List<VehiclesReportResponseDto>();

            foreach (var vehicle in vehicles)
            {
                var bookingsForVehicle = bookings.Where(x => x.VehicleId == vehicle.VehicleId).ToList();
                var vehicleReport = new VehiclesReportResponseDto()
                {
                    VehicleBase = _mapper.Map<VehicleBaseDto>(vehicle),
                    BookingsForVehicle = _mapper.Map<List<BaseBookingDto>>(bookingsForVehicle)
                };
                response.Add(vehicleReport);
            }

            return response;
        }

        public async Task<List<Review>> GetReviewsForUser(int userId)
        {
            return await _context.Reviews
                .Where(x => x.UserId == userId)
                .Include(x => x.Model)
                .ThenInclude(x => x.Vehicles)
                .OrderByDescending(x => x.Score)
                .ToListAsync();
        }

        public async Task<List<Review>> GetOtherModels(List<Model> models)
        {
            return await _context.Reviews.Where(x => !models.Select(y => y.ModelId).Contains(x.ModelId))
                .Include(x => x.Model)
                .ToListAsync();
        }

        public async Task<List<Model>> GetOtherModelsReviews(List<Model> models, int userId)
        {
            return await _context.Models
                .Include(x => x.Reviews)
                .Where(x => !x.Reviews.Select(y => y.UserId).Contains(userId) && !models.Select(y => y.ModelId).Contains(x.ModelId) && x.Reviews.Count > 0)
                .ToListAsync();
        }

        public async Task<List<Vehicle>> GetVehiclesByModelsId(List<int> modelIds)
        {
            return await _context.Vehicles
                .Where(x => modelIds.Contains(x.ModelId))
                .Include(x => x.Model)
                .ThenInclude(x => x.Make)
                .Include(x => x.Model)
                .ThenInclude(x => x.VehicleType)
                .ToListAsync();
        }

        public async Task<ICollection<Vehicle>> FilterVehiclesForBooking(BookVehiclesRequest bookVehiclesRequest)
        {
            var query = _context.Vehicles
                                .Include(x => x.Model)
                                .ThenInclude(x => x.VehicleType)
                                .Include(x => x.Model)
                                .ThenInclude(y => y.Make)
                                .Include(x => x.Bookings)
                                .AsQueryable();

            if (bookVehiclesRequest.TransmissionType.HasValue)
            {
                query = query.Where(x => x.TransmissionType == bookVehiclesRequest.TransmissionType.Value);
            }

            if (bookVehiclesRequest.VehicleTypes != null && bookVehiclesRequest.VehicleTypes.Any())
            {
                query = query.Where(x => bookVehiclesRequest.VehicleTypes.Contains(x.Model.VehicleType.VehicleTypeName));
            }

            if (bookVehiclesRequest.MinPrice != null)
            {
                query = query.Where(x => x.RatePerDay > bookVehiclesRequest.MinPrice);
            }

            if (bookVehiclesRequest.MaxPrice != null)
            {
                query = query.Where(x => x.RatePerDay < bookVehiclesRequest.MaxPrice);
            }

            query = query.Where(x => !x.Bookings.Any(y => (y.StartDate >= bookVehiclesRequest.StartDate && y.StartDate <= bookVehiclesRequest.EndDate) // start date overlaps
                                                          || (y.EndDate >= bookVehiclesRequest.StartDate && y.EndDate <= bookVehiclesRequest.EndDate) // end date overlaps
                                                          || (y.StartDate >= bookVehiclesRequest.StartDate && y.EndDate <= bookVehiclesRequest.EndDate) // whole booking inside span
                                                          || (y.StartDate <= bookVehiclesRequest.StartDate && y.EndDate >= bookVehiclesRequest.EndDate))); // whole span inside booking
            
            return await query.ToListAsync();
        }
    }

}
