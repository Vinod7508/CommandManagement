using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestAPILearning.Data;
using RestAPILearning.Dtos;
using RestAPILearning.Models;
using System.Collections.Generic;

namespace RestAPILearning.Controllers
{
    //api//Commands
    [Route("api/[Controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommander _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommander repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

    //Get api/commands
    [HttpGet]
       public ActionResult <IEnumerable<Command>> GetAllCommands()
       {

            var commandsItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandsItems));
        }



        //get api/commands/{id}
        [HttpGet("{id}",Name= "GetCommandbyId")]
        public ActionResult<CommandReadDto> GetCommandbyId(int id)
        {

            var singlecommand = _repository.GetCommandbyID(id);
            if(singlecommand != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(singlecommand));
            }

            return NotFound();
        }



        //post api/commands

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandmodel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandmodel);
            _repository.SaveChanges();

            var commandReaddto = _mapper.Map<CommandReadDto>(commandmodel);

            //return Ok(commandReaddto);

            return CreatedAtRoute(nameof(GetCommandbyId), new { id = commandReaddto.Id },commandReaddto );
        }




        //putaction api/commands/{id}
        [HttpPut("{Id}")]
        public IActionResult UpdateCommand(int Id,CommandUpdateDto commandUpdateDto)
        {
            var commandfromrepo = _repository.GetCommandbyID(Id);

            if(commandfromrepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandfromrepo);
            _repository.UpdateCommand(commandfromrepo);
            _repository.SaveChanges();

            return NoContent();   
        }


        //patch  api/commnads/{id}
        [HttpPatch("{Id}")]
        public ActionResult PartialUpdate(int Id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandfromrepo = _repository.GetCommandbyID(Id);

            if (commandfromrepo == null)
            {
                return NotFound();
            }

            var CommandtoPatch = _mapper.Map<CommandUpdateDto>(commandfromrepo);
            patchDoc.ApplyTo(CommandtoPatch, ModelState);

            if (!TryValidateModel(CommandtoPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(CommandtoPatch, commandfromrepo);

            _repository.UpdateCommand(commandfromrepo);
            _repository.SaveChanges();

            return NoContent();


        }

    }
}
