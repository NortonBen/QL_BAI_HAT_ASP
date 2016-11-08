using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBaiHat.Models;

namespace QuanLyBaiHat.Controllers
{
    public class SingleController : Controller
    {
        DataContext db = new DataContext();
        // GET: Single
        public ActionResult Index(int id)
        {
            var bh = db.BaiHats.Find(id);
            if(bh == null)
            {
                return RedirectToAction("index", "Home");
            }
            return View(bh);
        }
    }
}