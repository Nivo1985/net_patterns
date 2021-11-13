using System;

namespace SingletonPattern.Implementations
{
    public sealed class UltimateSingleton
    {
        private static readonly Lazy<UltimateSingleton>
            _lazy = new Lazy<UltimateSingleton>(() => new UltimateSingleton());

        public static UltimateSingleton Instance
        {
            get
            {
                Console.WriteLine("Instance");
                return _lazy.Value;
            }
        }
        
        private UltimateSingleton()
        {
            Console.WriteLine("Ultimate Singleton Singleton Constructor");
        }
    }
}