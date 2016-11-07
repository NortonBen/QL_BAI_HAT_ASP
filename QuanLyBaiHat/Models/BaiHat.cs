using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBaiHat.Models
{
    public class BaiHat
    {
        [Key]
        public int MaBH { get; set; }
        [Required]
        public string TenBH { get; set; }
        public string url { get; set; }
        public string img { get; set; }
        [AllowHtml]
        public string NoiDung { get; set; }
        [DataType(DataType.Date)]
        public DateTime NamSX { get; set; }
        public string HangSX { get; set; }
        public int MaCS { get; set; }
        public int MaTG { get; set; }
        [ForeignKey("MaTG")]
        public virtual TacGia TacGia { get;set;}
        [ForeignKey("MaCS")]
        public virtual CaSi CaSi { get; set; }

    }
}