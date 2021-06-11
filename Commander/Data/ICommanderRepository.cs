using Commander.Models;
using System.Collections.Generic;

namespace Comander.Data
{
    public interface IcommanderRepository
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
    }
}