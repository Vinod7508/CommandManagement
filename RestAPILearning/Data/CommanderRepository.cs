using RestAPILearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPILearning.Data
{
    public class CommanderRepository : ICommander
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "how to boil", Line = "Boil water", Platform = "Pan" },
                new Command { Id = 1, HowTo = "cut a bread", Line = "get a knife", Platform = "chopping board" },
                new Command { Id = 2, HowTo = "Make a cup of tea", Line = "Place a tea bag in a cup", Platform = " Tea Cup" }
            };
            return commands;
        }



        public Command GetCommandbyID(int Id)
        {
        return new Command { Id = 0, HowTo = "how to boil", Line = "Boil water", Platform = "Pan" };
        }
    }
}
