using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAPrep.Models {
    public enum Size { 
        [Display(Name="Very Small")] VSmall, Small,
        Medium, Large, [Display(Name="Very Large")]
        VLarge, A6, A7
    }
    public class CloudService {
        protected static Dictionary<Size, Double> dictionary = new Dictionary<Size, double>();
        protected static int index = 0;
        protected static double[] price = { .02, .08, .16, .32, .64, .90, 1.80 };

        static CloudService() {
            foreach (Size s in Enum.GetValues(typeof(Size))) {
                dictionary.Add(s, price[index]);
                index++;
            }
        }

        [Display(Name="No of Instances")]
        [Required(ErrorMessage="Number of Instances Required")]
        [Range(2, Int32.MaxValue, ErrorMessage="Must be greater than 1")]
        public int NumInstances { get; set; }

        [Display(Name = "Size of Instances")]
        [Required(ErrorMessage = "Size of Instances Required")]
        public Size Size { get; set; }

        [DataType(DataType.Currency)]
        public double Cost {
            get {
                double cost = 0.0;

                double dir = dictionary[this.Size];
                cost = dir * 24 * NumInstances;

                if (DateTime.IsLeapYear(DateTime.Now.Year)) {
                    cost *= 366;
                }
                else {
                    cost *= 365;
                }
                return cost;
            }
        }
    }
}