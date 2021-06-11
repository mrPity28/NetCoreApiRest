using System;
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

        public void CreateCommand(Command command)
        {
            if(command == null){
                throw new ArgumentNullException(nameof(command));
            }
            _context.Commands.Add(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id );
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            //notthing
        }
    }
}