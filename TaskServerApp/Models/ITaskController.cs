using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskServerApp.Models
{
    public interface ITaskController
    {
        List<MyTask> GetAllTask(int id);


        MyTask Get(int id);

        ActionResult Post([FromBody] MyTask task);

        ActionResult Put(IMyTask task);

        ActionResult Delete(int id);
       

    }
}
