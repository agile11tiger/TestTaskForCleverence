using System;
using System.Threading.Tasks;

namespace Tasks.Task2
{
    public class AsyncCaller
    {
        private readonly EventHandler handler;

        public AsyncCaller(EventHandler handler)
        {
            this.handler = handler;
        }

        public bool Invoke(int milliseconds, object sender, EventArgs args)
        {
            var task = Task.Run(() => handler.Invoke(sender, args));
            return task.Wait(milliseconds);
        }
    }
}
