using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    public class Questions:ModelPerent
    {
        public virtual TestsModel TestsModel { get; set; }
    }
}
