namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;

    public class DbAccess : IDbAccess
    {
        private const string ConnectionString = "Data Source=c:\\temp\\db.s3db";

        public void AddTask(Task task)
        {
            const string sql = "insert into Tasks (DESCRIPTION, ENDTIME, DAY) values (@description, @endtime, @day)";
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = sql;

                    command.Parameters.Add(new SQLiteParameter("description", task.Description));
                    command.Parameters.Add(new SQLiteParameter("endtime", task.EndTime));
                    command.Parameters.Add(new SQLiteParameter("day", task.Day));

                    command.ExecuteNonQuery();
                }
            }
        }

        public IList<Task> GetTasksFromDay(DateTime day)
        {
            const string sql = "select DESCRIPTION, ENDTIME, DAY from Tasks where DAY=@day";

            var result = new List<Task>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = sql;

                    command.Parameters.Add(new SQLiteParameter("day", day));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var task = new Task();
                            task.Description = reader["DESCRIPTION"].ToString();
                            task.EndTime = DateTime.Parse(reader["ENDTIME"].ToString());
                            task.Day = day;

                            result.Add(task);
                        }

                        return result;
                    }
                }
            }
        }
    }
}