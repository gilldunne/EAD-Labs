using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1_Welcome.Models {
    public class Message {
        [Key]
        public int MessageID { get; set; }

        [Required(ErrorMessage = "Number must not be blank!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Number must be 10 digits long")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Number must be 10 digits long")]
        [DisplayName("To")]
        public String MobileNumber { get; set; }

        [Required(ErrorMessage = "Message must not be blank!")]
        [StringLength(140, ErrorMessage = "Message must be no more than 140 characters long")]
        [DisplayName("Message")]
        public String Content { get; set; }
    }
}