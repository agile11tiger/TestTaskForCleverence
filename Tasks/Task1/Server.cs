using System.Threading;

namespace Tasks.Task1
{
    public static class Server
    {
        private static int count;
        private readonly static ReaderWriterLockSlim locker = new();

        public static int GetCount()
        {
            locker.EnterReadLock();

            try
            {
                return count;
            }
            finally
            {
                locker.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            locker.EnterWriteLock();

            try
            {
                checked
                {
                    count += value;
                }
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
