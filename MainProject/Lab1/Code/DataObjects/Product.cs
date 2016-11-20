using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465
{
    public class Product : IDataEntity
    {
        public int ID { get; set; }
        public string Code { get; set;}
        public string Name { get; set; }
        //public CategoryData Category{ get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        // public int MyProperty { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
    }
}