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
        [Required]
        override public string Answer { get; set; }
    }
}
