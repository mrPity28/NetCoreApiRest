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
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{id}" , Name ="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            return (command != null) ? Ok(_mapper.Map<CommandReadDto>(command)) : NotFound();
        }
        
        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //retornar 201
            return CreatedAtRoute(nameof(GetCommandById) , new {Id = commandReadDto.Id} , commandReadDto);
            //asi retorno un 200 y todo a nivel basico
            //return Ok(commandReadDto);
        }

        //PUT api/commands/{id}
        //PUT api/commands/7
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id , CommandUpdateDto commandUpdateDto)
        {

            var commandModelFromRepo = _repository.GetCommandById(id);

            if(commandModelFromRepo == null)
                return NotFound();

            //aqui se asigna la data
            _mapper.Map(commandUpdateDto , commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        //PATH api/commands/{id}
        //PATH api/commands/5
        /*
            [
                {
                    "op":"replace",
                    "path":"/howto",
                    "value":"some new value"
                },
                {
                    "op":"replace",
                    "path":"/howto",
                    "value":"some new value"
                },
            ]
        */
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id , JsonPatchDocument<CommandUpdateDto> patchDoc)
        {

            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
                return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch , ModelState);

            if(!TryValidateModel(commandToPatch)){
                return ValidationProblem(ModelState);
            }

            //aqui se asigna la data
            _mapper.Map(commandToPatch , commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        //DELETE api/commands/3
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
                return NotFound();


            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}