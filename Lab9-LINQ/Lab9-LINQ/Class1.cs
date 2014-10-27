using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9_LINQ
{
    public class Car {
        public String Make { get; set; }
        public String Model { get; set; }
        public String Registration { get; set; }
        public double EngineSize { get; set; }

        public override String ToString() {
            return "Make: " + Make + "\tModel: " + Model 
                + "\tReg: " + Registration + "\tEngine: " + EngineSize;
        }
    }
       
    class Fleet {
        public static void Main(String[] args) {
            List<Car> fleet = new List<Car>();
            fleet.Add(new Car() { Make = "Mazda", Model = "MX5", Registration = "12 D 12", EngineSize = 2000 });
            fleet.Add(new Car() { Make = "Mazda", Model = "3", Registration = "12 D 13", EngineSize = 1600 });
            fleet.Add(new Car() { Make = "BMW", Model = "5 Series", Registration = "12 D 14", EngineSize = 2000 });
            fleet.Add(new Car() { Make = "Toyota", Model = "Yaris", Registration = "12 D 16", EngineSize = 1100 });
            fleet.Add(new Car() { Make = "Renault", Model = "Scenic", Registration = "12 D 17", EngineSize = 1400 });
            fleet.Add(new Car() { Make = "Ford", Model = "Focus", Registration = "12 D 15", EngineSize = 1400 });

            // List all cars in ascending registration order
            var ascendingReg = fleet.OrderBy(car => car.Registration);
            foreach (var car in ascendingReg) {
                Console.WriteLine(car);
            }

            // List the models for all Mazda cars in the fleet
            var mazdaCars = fleet.Where(car => car.Make == "Mazda")
                                 .Select(car => car.Make); // get only the make
            foreach (var car in mazdaCars) {
                Console.WriteLine(car);
            }

            // List all cars in descending engine size order
            var descEngineCar = fleet.OrderByDescending(car => car.EngineSize);
            foreach (var car in descEngineCar) {
                Console.WriteLine(car);
            }

            // List just the make and model for cars whose engine size is 1600 cc
            var carCC = fleet.Where(car => car.EngineSize == 1600)
                .Select(car => new { car.Make, car.Model });
            foreach(var car in carCC) {
                Console.WriteLine(car);
            }

            // Count the number of cars whose engine size is 1600 cc or less
            var ccCount = fleet.Where(car => car.EngineSize <= 1600).Count();
            Console.WriteLine(ccCount);
            Console.ReadKey();
        }
    }
}
