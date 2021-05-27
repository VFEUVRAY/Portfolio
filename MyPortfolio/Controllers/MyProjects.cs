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
using Microsoft.AspNetCore.Authorization;

namespace MyPortfolio.Controllers
{
    public class MyProjectsController : Controller
    {
        private readonly MyPortfolioContext _context;
        private readonly IConfiguration _configuration;
        public MyProjectsController(MyPortfolioContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [AllowAnonymous]
        //  GET: MyProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects
                                    .Where(obj => obj.Enabled == true)
                                    .ToListAsync());
        }
    }
}