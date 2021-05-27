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
using MyPortfolio.ViewModels;

namespace MyPortfolio.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private MyPortfolioContext _context;
        private IConfiguration _configuration;
        public AdminController(MyPortfolioContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //GET: Admin
        public async Task<IActionResult> Index()
        {
            var viewModel = new AdminViewModel();
            viewModel.Projects = await _context.Projects.ToListAsync();
            return View(viewModel);
        }


        //POST: Admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AdminViewModel viewModel)
        {
            object routeValue = viewModel.projectId;
            if (viewModel.edit != null)
                return RedirectToAction("Edit", "Projects", new { id = viewModel.projectId });
            else if (viewModel.delete != null)
                return RedirectToAction("Delete", "Projects", new { id = viewModel.projectId });
            return RedirectToAction("Index", "Admin");
            //return viewModel.choice;
        }
    }
}