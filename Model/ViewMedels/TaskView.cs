using System.Threading.Tasks;

namespace GfsBalloting.Model.ViewMedels
{
    public class TaskView
    {
        public string     Duration          {get;set;}
        public string Title { get;set;}
        public string     TaskPriority      {get;set;}
        public string     TotalDays         {get;set;}
        public Guid SubTaskId         {get;set;}
        public Guid     TaskId            {get;set;}
        public string     TaskDays          {get;set;}
        public string     TotalHours        {get;set;}
        public string     HoursPerDay       {get;set;}
        public Guid UserId { get; set; }

        public List<UsersOffHours> offHours { get;set;}  
        public List<TaskView> taskViews  { get;set;}  
    }
}
