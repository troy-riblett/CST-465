using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465
{
    public class CategoryData : IDataEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}