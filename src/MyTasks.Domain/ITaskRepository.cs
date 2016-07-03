using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Domain
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        Task GetById(int id);
        Task Save(Task task);
        void Delete(Task task);
    }
}
