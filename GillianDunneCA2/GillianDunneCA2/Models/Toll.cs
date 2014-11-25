// Gillian Dunne - X00094469

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GillianDunneCA2.Models {
    public enum VehicleType {
        Car,
        [Display(Name = "Public Service Vehicle")]
        PSV,
        Bus, Goods
    }
    public class Toll {
        // Dictionary to hold the Car and the cost of toll relating to that car
        protected static Dictionary<VehicleType, Double> dictionary = new Dictionary<VehicleType, double>();
        protected static int index = 0;
        protected static double[] charge = { 2.00, 2.00, 2.80, 4.10 };
   
        // Fill the dictionary the first time the code is run only
        // Add the Car Type as the key and the toll charge as the value
        static Toll() {
            foreach (VehicleType c in Enum.GetValues(typeof(VehicleType))) {
                dictionary.Add(c, charge[index]);
                index++;
            }
        }

        [Display(Name = "Tick for Electronic Tag")]
        [Required(ErrorMessage = "Is Tag Present?")]
        public bool Tag { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "Car Type Required")]
        public VehicleType VehicleType { get; set; }

        // Using the dictionary, get the VehicleType selected with
        // the corresponding charge. If the vehicle has a tag
        // then apply a 20% discount
        [DataType(DataType.Currency)]
        public double Cost {
            get {
                double cost = 0.0;
                double dir = dictionary[this.VehicleType];
                
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