using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CAPrep2.Models {
    public enum Redundancy { [Display(Name="Geographical")] Geo, Locally}
    public class Storage {
        const double geoFirst = .125;
        const double geoSec = .11; 
        const double locFirst = .093;
        const double locSec = .083;

        [Required(ErrorMessage="Required Field")]
        [Range(1, Int32.MaxValue, ErrorMessage="Must be greater than 0")]
        [Display(Name="GB per Month")]
        public int Size { get; set; }

        [Required(ErrorMessage="Required Field")]
        public Redundancy Redundancy { get; set; }

        [DataType(DataType.Currency)]
        public double Cost {
            get {
                double cost = 0.0;
                if (Redundancy == Redundancy.Geo) {
                    if (Size > 1000) {
                        cost = (geoFirst * 1000) + ((Size - 1000) * geoSec);
                    }
                    else {
                        cost = geoFirst * Size;
                    }
                }
                if (Redundancy == Redundancy.Locally) {
                    if (Size > 1000) {
                        cost = (locFirst * 1000) + ((Size - 1000) * locSec);
                    }
                    else {
                        cost = locFirst * Size;
                    }
                }
                return cost;
            }
        }
    }
}