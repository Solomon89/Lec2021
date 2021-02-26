using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    [Display(Name = "Тестирование")]
    public class TestsModel:ModelPerent
    {
        [Display(Name = "Название")]
        public override string Name { get => base.Name; set => base.Name = value; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public virtual Person Creator { get; set; }
        public bool isActive { get; set; }
    }
}
