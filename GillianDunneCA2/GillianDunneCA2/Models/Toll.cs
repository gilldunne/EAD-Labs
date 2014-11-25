using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GillianDunneCA2.Models {
    public enum CarType {
        Car,
        [Display(Name = "Public Service Vehicle")]
        PSV,
        Bus, Goods
    }
    public class Toll {
        protected static Dictionary<CarType, Double> dictionary = new Dictionary<CarType, double>();
        protected static int index = 0;
        protected static double[] charge = { 2.00, 2.00, 2.80, 4.10 };
   
        static Toll() {
            foreach (CarType c in Enum.GetValues(typeof(CarType))) {
                dictionary.Add(c, charge[index]);
                index++;
            }
        }

        [Display(Name = "Electronic Tag")]
        [Required(ErrorMessage = "Is Tag Present?")]
        public bool Tag { get; set; }

        [Display(Name = "Car Type")]
        [Required(ErrorMessage = "Car Type Required")]
        public CarType CarType { get; set; }

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