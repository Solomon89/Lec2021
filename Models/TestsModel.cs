using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    public class TestsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public bool isActive { get; set; }
    }
}
