using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBaiHat.Models
{
    public class TacGia
    {
        public TacGia()
        {
            this.BaiHat = new HashSet<BaiHat>();
        }

        [Key]
        public int MaTG { get; set; }
        [Required]
        public string TenTG { get; set; }
        [AllowHtml]
        public string Mota { get; set; }
        public virtual ICollection<BaiHat> BaiHat { get; set; }
    }
}