using RestAPILearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPILearning.Data
{
    public class SqlCommanderRepository : ICommander
    {
        private readonly CommanderDBContext _context;

        public SqlCommanderRepository(CommanderDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandbyID(int Id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == Id);
        }
    }
}
