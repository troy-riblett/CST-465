﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
using System.Collections.Generic;

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

        [Required]
        public string CategoryName { get; set; }

        public List<CategoryData> AvailableCategories { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public HttpPostedFileWrapper Image { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

