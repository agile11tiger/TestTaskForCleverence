using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.Task1;

namespace Tests.Task1
{
    public class ServerTests
    {
        [Test]
        public void AddToCount()
        {
            var tasks = new List<Task>();

            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    tasks.Add(Task.Run(() => Server.GetCount()));
                }

                tasks.Add(Task.Run(() => Server.AddToCount(1)));
            }

            Task.WaitAll(tasks.ToArray());
            Assert.AreEqual(100, Server.GetCount());
        }
    }
}
