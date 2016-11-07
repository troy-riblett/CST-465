using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST465
{
    public class MultipleChoiceQuestion : TestQuestion
    {
        [Required(ErrorMessage = "Please select an answer")]
        override public string Answer { get; set; }
        public List<String> Choices { get; set; }
    }
}
