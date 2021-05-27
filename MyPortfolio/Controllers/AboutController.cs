using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using MyPortfolio.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly MyPortfolioContext _context;
        private readonly IConfiguration _configuration;

        public AboutController(MyPortfolioContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: About
        public async Task<IActionResult> Index()
        {
            var vm = new AboutViewModel();
            vm.me = await _context.Me.FindAsync(1);
            vm.skills = await _context.Skills.ToListAsync();
            //var my_info = await _context.Me.FindAsync(1);
            return View(vm);
        }
    }
}