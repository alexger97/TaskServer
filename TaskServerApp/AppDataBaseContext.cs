using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskServerApp.Models;

namespace TaskServerApp
{
    public class AppDataBaseContext:DbContext
    {
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options):base (options)
        {

        }
        public DbSet<MyTask> Tasks { get; set; }

       // public DbSet<User> Users   { get; set; }

    }
}
