using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Domain
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
    }
}
