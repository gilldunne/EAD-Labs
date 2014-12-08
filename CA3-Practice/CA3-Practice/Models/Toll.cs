using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA3_Practice.Models {
    public enum VehicleType { Car, Bus, [Display(Name= "Public Service Vehicle")] PSV, Goods}
    
    public class Toll {
        public double cost = 0.0;
        public const double discount = 0.8;
        public static int index = 0;
        public static Dictionary<VehicleType, Double> dictionary = new Dictionary<VehicleType, double>();
        public static double[] charge = { 2.00, 2.00, 2.80, 4.10};

        static Toll() {
            foreach (VehicleType v in Enum.GetValues(typeof(VehicleType))) {
                dictionary.Add(v, charge[index]);
                index++;
            }
        }

        [Display(Name = "Tick for Electronic Tag")]
        [Required(ErrorMessage = "Is Tag Present?")]
        public bool HasTag { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "Car Type Required")]
        public VehicleType VehicleType { get; set; }

        [DataType(DataType.Currency)]
        public double Cost {
            get {
                double dir = dictionary[this.VehicleType];

                if (HasTag) {
                    cost = dir * discount;
                }
                else {
                    cost = dir;
                }
                return cost;
            }
        }

    }
}