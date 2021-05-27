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
    public class ProjectsController : Controller
    {
        private readonly MyPortfolioContext _context;
        private readonly IConfiguration _configuration;

        public ProjectsController(MyPortfolioContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Picture,Date_created,Date_updated,Link,Enabled")] Project project, 
        IFormFile picture)
        {
            project.Date_created = DateTime.Now;
            project.Date_updated = project.Date_created;
            if (ModelState.IsValid)
            {
                if (picture != null && picture.Length > 0){
                    string rootpath = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey); //Get ABSOLUTE content root
                    FileInfo info = new FileInfo(picture.FileName); //Enables getting access to infos like extension
                    var pictureName = (DateTime.Now.Ticks) + info.Extension; //Create name of image that will be created
                    var picturePath = Path.Combine(rootpath, @"wwwroot/images", pictureName); //Create absolute path of image for creation
                    FileStream filestream = new FileStream(picturePath, FileMode.Create); //Open a stream for data to be passed in
                    project.Picture = Path.Combine(@"images", pictureName); //Path that will be saved in Database, do not add full path because views will only have access to static files directory root, not PC root
                    await picture.CopyToAsync(filestream); //Copy file data into local storage
                }
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            var vm = new EditProjectViewModel{
                project = project,
                Enabled = project.Enabled,
                oldPicture = project.Picture,
            };
            return View(vm);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProjectViewModel vm)
        {
            var picture = vm.Picture;
            var project = vm.project;
            if (id != project.Id)
            {
                return NotFound();
            }

            bool pictureHasChanged = false;
            //var date = await _context.Projects.FindAsync(id);
            //project.Date_created = (System.DateTime) _context.Entry(project).Property(obj => obj.Date_created);
            project.Date_updated = DateTime.Now;
            project.Enabled = vm.Enabled;
            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (picture != null && picture.Length > 0) {
                        //SAVE NEW PICTURE

                        FileInfo info = new FileInfo(picture.FileName);
                        var rootpath = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
                        var picutreName = DateTime.Now.Ticks + info.Extension;
                        var picturePath = Path.Combine(rootpath, @"wwwroot/images", picutreName);
                        FileStream stream = new FileStream(picturePath, FileMode.Create);
                        project.Picture = Path.Combine(@"images", picutreName);
                        await picture.CopyToAsync(stream);
                        pictureHasChanged = true;

                        // DELETE OLD PICTURE

                        picturePath = Path.Combine(rootpath, @"wwwroot", vm.oldPicture);
                        System.IO.File.Delete(picturePath);
                    }
                    _context.Update(project);
                    _context.Entry(project).Property(obj => obj.Date_created).IsModified = false;
                    if (!pictureHasChanged)
                        _context.Entry(project).Property(obj => obj.Picture).IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (!String.IsNullOrEmpty(project.Picture)) {
                var picturePath = Path.Combine(_configuration.GetValue<string>(WebHostDefaults.ContentRootKey), @"wwwroot", project.Picture);
                System.IO.File.Delete(picturePath);
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
