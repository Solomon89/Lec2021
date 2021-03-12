using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Models
{
    /*public class TestDbConxextcs:DbContext
    {
        public DbSet<TestsModel> TestsModels { get; set; }
        public DbSet<Person> People { get; set; }
        public TestDbConxextcs(DbContextOptions<TestDbConxextcs> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
           if (!TestsModels.Any())
            {
                TestsModels.Add(new TestsModel
                {
                    Name = "Тест 1",
                    Description = "ывпщмлыоващплыоавщ  ",
                    isActive = true
                });
                TestsModels.Add(new TestsModel
                {
                    Name = "Тест 3",
                    Description = "ывпщмлыоващплыоавщ  werwer",
                    isActive = false
                });
                SaveChanges();
            }
        }
    }*/
}
