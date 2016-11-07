using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBaiHat.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public int User_id { get; set; }
        public string permission { get; set; }
        [ForeignKey("User_id")]
        public virtual User User { get; set; }
    }
}