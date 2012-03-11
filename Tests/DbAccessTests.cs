namespace Tests
{
    using System;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DbAccessTests
    {
        [TestMethod]
        public void AddTaskTest()
        {
            var access = new DbAccess();
            access.AddTask(new Task { Day = DateTime.Now, Description = "test321!", EndTime = DateTime.Now });
        }
    }
}
