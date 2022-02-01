﻿using Microsoft.AspNetCore.Mvc;
using Rentacar.Dto;
using Rentacar.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentacar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBookingsByUser([FromRoute] int userId)
        {
            ICollection<BookingDto> result = await _bookingService.GetBookingsByUser(userId);
            return Ok(result);
        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> CancelBooking([FromRoute] int bookingId)
        {
            bool result = await _bookingService.CancelBooking(bookingId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> BookVehicle([FromBody] BookingDto bookingRequest)
        {
            BookingDto result = await _bookingService.CreateBooking(bookingRequest);
            return Ok(result);
        }
    }
}
