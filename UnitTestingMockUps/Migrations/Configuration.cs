namespace UnitTestingMockUps.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Entity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UnitTestingMockUps.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "UnitTestingMockUps.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Here i make the roles 
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rm.Create(new IdentityRole("admin"));
            rm.Create(new IdentityRole("customer"));

            // get a ref. to the UserManager
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Making one admin and one customer
            // Create an object of the ApplicationUser and provide a username
            var admin1 = new ApplicationUser { UserName = "admin@domain.dk" };
            //var customer1 = new ApplicationUser { UserName = "cus@domain.dk" };
            
            // Add the client1 object to the database through the usermanager (and suply password).
            var result1 = userManager.Create(admin1, "123Password!");
            //var result2 = userManager.Create(customer1, "1Password!");

            // If that does not go well (username could already exist), look up the user instead.
            if (result1.Succeeded == false)
            {
                admin1 = userManager.FindByName("admin@domain.dk");
            }
            /*
            if (result2.Succeeded == false)
            {
                customer1 = userManager.FindByName("cus@domain.dk");
            }
            */

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            try
            {
                // Adding Products
                context.Products.AddOrUpdate(p => p.Name, new ProductModel[]
            {
                new ProductModel
                {
                    Name = "Pistol",
                    ProductPrice = 1299,
                    Instruction = "How to Shout by dummies"
                },
                new ProductModel
                {
                    Name = "Skud",
                    ProductPrice = 299,
                    Instruction = "Arm up, get shoots dude"
                },
                new ProductModel
                {
                    Name = "Kniv",
                    ProductPrice = 599,
                    Instruction = "Stab For Dummies"
                }
            });
                /*
                                // Adding 1 Progress
                                context.Progress.AddOrUpdate(p => p.Name, new ProgressModel[]
                                {
                                    new ProgressModel
                                    {
                                        Name = "Eksamens Krav Semester",
                                        Process = 0,
                                        Task = new TaskModel(),
                                        Tasks = new List<TaskModel>()
                                    }
                                }
                            );

                            // Adding Tasks
                            context.Tasks.AddOrUpdate(t => t.Name, new TaskModel[]
                                {
                                    new TaskModel
                                    {
                                        Name = "MVC",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Entity FrameWork",
                                        Procent = 3,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Dependency Injection",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Unit testing with Mock-ups",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "ViewModels",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Partial Views",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Repositories",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Bootstrap",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Bootstrap - Grid System",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Bootstrap - mediaQueries",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Identity Management",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Less Css",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Scaffolding",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Bundles",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "LinQ 101",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = false,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Html Css",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = true,
                                        ProgressModelId = 1
                                    },
                                    new TaskModel
                                    {
                                        Name = "Git",
                                        Procent = 10,
                                        Progress = context.Progress.Find(0),
                                        TaskDone = true,
                                        ProgressModelId = 1
                                    }
                                }
                            );
                */
                // Save changes to db
                context.SaveChanges();
                Debug.WriteLine("No Catch");
            }
            catch (DbEntityValidationException eEV)
            {
                String catchedErrors = "";
                catchedErrors += "Catched the Validation Error\n";
                foreach(var eve in eEV.EntityValidationErrors)
                {
                    catchedErrors += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                      eve.Entry.Entity.GetType().Name, 
                                      eve.Entry.State
                                     );
                    foreach (var ve in eve.ValidationErrors)
                    {
                        catchedErrors += String.Format("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw new Exception("Caster et eller andet ???\n" + 
                                    "--------------Start--------------\n" + 
                                    catchedErrors + 
                                    "\n--------------End--------------");
            }
            // Assign the role
            // doing this after the change because of the use of id
            userManager.AddToRole(admin1.Id, "admin");
            //userManager.AddToRole(customer1.Id, "customer");

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
