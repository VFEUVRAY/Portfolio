using System;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string List { get; set; }
    }
}