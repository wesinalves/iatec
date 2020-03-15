using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iatec.Models;

namespace iatec.Data
{
    public static class SeedData
    {
        public static void Initialize(DataContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Id  =   1,
                        Name = "admin",
                        Email = "admin@iatec.org",
                        Password = "12345",
                    }
                    
                );

                context.SaveChanges();
            }

            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new Event
                    {
                        Id  =   1,
                        Name = "novo evento 1",
                        Description = "admin@iatec.org",
                        Place = "12345",
                        StartDate = System.DateTime.Parse("2020-03-15"),
                        UserId = 1
                    },
                    new Event
                    {
                        Id  =   1,
                        Name = "admin",
                        Description = "admin@iatec.org",
                        Place = "12345",
                        StartDate = System.DateTime.Parse("2020-03-15"),
                        UserId = 1
                    },
                    new Event
                    {
                        Id  =   1,
                        Name = "admin",
                        Description = "admin@iatec.org",
                        Place = "12345",
                        StartDate = System.DateTime.Parse("2020-03-15"),
                        UserId = 1
                    },
                    new Event
                    {
                        Id  =   1,
                        Name = "admin",
                        Description = "admin@iatec.org",
                        Place = "12345",
                        StartDate = System.DateTime.Parse("2020-03-15"),
                        UserId = 1
                    }
                    
                );

                context.SaveChanges();
            }
            
        }
    }
}