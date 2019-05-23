using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskServerApp.Models
{
    public class MyTask 
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
     
        public bool Importance { get; set; }
        
        public bool Urgency { get; set; }




        public MyTask(int id,string Name, string Description, bool Importance, bool Urgency)
        {
            this.Id = id;
            this.Name = Name;
            this.Description = Description;
            this.Importance = Importance;
            this.Urgency = Urgency;

        }

        public MyTask() { }
    }
}
