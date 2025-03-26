﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWD392.DTOs;
using SWD392.Repositories;

namespace SWD392.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDTO dto)
        {
            var result = await _roomRepository.CreateRoomAsync(dto);
            return result ? Ok(new { Message = "Tạo phòng thành công." }) : BadRequest("Thất bại");
        }

        [HttpPost("Checkin")]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> CheckinCustomer([FromBody] CheckinCustomerDTO dto)
        {
            var (success, message) = await _roomRepository.CheckinCustomerAsync(dto);
            return success ? Ok(new { message }) : BadRequest(new { message });
        }
    }
}
