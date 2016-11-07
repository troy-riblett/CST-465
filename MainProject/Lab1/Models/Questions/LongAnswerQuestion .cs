using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST465
{
    public class LongAnswerQuestion : TestQuestion
    {
        [Required(ErrorMessage = "Please answer this question")]
        override public string Answer { get; set; }
    }
}
