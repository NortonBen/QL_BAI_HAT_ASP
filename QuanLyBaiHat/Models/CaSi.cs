using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBaiHat.Models
{
    public class CaSi
    {
        public CaSi()
        {
            this.BaiHat = new HashSet<BaiHat>();
        }

        [Key]
        public int MaCS { get; set; }
        [Required]
        public string TenCS { get; set; }
        [AllowHtml]
        public string MaTo { get; set; }

        public virtual ICollection<BaiHat> BaiHat { get; set; }
    }
}