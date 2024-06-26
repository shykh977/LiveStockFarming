using PwDbAssistant.DbConnect;

using PwDbAssistant.Common;
using ExcelDataReader;
using System.Data;
using GfsBalloting.Model;
using GfsBalloting.Model.ViewMedels;
using System.Threading.Tasks;

namespace PwDbAssistant.DataLayer
{
    public class PtmsService
    {
        private IGenericRepository<Users> _IgenericRepository;

        APIResponse apiresponse = new APIResponse();


        public PtmsService(IGenericRepository<Users> igenericRepository)
        {
            _IgenericRepository = igenericRepository;
        }

        public APIResponse CreateUsers(Users users)
        {
            users.UserId = Guid.NewGuid();
            var res = _IgenericRepository.ExecuteQuery<Users>(users, "usp_Create_Update_Users").ToList();
            apiresponse.Response = res;
            return apiresponse;
        }


        public APIResponse LoginUser(Users users)
        {

            object obj = new
            {
                UserName = users.UserName,
                Password = users.Password,
            };

            var res = _IgenericRepository.ExecuteQuery<Users>(obj, "usp_LoginUser").FirstOrDefault();
            apiresponse.Response = res;
            return apiresponse;
        }



        public APIResponse CreateTask(Tasks? task)
        {


           Guid TaskId = Guid.NewGuid();    
           Guid SubTaskId = Guid.NewGuid();

            task.Duration.ToString();
            task.TaskId = TaskId;


            int TotalDays =Convert.ToInt32( (Convert.ToDateTime(task.Duration) - (DateTime.Now)).TotalDays);
           // float TotalHours = Convert.ToInt32( (Convert.ToDateTime(task.Duration) - (DateTime.Now)).TotalHours);

            task.TotalDays = TotalDays;
            //task.TotalHours = TotalHours;





            var res = _IgenericRepository.ExecuteQuery<Tasks>(task, "usp_Create_Update_Task").ToList();

            for (int i = 1; i <= TotalDays; i++)
            {
               


                SubTask subTask = new SubTask
                {
                    SubTaskId = Guid.NewGuid(),
                    TaskId = TaskId,
                    TaskDays = i,
                    // TotalHours = TotalHours.ToString(),
                    HoursPerDay = task.TotalHours,
                    UserId = task.UserId,
                    DateForAttempt = Convert.ToDateTime(task.DateAndTime).AddDays(i-1)
                };

                _IgenericRepository.ExecuteQuery<SubTask>(subTask, "usp_Create_Update_SubTask").ToList();

            }
            apiresponse.Response = res;
            return apiresponse;
        }


        public APIResponse CreateUserOffHours(UsersOffHours users)
        {



            int duration =0;
            users.UserOffHoursId = Guid.NewGuid();
           
           
            var startTime = Convert.ToDateTime(users.HourFrom).ToShortTimeString();
            var endTime = Convert.ToDateTime(users.HourTo).ToShortTimeString();

            DateTime start = DateTime.Parse(startTime);
            DateTime end = DateTime.Parse(endTime);


            if (Convert.ToDateTime(start) > Convert.ToDateTime(end))
            {
                end = end.AddDays(1);
                 duration = Convert.ToInt32( end.Subtract(start).TotalHours);
            }
            DateTime dateTime = users.HourFrom;


         

            for (int i = 1; i <=duration; i++)
            {

                DateTime dt = dateTime.AddHours(i);


              
                users.HourFrom = dt;
                users.HourTo = dt;

                users.UserOffHoursId = Guid.NewGuid();

                _IgenericRepository.ExecuteQuery<UsersOffHours>(users, "usp_Create_Update_UserOffHours").ToList();
            }
           

            //var res = _IgenericRepository.ExecuteQuery<UsersOffHours>(users, "usp_Create_Update_UserOffHours").ToList();
            apiresponse.StatusMessage ="Off Hours Created";
            return apiresponse;
        }
     
        public APIResponse GetUserOffHours(UsersOffHours users)
        {


            object obj = new 
            {

                UserId = users.UserId

            };

            var res = _IgenericRepository.ExecuteQuery<UsersOffHours>(obj, "usp_GetUserOffHours").ToList();
            apiresponse.Response = res;
            return apiresponse;
        }
        
        public APIResponse GetTakes(TaskFilter taskFilter)
        {

            TaskView taskViews = new TaskView();


            taskViews.taskViews = _IgenericRepository.ExecuteQuery<TaskView>(taskFilter, "usp_GetTakes").ToList();

            taskViews.offHours = _IgenericRepository.ExecuteQuery<UsersOffHours>(new { UserId = taskFilter.UserId }, "usp_GetUserOffHours").ToList();


            apiresponse.Response = taskViews;
            return apiresponse;
        }

         public APIResponse GetTakesReminder(TaskFilter taskFilter)
        {


            taskFilter.FromDate = DateTime.Now;
            taskFilter.Todate = DateTime.Now.AddHours(3);


            var res = _IgenericRepository.ExecuteQuery<TaskView>(taskFilter, "usp_GetTakes").ToList();
            apiresponse.Response = res;
            return apiresponse;
        }


    }

}
