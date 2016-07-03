using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Domain;

namespace MyTasks.Api.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private ITaskRepository _repository;

        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            MyTasks.Domain.Task task = _repository.GetById(id);

            if(task == null)
                return NotFound();

            return Ok(_repository.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(MyTasks.Domain.Task task)
        {
            _repository.Save(task);

            return Ok(task);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, MyTasks.Domain.Task task)
        {
            _repository.Save(task);

            return Ok(task);
        }

        // PUT api/values/5
        [HttpPut("Completed/{id}")]
        public IActionResult Completed(int id)
        {
            MyTasks.Domain.Task task = _repository.GetById(id);

            System.Console.WriteLine(task.Id);
            if(task == null)
                return NotFound();

            task.Completed = !task.Completed;

            _repository.Save(task);

            return Ok(task);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            MyTasks.Domain.Task task = _repository.GetById(id);

            if(task == null)
                return NotFound();

            _repository.Delete(task);

            return Ok();
        }
    }
}
