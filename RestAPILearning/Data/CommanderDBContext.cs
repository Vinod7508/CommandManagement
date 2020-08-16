using Microsoft.EntityFrameworkCore;
using RestAPILearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPILearning.Data
{
    public class CommanderDBContext : DbContext
    {

        public CommanderDBContext(DbContextOptions<CommanderDBContext> options):base(options)
        {}


        public DbSet<Command> Commands { get; set;}
    }
}
