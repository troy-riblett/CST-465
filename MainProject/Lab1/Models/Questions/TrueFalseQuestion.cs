using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST465
{
    public class TrueFalseQuestion : TestQuestion
    {
        [Required(ErrorMessage = "Please answer this question")]
        [RegularExpression("^(True|False)$", ErrorMessage = "Please select either True or False")]
        override public string Answer { get; set; }
    }
}
