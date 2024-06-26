namespace GfsBalloting.Model
{
    public class SubTask
    {
      public Guid  SubTaskId        {get;set;}
      public Guid  TaskId           {get;set;}
      public int  TaskDays         {get;set;}
      public string  TotalHours       {get;set;}
      public DateTime DateForAttempt { get;set;}
      public float HoursPerDay { get;set;}
      public Guid UserId { get; set; }
    }
}
