using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Data;
using Comander.Data;
using AutoMapper;
using Commander.Dtos;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IcommanderRepository _repository;
        private readonly IMapper _mapper;

        public CommandsController(IcommanderRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {   
            var commands = _repository.GetAllCommands(); 
            return (commands != null) ? Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands)) : NotFound();
        }
        //GET api/commands/{id}
        //GET api/commands/5
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            return (command != null) ? Ok(_mapper.Map<CommandReadDto>(command)) : NotFound();
        }

    }
}