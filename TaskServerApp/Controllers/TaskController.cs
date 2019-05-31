using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskServerApp.Controllers;
using TaskServerApp.Models;


namespace TaskServerApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase,ITaskController
    {
        private AppDataBaseContextSL context;
        private UserController userController;
        public TaskController(AppDataBaseContextSL context)
        {
            this.context = context;
            this.userController = new UserController(context);
                //(UserController)userController;
        }


        // GET api/values
        [HttpGet("GetAllTasks")]
        [HttpGet("GetAllTasks/{id}")]
        public List<MyTask> GetAllTask(int id)
        {

            List<MyTask> tt=new List<MyTask>();
            try { 
            foreach(MyTask cc in context.Tasks.Where(x=>x.UserId==id).ToList())
            {
                tt.Add(cc);
            }
            }
            catch { return null; }
            return tt;
        }


        [HttpGet("{id}")]
        public MyTask Get(int id)
        {
            if (context.Tasks.ToList<IMyTask>().Exists(x => x.Id == id))
                return context.Tasks.First(x => x.Id == id);
            return null;
        }

        
        [HttpPost]
        public ActionResult Post([FromBody] MyTask task)
        {

            //if (userController.ChekUser(task.TaskUser))
           // {
                if (context.Tasks.Any(x => x.Id == task.Id))
                {
                    Put(task);
                }
            try
            {
                context.Tasks.Add((MyTask)task);
                context.SaveChanges();
                return this.Ok();
            }
            catch { return this.StatusCode((int)HttpStatusCode.Unauthorized); }
           
           

        }

        [HttpPut]
        public ActionResult Put(IMyTask task)
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
