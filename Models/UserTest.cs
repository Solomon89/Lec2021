using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Lec2021.Models
{
    public class UserTest: IdentityUser<int>
    {
        public List<TestsModel> Tests { get; set; }
    }
}
