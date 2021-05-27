using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MyPortfolio.Models;

namespace MyPortfolio.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public int projectId { get; set; }
        public string edit { get; set; }
        public string delete { get; set; }
    }
}