using Comander.Data;
using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    public class MockCommanderRepository : IcommanderRepository
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil ad egg", Line = "Boil Water", Platform = "Kettle & pan" },
                new Command { Id = 1, HowTo = "Boil ad egg", Line = "Boil Water", Platform = "Kettle & pan" },
                new Command { Id = 2, HowTo = "Boil ad egg", Line = "Boil Water", Platform = "Kettle & pan" },
                new Command { Id = 3, HowTo = "Boil ad egg", Line = "Boil Water", Platform = "Kettle & pan" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil ad egg", Line = "Boil Water", Platform = "Kettle & pan" };
        }
    }
}