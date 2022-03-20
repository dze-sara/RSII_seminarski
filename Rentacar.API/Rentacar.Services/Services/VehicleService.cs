using AutoMapper;
using Rentacar.Common;
using Rentacar.DataAccess.Interfaces;
using Rentacar.Dto;
using Rentacar.Dto.Enums;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using Rentacar.Entities;
using Rentacar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentacar.Services.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<VehicleBaseDto> AddVehicle(NewVehicleRequest newVehicle)
        {
            var vehicle = await _vehicleRepository.AddVehicle(newVehicle);
            var vehicleDto = new VehicleBaseDto()
            {
                IsActive = vehicle.IsActive,
                Make = vehicle.Model.Make?.MakeName,
                Model = vehicle.Model.ModelName,
                NumberOfSeats = vehicle.Model.NoOfSeats,
                RatePerDay = vehicle.RatePerDay,
                TransmissionType = (TransmissionTypeEnum)vehicle.TransmissionType,
                VehicleId = vehicle.VehicleId,
                VehicleType = vehicle.Model.VehicleType?.VehicleTypeName
            };
            return vehicleDto;
        }

        public async Task<VehicleBaseDto> UpdateVehicle(int vehicleId, NewVehicleRequest request)
        {
            var vehicle = await _vehicleRepository.UpdateVehicle(vehicleId, request);

            var vehicleDto = new VehicleBaseDto()
            {
                IsActive = vehicle.IsActive,
                Make = vehicle.Model.Make?.MakeName,
                Model = vehicle.Model.ModelName,
                NumberOfSeats = vehicle.Model.NoOfSeats,
                RatePerDay = vehicle.RatePerDay,
                TransmissionType = (TransmissionTypeEnum)vehicle.TransmissionType,
                VehicleId = vehicle.VehicleId,
                VehicleType = vehicle.Model.VehicleType?.VehicleTypeName
            };

            return vehicleDto;
        }

        public async Task<ICollection<VehicleBaseDto>> FilterVehicles(TransmissionTypeEnum? transmissionType, DateTime? bookingStartTime, DateTime? bookingEndTime, int? vehicleType)
        {
            return _mapper.Map<List<VehicleBaseDto>>(await _vehicleRepository.FilterVehicles((int?)transmissionType, bookingStartTime, bookingEndTime, vehicleType));
        }

        public async Task<ICollection<VehicleBaseDto>> FilterVehicles(VehicleRequestDto request)
        {
             return await _vehicleRepository.FilterVehicles(request);
        }

        public async Task<ICollection<VehicleBaseDto>> GetRecommendedVehicles(int userId)
        {
            // Get user's last vehicle model
            Vehicle lastVehicle = await _vehicleRepository.GetVehicleByUserId(userId);

            // Get other vehicle models
            ICollection<Vehicle> availableVehicles = await _vehicleRepository.GetVehicles();

            // Calculate vehicle with lowest hamming distance
            List<Model> recommendations = CalculateLowestDistance(lastVehicle, availableVehicles);

            // Retrieve vehicle with recommended model and return data
            var recommendedVehicles = await _vehicleRepository.GetVehicles(recommendations);

            return _mapper.Map<List<VehicleBaseDto>>(recommendedVehicles);
        }

        private List<Model> CalculateLowestDistance(Vehicle lastVehicle, ICollection<Vehicle> availableVehicles)
        {
            var recommendations = availableVehicles.OrderByDescending(x => CalculateDistance(lastVehicle, x));
            return recommendations.Select(x => x.Model).ToList();
        }

        private decimal CalculateDistance(Vehicle vehicle1, Vehicle vehicle2)
        {
            decimal distance = 0;
            distance += Math.Abs(vehicle1.Model.VehicleTypeId - vehicle2.Model.VehicleTypeId);
            distance += Math.Abs(vehicle1.Model.MakeId - vehicle2.Model.MakeId);
            distance += Math.Abs(vehicle1.Model.ModelId - vehicle2.Model.ModelId);
            distance += Math.Abs(vehicle1.RatePerDay - vehicle2.RatePerDay);
            return distance;
        }

        public async Task<VehicleDto> GetVehicleById(int vehicleId)
        {
            AssertionHelper.AssertInt(vehicleId);

            return _mapper.Map<VehicleDto>(await _vehicleRepository.GetVehicleById(vehicleId));
        }

        public async Task<ICollection<VehicleDto>> GetVehicles()
        {
            return _mapper.Map<List<VehicleDto>>(await _vehicleRepository.GetVehicles());
        }

        public async Task<bool> DeleteVehicle(int vehicleId)
        {
            return await _vehicleRepository.DeleteVehicle(vehicleId);
        }

        public async Task<List<VehiclesReportResponseDto>> VehiclesReport()
        {
            return await _vehicleRepository.VehiclesReport();
        }
    }
}
