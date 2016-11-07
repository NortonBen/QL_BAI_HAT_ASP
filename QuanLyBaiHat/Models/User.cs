using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBaiHat.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string username {get;set;}
        [Required]
        public string password { get; set; }
        public string email { get; set; }

    }
}