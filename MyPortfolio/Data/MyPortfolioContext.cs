using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyPortfolio.Areas.Identity.Data;

namespace MyPortfolio.Data
{
    public class MyPortfolioContext : IdentityDbContext<PortfolioUser>
    {
        public MyPortfolioContext (DbContextOptions<MyPortfolioContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Me> Me { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}