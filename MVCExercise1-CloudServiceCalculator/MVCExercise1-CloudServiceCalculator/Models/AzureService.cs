using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCExercise1_CloudServiceCalculator.Models {
    public class AzureService {

        public static String[] SizeDescriptions {
            get {
                return new String[] { "Very Small", "Small", "Medium", "Large", "Very Large", "A5", "A6" };
            }
        }

        public static double[] SizePrices {
            get {
                return new double[] { 0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80 };
            }
        }

        // A cloud service must have at least 2 instances
        [Required(ErrorMessage = "Required field!")]
        [Range(2, Int32.MaxValue, ErrorMessage = "At least 2 instances required")]
        [DisplayName("Number of Instances")]
        public int NumInstances { get; set; }

        // The size of the instance
        [Required(ErrorMessage = "Required field!")]
        [DisplayName("Instance Size")]
        public String InstanceSize { get; set; }

        // Calculate the yearly cost
        public double Cost {
            get {
                int size = 0;
                for (int i = 0; i < AzureService.SizeDescriptions.Length; i++) {
                    if (AzureService.SizeDescriptions[i] == this.InstanceSize) {
                        size = i;
                        break;
                    }
                }
                double hourlyPrice = NumInstances * InstanceSize[size];
                double dailyPrice = hourlyPrice * 24;
                double yearlyPrice;

                if (DateTime.IsLeapYear(DateTime.Now.Year)) {
                    yearlyPrice = dailyPrice * 366;
                }
                else {
                    yearlyPrice = dailyPrice * 365;
                }
                return yearlyPrice;
            }
        }
    }
}