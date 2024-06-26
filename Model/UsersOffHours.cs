namespace GfsBalloting.Model
{
    public class UsersOffHours
    {
      public Guid  UserOffHoursId   {get;set;}
      public Guid  UserId           {get;set;}
      public DateTime  HourFrom         {get;set;}
      public DateTime HourTo { get; set; }

    }
}
