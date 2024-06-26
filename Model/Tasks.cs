using System.Threading.Tasks;

namespace GfsBalloting.Model
{
    public class Tasks
    {
      public Guid  TaskId           {get;set;}
      public string Title { get;set;}
      public string  DateAndTime    {get;set;}
      public string  TaskPriority   {get;set;}
      public string  TaskCategory   {get;set;}
      public int TotalDays { get;set;}
      public float TotalHours { get;set;}
      public string Duration       {get;set;}
      public Guid UserId { get; set; }

    }
}
