using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CST465
{
    public class ProductModel
    {
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        //public CategoryModel Category{ get; set; }
        [Required]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        // public int MyProperty { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

