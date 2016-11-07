using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBaiHat.Models
{
    public class Media
    {
        [Key]
        public int Id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string extension { get; set; }
        public DateTime date { get; set; }
        public long size { get; set; }
        public string type { get; set; }
    }
}