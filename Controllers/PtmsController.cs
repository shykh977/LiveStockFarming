using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PwDbAssistant.DbConnect;
using PwDbAssistant.Common;
using PwDbAssistant.DataLayer;
using System.Reflection.Metadata;
using GfsBalloting.Model;
using GfsBalloting.Model.ViewMedels;

namespace PwDbAssistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PtmsController : ControllerBase
    {
        private IGenericRepository<Users> _IgenericRepository;
        APIResponse apiresponse = new APIResponse();
        private readonly IWebHostEnvironment _environment;

        PtmsService ptmsService  = null;

        public PtmsController(IGenericRepository<Users> igenericRepository)
        {
            ptmsService = new PtmsService(igenericRepository);
          
        }

        [HttpPost]
        [Route("CreateUsers")]
        public ActionResult CreateUsers(Users users)
        {
            return Ok(ptmsService.CreateUsers(users));
        }
        
        [HttpPost]
        [Route("LoginUser")]
        public ActionResult LoginUser(Users users)
        {
            return Ok(ptmsService.LoginUser(users));
        }

        [HttpPost]
        [Route("CreateTask")]
        public ActionResult CreateTask(Tasks? tasks)
        {
            return Ok(ptmsService.CreateTask(tasks));
        }

        [HttpPost]
        [Route("CreateUserOffHours")]
        public ActionResult CreateUserOffHours(UsersOffHours usersOffHours)
        {
            return Ok(ptmsService.CreateUserOffHours(usersOffHours));
        }

        [HttpPost]
        [Route("GetUserOffHours")]
        public ActionResult GetUserOffHours(UsersOffHours usersOffHours)
        {
            return Ok(ptmsService.GetUserOffHours(usersOffHours));
        }

        [HttpPost]
        [Route("GetTasks")]
        public ActionResult GetTasks(TaskFilter usersOffHours)
        {
            return Ok(ptmsService.GetTakes(usersOffHours));
        }

        [HttpPost]
        [Route("GetTasksReminder")]
        public ActionResult GetTasksReminder(TaskFilter usersOffHours)
        {
            return Ok(ptmsService.GetTakesReminder(usersOffHours));
        }



    }
}
