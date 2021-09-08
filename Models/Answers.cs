using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    public class Answers:ModelPerent
    {
        public virtual Questions Questions { get; set; }
    }
}
