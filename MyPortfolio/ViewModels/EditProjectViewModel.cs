using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MyPortfolio.Models;
using Microsoft.AspNetCore.Http;

namespace MyPortfolio.ViewModels
{
    public class EditProjectViewModel
    {
        public Project project { get; set; }
        public IFormFile Picture { get; set; }
        public string oldPicture { get; set; }
        public bool Enabled { get; set; }
    }
}