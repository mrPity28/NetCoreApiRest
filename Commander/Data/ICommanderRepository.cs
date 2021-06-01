using Commander.Models;
using System.Collections.Generic;

namespace Comander.Data
{
    public interface IcommanderRepository
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}