using System;


namespace Aids
{
    public static class Safe
    {
        public static T Run<T>(Func<T> function, T valueOnException)
        {
            try
            {
                return function();
            }
            catch (Exception e)
            {
                LogException(e);
                return valueOnException;
            }
        }
        public static void Run(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                LogException(e);
            }
        }

        private static void LogException(Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
