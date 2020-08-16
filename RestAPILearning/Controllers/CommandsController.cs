using Microsoft.AspNetCore.Mvc;
using RestAPILearning.Data;
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

        public CommandsController(ICommander repository)
        {
            _repository = repository;
        }

    //Get api/commands
    [HttpGet]
       public ActionResult <IEnumerable<Command>> GetAllCommands()
       {

            var commandsItems = _repository.GetAllCommands();
            return Ok(commandsItems);
        }



        //get api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandbyId(int id)
        {

            var singlecommand = _repository.GetCommandbyID(id);
            return Ok(singlecommand);

        }


    }
}
