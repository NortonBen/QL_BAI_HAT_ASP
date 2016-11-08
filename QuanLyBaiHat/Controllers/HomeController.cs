using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBaiHat.Models;
using QuanLyBaiHat.Helper;

namespace QuanLyBaiHat.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int page = 0, int part =16, string sort = "Id", string typesort = "asc")
        {
            var total = db.BaiHats.Count() / part;
            
            var paginate = Paginate.create(page, part, total);
            var _qr = db.BaiHats.Where(
                delegate (BaiHat bh) {
                    if (Request["search"] == null)
                    {
                        return true;
                    }
                    if (bh.CaSi.TenCS.ToUpper().Contains(Request["search"].ToUpper()))
                    {
                        return true;
                    }
                    if (bh.TacGia.TenTG.ToUpper().Contains(Request["search"].ToUpper()))
                    {
                        return true;
                    }
                    if (bh.TenBH.ToUpper().Contains(Request["search"].ToUpper()))
                    {
                        return true;
                    }
                    if (bh.NoiDung.ToUpper().Contains(Request["search"].ToUpper()))
                    {
                        return true;
                    }
                    return false;
                });
            
            var qr = _qr.OrderBy(p => p.MaBH);
            if(sort == "Ten")
            {
                qr = _qr.OrderBy(p => p.TenBH);
            }
            if (sort == "Ten")
            {
                qr = _qr.OrderBy(p => p.TenBH);
            }
            if(sort == "namXB")
            {
                qr = _qr.OrderBy(p => p.NamSX);
            }
            if (sort == "hangSX")
            {
                qr = _qr.OrderBy(p => p.HangSX);
            }
           

            var  meta = _qr.Skip(paginate["page"] * part).Take((paginate["page"] + 1) * part);
            ViewBag.paginate = paginate;

            var data = meta.ToList();
            return View(data);
            
        }

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string username, string password)
        {
            User user = db.Users.Where(t => t.username == username && t.password == password).SingleOrDefault();
            if(user != null)
            {
                Session["auth"] = user;
                return RedirectToAction("index");
            }
            ViewBag.error = "Tài Khoản hoặc Mật Khẩu Sai";
            return View();
        }

        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult register(User user,string repassword = null)
        {
            if (ModelState.IsValid)
            {
                if(user.password != repassword)
                {
                    ViewBag.error = "Mật khẩu không khớp";
                    return View(user);
                }
                db.Users.Add(user);
                db.SaveChanges();
                Role _role = new Role();
                _role.permission = "user";
                _role.User_id = user.Id;
                db.Roles.Add(_role);
                db.SaveChanges();
                return RedirectToAction("login");
            }

            return View(user);
        }

        public ActionResult logout()
        {
            Session["auth"] = null;
            return RedirectToAction("login");
        }

        public ActionResult about()
        {
            return View();
        }
    }
}