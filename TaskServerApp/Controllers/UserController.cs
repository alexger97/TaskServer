using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using TaskServerApp.Models;

namespace TaskServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase,IUserController
    {

        private AppDataBaseContextSL context;

        public UserController(AppDataBaseContextSL context)
        {
            this.context = context;
        }

        public bool ChekUser (IUser user)
        {
            if (context.Users.Contains(user))
                return true;
            return false;
                

        }


        [HttpGet("GetAllUsers")]
 
        public List<User> GetAllUsers()
        {

            return context.Users.ToList();
        }

        [HttpPost("LoginUser")]
        public IUser LoginUser([FromBody]object[] auth)
        {
            string password = auth[1] as string;
           
            try
            {
               var user = context.Users.Where(x => x.Name == auth[0] as string);
             user =   user.Where(x => x.Password.Equals(password));
                if (user != null)
                {
                    return user.First();

                }
                else return null;
            }
            catch (Exception x) { return null; }
          
        }


        [HttpPost("AddUser")]
        public IUser AddUser([FromBody]object[] auth)
        {
            

            string password = auth[1] as string;
            context.Users.Add(new User { Name = auth[0] as string, Password = auth[1] as string });
            context.SaveChanges();

            try { 
            var user = context.Users.Where(x => x.Name == auth[0] as string).Where(x => x.Password.Equals(password));
                if (user != null)
                {
                    return user.First();

                }
                return null;
            }
            catch (Exception c) { return null; }
            

        }


    }
}
