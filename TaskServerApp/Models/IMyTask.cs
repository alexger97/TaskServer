using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskServerApp.Models
{
    public interface IMyTask
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool Importance { get; set; }
        bool Urgency { get; set; }

        int UserId { get; set; }


      

    }
}
