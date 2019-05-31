using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskServerApp.Models;

namespace TaskServerApp
{
    public class AppDataBaseContextSL:DbContext
    {
        public AppDataBaseContextSL(DbContextOptions<AppDataBaseContextSL> options):base (options)
        {

        }
        public DbSet<MyTask> Tasks { get; set; }

        public DbSet<User> Users   { get; set; }

    }
}
