using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    public class PersonTest:ModelPerent
    {
        [JsonIgnore]
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }
        public Person Person { get; set; }
        public TestsModel TestsModel { get; set; }
        public DateTime TestStart { get; private set; }
        public PersonTest()
        {
            TestStart = DateTime.Now;
        }
    }
}
