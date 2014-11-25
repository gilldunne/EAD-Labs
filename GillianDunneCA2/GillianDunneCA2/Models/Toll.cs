// Gillian Dunne - X00094469

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GillianDunneCA2.Models {
    public enum CarType {
        Car,
        [Display(Name = "Public Service Vehicle")]
        PSV,
        Bus, Goods
    }
    public class Toll {
        // Dictionary to hold the Car and the cost of toll relating to that car
        protected static Dictionary<CarType, Double> dictionary = new Dictionary<CarType, double>();
        protected static int index = 0;
        protected static double[] charge = { 2.00, 2.00, 2.80, 4.10 };
   
        // Fill the dictionary the first time the code is run only
        // Add the Car Type as the key and the toll charge as the value
        static Toll() {
            foreach (CarType c in Enum.GetValues(typeof(CarType))) {
                dictionary.Add(c, charge[index]);
                index++;
            }
        }

        [Display(Name = "Tick for Electronic Tag")]
        [Required(ErrorMessage = "Is Tag Present?")]
        public bool Tag { get; set; }

        [Display(Name = "Car Type")]
        [Required(ErrorMessage = "Car Type Required")]
        public CarType CarType { get; set; }

        // Using the dictionary, get the CarType selected with
        // the corresponding charge. If the vehicle has a tag
        // then apply a 20% discount
        [DataType(DataType.Currency)]
        public double Cost {
            get {
                double cost = 0.0;
                double dir = dictionary[this.CarType];
                
                if (Tag) { 
                    cost = dir * 0.8;
                }
                else {
                    cost = dir;
                }
                return cost;
            }
        }
    }
}