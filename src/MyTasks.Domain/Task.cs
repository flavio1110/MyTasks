using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public string  Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get;set; }
        // public User User { get; set; }        
    }
}
