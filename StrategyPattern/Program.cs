using System;
using System.Collections.Generic;
using StrategyPattern.Domain;
using StrategyPattern.Domain.Strategies.Utils;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // set context data
            var travelData = new TravelData()
            {
                Name = "Karol",
                Departure = "Poland",
                Destination = "Spain",
                InnerEuTravel = true,
                ExtraLuggage = false
            };
            
            // set strategies
            travelData.VisaCostCalculator = StrategiesGenerator.GetVisaCostStrategy(travelData.InnerEuTravel);
            travelData.LuggageCost = StrategiesGenerator.GetLuggageCostStrategy(travelData.ExtraLuggage, travelData.InnerEuTravel);
            
            //use object with strategies
            Console.WriteLine("First Travel Cost");
            Console.WriteLine(travelData.GetExtraCost().ToString());
            //////////////////////////////////////////////////////////////
            var travelDataList = new List<TravelData>()
            {
                new TravelData()
                {
                    Name = "Karol",
                    Departure = "Poland",
                    Destination = "Spain",
                    InnerEuTravel = true,
                    ExtraLuggage = false,
                    VisaCostCalculator = StrategiesGenerator.GetVisaCostStrategy(true),
                    LuggageCost = StrategiesGenerator.GetLuggageCostStrategy(false, true)
                },
                new TravelData()
                {
                    Name = "Adam",
                    Departure = "Poland",
                    Destination = "China",
                    InnerEuTravel = false,
                    ExtraLuggage = true,
                    VisaCostCalculator = StrategiesGenerator.GetVisaCostStrategy(false),
                    LuggageCost = StrategiesGenerator.GetLuggageCostStrategy(true, false)
                },
                new TravelData()
                {
                    Name = "Piotr",
                    Departure = "Poland",
                    Destination = "Canada",
                    InnerEuTravel = false,
                    ExtraLuggage = false,
                    VisaCostCalculator = StrategiesGenerator.GetVisaCostStrategy(false),
                    LuggageCost = StrategiesGenerator.GetLuggageCostStrategy(false, false)
                }
            };
            
            travelDataList.Sort(new TravelComparer());
        }
    }
}