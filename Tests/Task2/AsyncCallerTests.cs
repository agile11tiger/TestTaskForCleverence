using NUnit.Framework;
using System;
using System.Threading;
using Tasks.Task2;

namespace Tests.Task2
{
    public class AsyncCallerTests
    {
        [Test]
        public void AsyncCallerWorks()
        {
            var handler = new EventHandler((sender, args) => Thread.Sleep(500));
            var caller = new AsyncCaller(handler);

            Assert.IsTrue(caller.Invoke(1000, null, EventArgs.Empty));
            Assert.IsFalse(caller.Invoke(300, null, EventArgs.Empty));
        }
    }
}
