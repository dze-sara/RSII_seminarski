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

        public async Task<ICollection<VehicleDto>> FilterVehicles(TransmissionTypeEnum? transmissionType, DateTime? bookingStartTime, DateTime? bookingEndTime, int? vehicleType)
        {
            return _mapper.Map<List<VehicleDto>>(await _vehicleRepository.FilterVehicles((int?)transmissionType, bookingStartTime, bookingEndTime, vehicleType));
        }

        public async Task<ICollection<VehicleBaseDto>> FilterVehicles(VehicleRequestDto request)
        {
             return await _vehicleRepository.FilterVehicles(request);
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
    }
}
