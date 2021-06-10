using Commander.Models;
using System.Collections.Generic;

namespace Comander.Data
{
    public interface IcommanderRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}