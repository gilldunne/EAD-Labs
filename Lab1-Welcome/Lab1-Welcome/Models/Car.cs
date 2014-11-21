using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1_Welcome.Models {
    public enum EngineType { Petrol, Diesel, Hybrid }
    public class Car {

        [Key]
        public int CarID { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public double EngineSize { get; set; }
        public EngineType EngineType { get; set; }
    }
}