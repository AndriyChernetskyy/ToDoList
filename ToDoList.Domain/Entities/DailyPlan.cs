using System;

namespace ToDoList.Models
{
    public class DailyPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DatePlanedFor { get; set; }
        public string PlanDescription { get; set; }
    }
}
