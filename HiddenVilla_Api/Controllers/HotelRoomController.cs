﻿using Business.Repository.IRepository;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HiddenVilla_Api.Controllers
{
    [Route("api/[controller]")]
    public class HotelRoomController : Controller
    {
        private readonly IHotelRoomRepository _hotelRoomRepository;
        public HotelRoomController(IHotelRoomRepository hotelRoomRepository)
        {
            _hotelRoomRepository = hotelRoomRepository;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetHotelRooms()
        {
            var allRooms = await _hotelRoomRepository.GetAllHotelRooms();
            return Ok(allRooms);
        }


        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetHotelRoom(int? roomId)
        {
            if(roomId == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "Chybička se vloudila",
                    ErrorMessage = "Neplatné Id pokoje...",
                    StatusCode=StatusCodes.Status400BadRequest
                });
            }

            var roomDetails = await _hotelRoomRepository.GetHotelRoom(roomId.Value);

            if (roomDetails == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "Chybička se vloudila",
                    ErrorMessage = "Neplatné Id pokoje...",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(roomDetails);
        }









    }
}
