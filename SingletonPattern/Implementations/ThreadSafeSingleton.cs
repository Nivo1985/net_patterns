using System;

namespace SingletonPattern.Implementations
{
    public sealed class ThreadSafeSingleton
    {
        private static ThreadSafeSingleton _instance;
        private static readonly object padlock = new object();
        
        private ThreadSafeSingleton()
        {
            Console.WriteLine("Thread Safe Singleton Constructor");
        }

        public static ThreadSafeSingleton Instance
        {
            get
            {
               Console.WriteLine("Instance");

               if (_instance == null)
               {
                   lock (padlock)
                   {
                       _instance ??= new ThreadSafeSingleton();
                   }
               }
               
               return _instance;
            }
        } 
    }
}