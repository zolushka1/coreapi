using coreapi.BusinessObjects.NonDC;
using coreapi.DbConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace coreapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Лог үүсгэх 
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger) { _logger = logger; }

        // (User) Хэрэглэгчидийн мэдээлэлтэй холбоотой сервисүүд

        [HttpGet(Name = "Users")]
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            var options = new DbContextOptionsBuilder<MSSQLDbContext>()
                .UseSqlServer("YourConnectionString")
                .Options;

            using (var dbContext = new MSSQLDbContext(options))
            {
                try
                {
                    // Retrieve data
                    users = dbContext.Users.ToList();
                    foreach (var user in users)
                    {
                        Console.WriteLine($"ID: {user.Id}, Name: {user.Username}, Age: {user.Age}");
                    }

                    // Insert new data
                    var newUser = new User { Id = 15923, Username = "John Doe", Password = "Piasworda", Age = 26, Email = "example@yahoo.com", Phone = "88881517" };
                    dbContext.Users.Add(newUser);
                    dbContext.SaveChanges();

                    Console.WriteLine("Data inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return users;
        }

        [HttpGet(Name = "GetUser")]
        public User GetUser()
        {
            var user = new User()
            {
                Username = "Zoloo",
                Password = "nuuts ug",
                Age = 24,
                Email = "zolooolzii13@gmail.com",
                Phone = "88048113",
            };
            return user;
        }
    }
}
