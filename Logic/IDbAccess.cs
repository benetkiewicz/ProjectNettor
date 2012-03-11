namespace Logic
{
    using System;
    using System.Collections.Generic;

    public interface IDbAccess
    {
        void AddTask(Task task);
        IList<Task> GetTasksFromDay(DateTime day);
    }
}