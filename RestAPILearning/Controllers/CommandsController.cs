using AutoMapper;
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
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandbyId(int id)
        {

            var singlecommand = _repository.GetCommandbyID(id);
            if(singlecommand != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(singlecommand));
            }

            return NotFound();
        }


    }
}
