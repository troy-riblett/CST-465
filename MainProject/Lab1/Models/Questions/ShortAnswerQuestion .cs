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
        [Required]
        [MaxLength(100)]
        override public string Answer { get; set; }
    }
}
