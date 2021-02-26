using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    public class Person:ModelPerent
    {
        [Display(Name="Имя")]
        public override string Name { get => base.Name; set => base.Name = value; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public List<TestsModel> TestsModels { get; set; }
    }
}
