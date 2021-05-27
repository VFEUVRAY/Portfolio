using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using MyPortfolio.Models;

namespace MyPortfolio.ViewModels
{
    public class AboutViewModel
    {
        public Me me { get; set; }
        public List<Skill> skills { get; set; }
    }
}