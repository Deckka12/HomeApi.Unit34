﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using HomeApi.Contracts.Models.Home;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using HomeApi.Data.Queries;
using HomeApi.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository _repository;
        private IMapper _mapper;
        private IRoomRepository _rooms;

        public RoomsController(IRoomRepository repository, IMapper mapper, IRoomRepository rooms) {
            _repository = repository;
            _mapper = mapper;
            _rooms = rooms;
        }

        //TODO: Задание - добавить метод на получение всех существующих комнат
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromRoute]Guid id,
            [FromBody]EditRoomRequest request) {
            var room = await _rooms.GetRoomById(id);
            if(room == null)
                return StatusCode(400, $"Ошибка: Комнаты с иденитификатором {id} не существует.");
            await _rooms.UpdateRoom(
                room,
                new UpdateRoomQuery(request.NewName, request.Area)
            );
            return StatusCode(201, $" Комната изменена на {request.NewName}.");
        }
        /// <summary>
        /// Добавление комнаты
        /// </summary>
        [HttpPost] 
        [Route("")] 
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom == null)
            {
                var newRoom = _mapper.Map<AddRoomRequest, Room>(request);
                await _repository.AddRoom(newRoom);
                return StatusCode(201, $"Комната {request.Name} добавлена!");
            }
            
            return StatusCode(409, $"Ошибка: Комната {request.Name} уже существует.");
        }
    }
}