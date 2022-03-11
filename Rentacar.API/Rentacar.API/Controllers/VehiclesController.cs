using Microsoft.AspNetCore.Mvc;
using Rentacar.Dto;
using Rentacar.Dto.Enums;
using Rentacar.Dto.Request;
using Rentacar.Dto.Response;
using Rentacar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ICollection<VehicleDto> vehicles = await _vehicleService.GetVehicles();
            return Ok(vehicles);
        }

        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetVehicleDetails(int vehicleId)
        {
            VehicleDto vehicleDetails = await _vehicleService.GetVehicleById(vehicleId);
            return Ok(vehicleDetails);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterVehicles([FromQuery] TransmissionTypeEnum? transmissionType, [FromQuery] DateTime? bookingStart, [FromQuery] DateTime? bookingEnd, [FromQuery] int? vehicleType)
        {
            if(bookingStart.HasValue && bookingEnd.HasValue && bookingStart >= bookingEnd)
            {
                return BadRequest();
            }

            ICollection<VehicleDto> vehicles =  await _vehicleService.FilterVehicles(transmissionType, bookingStart, bookingEnd, vehicleType);
            return Ok(vehicles);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> FilterVehiclesPost([FromBody] VehicleRequestDto request)
        {
            ICollection<VehicleBaseDto> vehicles = await _vehicleService.FilterVehicles(request);
            return Ok(vehicles);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddVehicle([FromBody] NewVehicleRequest request)
        {
            VehicleBaseDto vehicle = await _vehicleService.AddVehicle(request);
            var x = Ok(vehicle);
            return x;
        }
    }
}
