using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST465
{
    public class ContactModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [RegularExpression("(\\(\\d{3}\\)|\\d{3}\\-)\\d{3}\\-\\d{4}", ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}