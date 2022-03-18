﻿using Microsoft.EntityFrameworkCore;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
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
        public VehicleRepository(RentacarContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Vehicle>> FilterVehicles(int? transmissionType, DateTime? bookingStartDate, DateTime? bookingEndDate, int? vehicleType)
        {
            var query = _context.Vehicles
                                .Include(x => x.Model)
                                .ThenInclude(x => x.VehicleType)
                                .Include(x =>x.Model)
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

            if(request.MaxPrice > 0)
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
                VehicleType = x.Model.VehicleType.VehicleTypeName
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

            if(existingVehicle == null)
            {
                return null;
            }

            if(vehicle.Model != null)
            {
                var model = _context.Models.Where(x => x.ModelId == vehicle.Model.ModelId).FirstOrDefault();
                existingVehicle.Model = model;
            }

            if (vehicle.PricePerDay != null && vehicle.PricePerDay != 0)
            {
                existingVehicle.RatePerDay = (decimal)vehicle.PricePerDay;
            }

            if(vehicle.Transmission != null && vehicle.Transmission != 0)
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

            if(vehicle == null)
            {
                return false;
            }

            _context.Remove<Vehicle>(vehicle);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
