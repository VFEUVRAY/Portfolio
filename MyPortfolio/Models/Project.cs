using System;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        public string Picture { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_created { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_updated { get; set; }
        [DataType(DataType.Url)]
        public string Link { get; set; }
        public bool Enabled { get; set; }
    }
}