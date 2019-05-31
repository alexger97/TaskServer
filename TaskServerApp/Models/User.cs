using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskServerApp.Models
{
    public class User: IUser
    {
   
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

    }
}
