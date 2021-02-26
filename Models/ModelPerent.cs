using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    public class ModelPerent
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
