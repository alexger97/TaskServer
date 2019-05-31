using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskServerApp.Models
{
    public interface IUser
    {
        int Id { get; set; }

        string Name { get; set; }

        string Password { get; set; }
    }
}
