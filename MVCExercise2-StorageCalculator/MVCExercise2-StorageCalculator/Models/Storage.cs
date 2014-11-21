using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCExercise2_StorageCalculator.Models {

    public enum Redundancy { [Display(Name= "Graphically")] Geo, Locally }
    public class Storage {

        const double GeoFirst = 0.125;
        const double GeoSecond = 0.11;
        const double LocFirst = 0.093;
        const double LocSecond = 0.083;

        [Required(ErrorMessage="Required Field")]
        [Range(1, Double.MaxValue, ErrorMessage="Must be larger than 0")]
        [Display(Name = "Average GB usage per month")]
        public double StorageSize { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public Redundancy Redundancy { get; set; }

        [DisplayFormat(DataFormatString= "{0:C}")]
        public double Cost {
            get {
                double cost = 0.0;
                if (Redundancy == Models.Redundancy.Geo) {
                    if (StorageSize > 1000) {
                        cost = ((1000 * GeoFirst) + ((StorageSize - 1000) * GeoSecond));
                    }
                    else {
                        cost = StorageSize * GeoFirst;
                    }
                }
                else {
                    if (StorageSize > 1000) {
                        cost = ((1000 * LocFirst) + ((StorageSize - 1000) * LocSecond));
                    }
                    else {
                        cost = StorageSize * LocFirst;
                    }
                }
                return cost;
            }
        }
    }
}