﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST465
{
    public class AnsweredQuestion
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
