using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST465
{
    public class ShortAnswerQuestion : TestQuestion
    {
        [Required(ErrorMessage = "Please answer this question")]
        [MaxLength(100, ErrorMessage = "Max of 100 characters, please use fewer")]
        override public string Answer { get; set; }
    }
}
