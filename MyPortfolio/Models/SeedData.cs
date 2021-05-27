using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyPortfolio.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using MyPortfolio.Areas.Identity.Data;


namespace MyPortfolio.Models
{
    public class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider, string testPwd)
        {
            SeedPortfolioDB(serviceProvider);
            var adminId = await EnsureUser(serviceProvider, testPwd, "admin@admin.ad");
            var roleId = await CreateRole(serviceProvider, "admin");
            await AssignRoleToUser(serviceProvider, adminId, "admin");
        }
        public static void SeedPortfolioDB(IServiceProvider serviceProvider)
        {
            using (var context = new MyPortfolioContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyPortfolioContext>>()))
            {
                /*
                //look if there is already an entry in Me table
                if (context.Me.Any())
                {
                    return ; //Don't do anything, seeding already done
                }
                */
                if (!context.Me.Any())
                {
                    context.Me.AddRange(
                       new Me
                        {
                            Firstname = "Vaillant",
                            Lastname = "FEUVRAY",
                            Email = "feuvra_v@etna-alternance.net",
                            Phone = "+33 7 54 17 37 75",
                            Address = "75013",
                            City = "Paris",
                            Country = "France",
                            Birth_date = DateTime.Parse("1998-2-23"),
                            Description = "I am currently attending programming/IT Bachelor cycle at ETNA (along with a Master's degree afterward) with the goal of becoming a Software Engineer. Looking for challenges, I aim to sharpen my problem solving and logic skills and their use in computer programming. I am particularly interested by heavy applications developpement as well and software optimization."
                        }
                    );
                }
                if (!context.Skills.Any())
                {
                    context.Skills.AddRange(
                        new Skill
                        {
                            Type = "Software Programming",
                            List = "- C / C++ / C# / Python"
                        },
                        new Skill
                        {
                            Type = "Web",
                            List = "- HTML / CSS / ASP.NET / PHP + Framework Laravel / Javascript + Google App script"
                        },
                        new Skill
                        {
                            Type = "Other IT",
                            List = "- Git / Unix"
                        },
                        new Skill
                        {
                            Type = "Languages",
                            List = "- Fluent English / Fluent French"
                        }
                    );
                }
                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(
                        new Project
                        {
                            Title = "Resume - Python/Django",
                            Description = "My resume made in Python with Django Framework, along with a dockerfile in the git repository",
                            Picture = "images/resume.gif",
                            Date_created = DateTime.Now,
                            Date_updated = DateTime.Now,
                            Link = "https://github.com/VFEUVRAY/RESUME",
                            Enabled = true
                        },
                        new Project
                        {
                            Title = "Hyrule Castle - Bash",
                            Description = "Turn by turn console game developed in bash, with characters and enemies randomly generated from csv files, multiple actions and boss fights",
                            Picture = "images/hyrulecastle.gif",
                            Date_created = DateTime.Now,
                            Date_updated = DateTime.Now,
                            Link = "https://github.com/VFEUVRAY/Hyrule-Castle-Pool",
                            Enabled = true
                        },
                        new Project
                        {
                            Title = "MyCrd - C",
                            Description = "Text file reading program, handling a few types of instructions, saving values and in double linked list in order to handle, reassign and delete them depending on instructions read in file, along with leakless memory handling.",
                            Picture = "images/mycrd.gif",
                            Date_created = DateTime.Now,
                            Date_updated = DateTime.Now,
                            Link = "https://github.com/VFEUVRAY/my_crd",
                            Enabled = true
                        },
                        new Project
                        {
                            Title = "Page Bleue / Phonebook - PHP with Laravel",
                            Description = "Address book type website with contact informations of Enterprises and their Collaborators. All information organised in MySQL database.",
                            Picture = "images/phonebook.gif",
                            Date_created = DateTime.Now,
                            Date_updated = DateTime.Now,
                            Link = "https://github.com/VFEUVRAY/MyPhoneBook",
                            Enabled = true
                        },
                        new Project
                        {
                            Title = "Online ranked ladder via automated Google Sheet",
                            Description = "Ranked ladder of competitive players build from in game scores, with the data being handled in a Google Sheet with scripts. Splitting of administrator and user functionnalities on dedicated sheets.Multiple features such as adding new players, reporting a played challenge score, user sheet update from administrator sheet, automatic split of players in leagues depending on total scores, complete history of past challenges.",
                            Picture = "images/rft.gif",
                            Date_created = DateTime.Now,
                            Date_updated = DateTime.Now,
                            Link = "https://github.com/VFEUVRAY/RFT",
                            Enabled = true
                        },
                        new Project
                        {
                            Title = "Minishell - C",
                            Description = "Developement of a Shell console with integration of essential bash functions such as : LS, CD, RM, MKDIR, SUDO. Error handling, user prompt. Memory handling and preventing leaks.",
                            Picture = "",
                            Date_created = DateTime.Now,
                            Date_updated = DateTime.Now,
                            Link = "",
                            Enabled = true
                        },
                        new Project
                        {
                            Title = "Hack'n Slash type game - Python + Pygame",
                            Description = "Action game with infinite waves of increasingly numerous, randomly generated enemies. Several actions such as aerial combat, projectile throwing.",
                            Picture = "",
                            Date_created = DateTime.Now,
                            Date_updated = DateTime.Now,
                            Link = "",
                            Enabled = true
                        }
                    );
                }
                context.SaveChanges();
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,string testPwd, string username)
        {
            var userManager = serviceProvider.GetService<UserManager<PortfolioUser>>();

            var user = await userManager.FindByNameAsync(username);
            if (user == null){
                user = new PortfolioUser{
                    UserName = username,
                    Email = username,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testPwd);
            }

            if (user == null) //user creation has failed, likely because of password problems
            {
                throw new Exception("The password is probably not strong enough");
            }
            return user.Id;
        }

        private static async Task<IdentityResult> CreateRole(IServiceProvider serviceProvider, string rolename)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            IdentityResult roleid = null;

            if (roleManager == null)
            {
                throw new Exception("Role Manager could not be found (SeeData::CreateRole)");
            }
            if (!await roleManager.RoleExistsAsync(rolename)) {
                roleid = await roleManager.CreateAsync(new IdentityRole(rolename));
                if (roleid == null) {
                    throw new Exception("Error occured while creating role (This error occurs after role manager has been found)");
                }
            }
            return roleid;
        }

        public static async Task AssignRoleToUser(IServiceProvider serviceProvider, string userId, string roleName)
        {
            var userManager = serviceProvider.GetService<UserManager<PortfolioUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            var user = await userManager.FindByIdAsync(userId);
            var role = await roleManager.FindByNameAsync(roleName);
            if (user == null || role == null) {
                throw new Exception("Something wrong happened while creating either role or user");
            }
            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}
