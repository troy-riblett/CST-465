using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CST465
{
    public class TestQuestion
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public string Question { get; set; }
        public virtual string Answer { get; set; }
    }
}
