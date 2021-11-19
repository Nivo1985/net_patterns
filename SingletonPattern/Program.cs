using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SingletonPattern.Implementations;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // // 1
            //Casses.NaiveSingletonUsaga();
            
            // // 2
            // Casses.NaiveSingletParallelProblem();
            
            // // 3
            // Casses.ThreadSafeSingletParallelUsage();

            // // 3
            // var watch1 = new Stopwatch();
            // var watch2 = new Stopwatch();
            //
            // watch1.Start();
            // for (int i = 0; i < 1000; i++)
            // {
            //     Casses.ThreadSafeSingletParallelUsage();    
            // }
            // watch1.Stop();
            //
            // watch2.Start();
            // for (int i = 0; i < 1000; i++)
            // {
            //     Casses.UltimateSingletonParallelUsage();    
            // }
            // watch2.Stop();
            //
            // Console.WriteLine($"ThreadSafeSingletParallelUsage x 1 000 took: {watch1.ElapsedMilliseconds}");
            // Console.WriteLine($"UltimateSingletonParallelUsage x 1 000 took: {watch2.ElapsedMilliseconds}");
        }
    }

    public static class Casses
    {
        public static void NaiveSingletonUsaga()
        {
            var inst1 = NaiveSingleton.Instance;
            var inst2 = NaiveSingleton.Instance;
            var inst3 = NaiveSingleton.Instance;
        }

        public static void NaiveSingletParallelProblem()
        {
            var options = new ParallelOptions(){MaxDegreeOfParallelism = 3};
            var counters = new List<int>(){1, 2, 3};
            var instancesCollection = new List<NaiveSingleton>();
            Parallel.ForEach(counters, options, x =>
            {
                Console.WriteLine(x.ToString());
                instancesCollection.Add(NaiveSingleton.Instance);
            });
        }
        
        public static void ThreadSafeSingletParallelUsage()
        {
            var options = new ParallelOptions(){MaxDegreeOfParallelism = 3};
            var counters = new List<int>(){1, 2, 3};
            var instancesCollection = new List<ThreadSafeSingleton>();
            Parallel.ForEach(counters, options, x =>
            {
                Console.WriteLine(x.ToString());
                instancesCollection.Add(ThreadSafeSingleton.Instance);
            });
        }    
        
        public static void UltimateSingletonParallelUsage()
        {
            var options = new ParallelOptions(){MaxDegreeOfParallelism = 3};
            var counters = new List<int>(){1, 2, 3};
            var instancesCollection = new List<UltimateSingleton>();
            Parallel.ForEach(counters, options, x =>
            {
             Console.WriteLine(x.ToString());
             instancesCollection.Add(UltimateSingleton.Instance);
            });
        }
    } 
}