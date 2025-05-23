﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD392.DTOs;
using SWD392.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SWD392.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _bookingRepository.GetAllDoctorsAsync();
            return Ok(doctors);
        }


        [HttpGet("GetAvailableBookings/{doctorId}")]
        public async Task<IActionResult> GetAvailableBookings(string doctorId)
        {
            var slots = await _bookingRepository.GetAvailableBookingsAsync(doctorId);
            return Ok(slots);
        }

      
        [HttpPost("RequestAppointment")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> RequestAppointment([FromBody] BookingRequestDTO request)
        {
            var customerUsername = User.Identity.Name;
            if (string.IsNullOrEmpty(customerUsername))
            {
                return Unauthorized(new { Message = "Không xác định được tài khoản khách hàng!" });
            }

            bool success = await _bookingRepository.RequestAppointmentAsync(request, customerUsername);

            if (!success)
            {
                return BadRequest(new { Message = "Lịch này đã được đặt hoặc không tồn tại!" });
            }

            return Ok(new { Message = "Đặt lịch thành công! Chờ xác nhận từ Staff.", BookingId = request.BookingId });
        }

      
        [HttpGet("GetCustomerAppointments")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetCustomerAppointments()
        {
            var customerUsername = User.Identity.Name;
            if (string.IsNullOrEmpty(customerUsername))
            {
                return Unauthorized("Không xác định được tài khoản khách hàng.");
            }

            var appointments = await _bookingRepository.GetCustomerAppointmentsAsync(customerUsername);
            return Ok(appointments);
        }


        [HttpPut("CancelAppointment/{bookingId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CustomerCancelAppointment(int bookingId)
        {
            try
            {
                var success = await _bookingRepository.CustomerCancelAppointmentAsync(bookingId);
                if (!success)
                {
                    return BadRequest(new { Message = "Không thể hủy lịch hẹn. Có thể lịch này đã bị hủy hoặc không tồn tại." });
                }
                return Ok(new { Message = "Lịch hẹn đã được hủy và bạn có thể đặt lại!" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpGet("GetResultBooking/{bookingId}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetResultBooking(int bookingId)
        {
            var customerId = User.Identity.Name;
            if (string.IsNullOrEmpty(customerId))
            {
                return Unauthorized(new { Message = "Không xác định được tài khoản khách hàng!" });
            }

            var result = await _bookingRepository.GetResultBookingAsync(bookingId, customerId);

            if (result == null)
            {
                return NotFound(new { Message = "Không tìm thấy kết quả cho lịch hẹn này!" });
            }

            return Ok(result);
        }





    }
}
