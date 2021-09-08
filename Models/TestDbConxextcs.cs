using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lec2021.Models
{
    public class TestDbConxextcs : IdentityDbContext<UserTest, IdentityRole<int>,int>
    {
        public DbSet<TestsModel> TestsModels { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonTest> PersonTests { get; set; }
        public DbSet<UserTestAnswer> UserTestAnswer { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Questions> Questions { get; set; }
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
    }
}
