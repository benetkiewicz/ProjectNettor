namespace Tests
{
    using System;
    using System.Collections.Generic;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TaskManagerTests
    {
        [TestMethod]
        public void NoOverlappingTasksReportTest()
        {
            var manager = new TaskManager(new MockDbAccess());

            string report = manager.GetReport();

            Assert.AreEqual(ExpectedNoOverlapReport, report);
        }

        [TestMethod]
        public void OverlappingTasksReportTest()
        {
            var mockDbAccess = new MockDbAccess();
            mockDbAccess.Overlapping = true;
            var manager = new TaskManager(mockDbAccess);

            string report = manager.GetReport();

            Assert.AreEqual(ExpectedOverlapReport, report);
        }

        private const string ExpectedNoOverlapReport = @"
08:00 - 09:15 = desc 1
09:15 - 09:30 = other desc";
        private const string ExpectedOverlapReport = @"
08:00 - 09:15 = desc 1, desc 1 overlap
09:15 - 09:30 = other desc";
    }

    public class MockDbAccess : IDbAccess
    {
        public bool Overlapping { get; set; }

        public void AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public IList<Task> GetTasksFromDay(DateTime today)
        {
            if (Overlapping)
            {
                var taskList = new List<Task>();
                var day = new DateTime(2011, 11, 20, 1, 1, 1);
                var endTime1 = new DateTime(2011, 11, 20, 9, 15, 0);
                var endTime2 = new DateTime(2011, 11, 20, 9, 15, 0);
                var endTime3 = new DateTime(2011, 11, 20, 9, 30, 0);
                taskList.Add(new Task() { Day = day, Description = "desc 1", EndTime = endTime1 });
                taskList.Add(new Task() { Day = day, Description = "desc 1 overlap", EndTime = endTime2 });
                taskList.Add(new Task() { Day = day, Description = "other desc", EndTime = endTime3 });
                return taskList;
            }
            else
            {
                var taskList = new List<Task>();
                var day = new DateTime(2011, 11, 20, 1, 1, 1);
                var endTime1 = new DateTime(2011, 11, 20, 9, 15, 0);
                var endTime2 = new DateTime(2011, 11, 20, 9, 30, 0);
                taskList.Add(new Task() {Day = day, Description = "desc 1", EndTime = endTime1});
                taskList.Add(new Task() {Day = day, Description = "other desc", EndTime = endTime2});
                return taskList;
            }
        }
    }
}