using System;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Models
{
    public class Me
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birth_date { get; set; }
        public string Description { get; set; }

    }
}