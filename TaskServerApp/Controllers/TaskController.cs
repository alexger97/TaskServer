using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskServerApp.Models;


namespace TaskServerApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private AppDataBaseContext context;

        public TaskController(AppDataBaseContext context)
        {
            this.context = context;
        }


        // GET api/values
        [HttpGet("GetAllTasks")]
        [HttpGet("GetAllTasks/{id}")]
        public List<MyTask> GetAllTask(int id)
        {
            return context.Tasks.ToList<MyTask>();
        }


        [HttpGet("{id}")]
        public MyTask Get(int id)
        {
            if (context.Tasks.ToList<MyTask>().Exists(x => x.Id == id))
                return context.Tasks.First(x => x.Id == id);
            return null;
        }

        
        [HttpPost]
        public ActionResult Post([FromBody] MyTask task)
        {

            if (context.Tasks.Any(x => x.Id == task.Id))
            {
                Put(task);
            }
            context.Tasks.Add(task);
            context.SaveChanges();
            return this.Ok();

        }

        [HttpPut]
        public ActionResult Put(MyTask task)
        {
            if (context.Tasks.Any(x => x.Id == task.Id))
            {
                context.Tasks.Find(task.Id).Description = task.Description;
                context.Tasks.Find(task.Id).Name = task.Name;
                context.Tasks.Find(task.Id).Importance = task.Importance;
                context.Tasks.Find(task.Id).Urgency = task.Urgency;
                context.SaveChanges();
                return this.Ok();
            }
            return this.StatusCode((int)HttpStatusCode.NotFound);
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (context.Tasks.Any(x => x.Id == id))
            {
                context.Tasks.Remove(context.Tasks.Find(id));
                context.SaveChanges();
                return this.Ok();

            }
            return this.StatusCode((int)HttpStatusCode.NotFound);
        }
    }
}
