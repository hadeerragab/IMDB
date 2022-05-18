using IMDB.Models;
using IMDB.Data.Static;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace IMDB.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Fname = "Actor 1",
                            Lname="1",
                            age = 20,
                            profilepicURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                             Fname = "Actor ",
                            Lname="2",
                            age = 20,
                            profilepicURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            Fname = "Actor ",
                            Lname="3",
                            age = 20,
                            profilepicURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Fname = "Actor ",
                            Lname="4",
                            age = 20,
                            profilepicURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },

                    });
                    context.SaveChanges();
                }


                if (!context.Directors.Any())
                {
                    context.Directors.AddRange(new List<Director>()
                    {
                        new Director()
                        {
                            Fname = "Director",
                            Lname="1",
                            age = 20,
                            profilepicURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Director()
                        {
                             Fname = "Director ",
                            Lname="2",
                            age = 20,
                            profilepicURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Director()
                        {
                            Fname = "Director ",
                            Lname="3",
                            age = 20,
                            profilepicURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Director()
                        {
                            Fname = "Director ",
                            Lname="4",
                            age = 20,
                            profilepicURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },

                    });
                    context.SaveChanges();
                }




                //movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            name = "Life",
                            dirictorID = 3,
                            imageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",

                        },
                        new Movie()
                        {
                            name = "The Shawshank Redemption",
                            imageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            dirictorID = 1,

                        },
                        new Movie()
                        {
                            name = "Ghost",
                            imageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            dirictorID = 4,
                        },
                        new Movie()
                        {
                            name = "Race",
                            imageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            dirictorID = 2

                        },
                        new Movie()
                        {
                            name = "Scoob",
                            imageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            dirictorID = 3
                        },

                    });
                    context.SaveChanges();
                }
                //actor_movie
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_make_Movie>()
                    {
                        new Actor_make_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_make_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_make_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_make_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },
                    });
                    context.SaveChanges();
                }

                

            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@imdb.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        profilepicURL = "http://dotnethow.net/images/actors/actor-1.jpeg",
                        age = 20
                      
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@imdb.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        profilepicURL = "http://dotnethow.net/images/actors/actor-1.jpeg",
                        age = 20
                        
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }

}
