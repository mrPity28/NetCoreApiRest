using System.Collections.Generic;
using System.Linq;
using Comander.Data;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepository : IcommanderRepository
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepository(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id );
        }
    }
}