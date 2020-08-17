using RestAPILearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestAPILearning.Data
{
   public interface ICommander
    {

        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandbyID(int Id);
        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);

       
    }
}
