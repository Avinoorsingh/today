using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class employee
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string fname { get; set; }
        [Required]
        public string lname { get; set; }
        [Required]
        public string country { get; set; }
        public string freq { get; set; }
    }
}
