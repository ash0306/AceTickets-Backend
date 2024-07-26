﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBookingBackend.Interfaces;
using MovieBookingBackend.Models;
using MovieBookingBackend.Models.DTOs.Bookings;

namespace MovieBookingBackend.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookingDTO>> AddBooking(AddBookingDTO addBookingDTO)
        {
            try
            {
                var result = await _bookingService.AddBooking(addBookingDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BookingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBookings()
        {
            try
            {
                var result = await _bookingService.GetAllBookings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [HttpGet("user/{id}")]
        [ProducesResponseType(typeof(BookingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetBookingsByUserId(int id)
        {
            try
            {
                var result = await _bookingService.GetAllBookingsByUserId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBookingsById(int id)
        {
            try
            {
                var result = await _bookingService.GetBookingById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [HttpPut("status")]
        [ProducesResponseType(typeof(BookingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookingDTO>> UpdateBookingStatus(BookingStatusDTO bookingStatusDTO)
        {
            try
            {
                var result = await _bookingService.UpdateBookingStatus(bookingStatusDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }
    }
}
