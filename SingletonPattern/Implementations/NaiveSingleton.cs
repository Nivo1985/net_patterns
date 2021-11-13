using System;

namespace SingletonPattern.Implementations
{
    public sealed class NaiveSingleton
    {
        private static NaiveSingleton _instance;
        
        private NaiveSingleton()
        {
            Console.WriteLine("Naive Singleton Constructor");
        }

        public static NaiveSingleton Instance
        {
            get
            {
               Console.WriteLine("Instance"); 
               return _instance ??= new NaiveSingleton();
            }
        } 
    }
}