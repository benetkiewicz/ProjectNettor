namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TaskManager
    {
        private readonly IDbAccess dbAccess;

        public TaskManager(IDbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
        }

        public TaskManager() : this(new DbAccess())
        { }

        public void AddTask(string description)
        {
            DateTime today = DateTime.Today;
            DateTime endTime = new DateCalculator().CalculateEndTime(DateTime.Now);

            var task = new Task();
            task.Description = description;
            task.Day = today;
            task.EndTime = endTime;

            var db = new DbAccess();
            db.AddTask(task);
        }

        public string GetReport()
        {
            var builder = new StringBuilder();
            IList<Task> tasks = dbAccess.GetTasksFromDay(DateTime.Today);
            var previousTask = CreateFistTaskOfTheDay();

            foreach (var task in tasks)
            {
                if (previousTask.EndTime == task.EndTime)
                {
                    builder.Append(", ");
                    builder.Append(task.Description);
                }
                else
                {
                    builder.Append("\r\n");
                    builder.Append(previousTask.EndTime.ToString("HH:mm"));
                    builder.Append(" - ");
                    builder.Append(task.EndTime.ToString("HH:mm"));
                    builder.Append(" = ");
                    builder.Append(task.Description);
                }

                previousTask = task;
            }

            return builder.ToString();
        }

        private static Task CreateFistTaskOfTheDay()
        {
            return new Task { EndTime = new DateTime(2011, 11, 21, 8, 0, 0) };
        }
    }
}