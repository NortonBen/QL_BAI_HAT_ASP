using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBaiHat.Models;

namespace QuanLyBaiHat.Controllers
{
    public class BaiHatController : Controller
    {
        private DataContext db = new DataContext();

        // GET: BaiHat
        public ActionResult Index()
        {
            var baiHats = db.BaiHats.Include(b => b.CaSi).Include(b => b.TacGia);
            return View(baiHats.ToList());
        }

        // GET: BaiHat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat baiHat = db.BaiHats.Find(id);
            if (baiHat == null)
            {
                return HttpNotFound();
            }
            return View(baiHat);
        }

        // GET: BaiHat/Create
        public ActionResult Create()
        {
            ViewBag.MaCS = new SelectList(db.CaSis, "MaCS", "TenCS");
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG");
            return View();
        }

        // POST: BaiHat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBH,TenBH,url,img,NoiDung,NamSX,HangSX,MaCS,MaTG")] BaiHat baiHat)
        {
            if (ModelState.IsValid)
            {
                db.BaiHats.Add(baiHat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCS = new SelectList(db.CaSis, "MaCS", "TenCS", baiHat.MaCS);
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", baiHat.MaTG);
            return View(baiHat);
        }

        // GET: BaiHat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat baiHat = db.BaiHats.Find(id);
            if (baiHat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCS = new SelectList(db.CaSis, "MaCS", "TenCS", baiHat.MaCS);
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", baiHat.MaTG);
            return View(baiHat);
        }

        // POST: BaiHat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBH,TenBH,url,img,NoiDung,NamSX,HangSX,MaCS,MaTG")] BaiHat baiHat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiHat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCS = new SelectList(db.CaSis, "MaCS", "TenCS", baiHat.MaCS);
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", baiHat.MaTG);
            return View(baiHat);
        }

        // GET: BaiHat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat baiHat = db.BaiHats.Find(id);
            if (baiHat == null)
            {
                return HttpNotFound();
            }
            return View(baiHat);
        }

        // POST: BaiHat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiHat baiHat = db.BaiHats.Find(id);
            db.BaiHats.Remove(baiHat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
