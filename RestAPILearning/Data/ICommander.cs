using RestAPILearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestAPILearning.Data
{
   public interface ICommander
    {
        IEnumerable<Command> GetAllCommands();

        Command GetCommandbyID(int Id);
    }
}
