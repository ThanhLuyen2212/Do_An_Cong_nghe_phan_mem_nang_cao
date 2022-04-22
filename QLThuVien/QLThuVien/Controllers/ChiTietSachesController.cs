using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Controllers
{
    public class ChiTietSachesController : Controller
    {
        private QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        // GET: ChiTietSaches/Index/5
        [HttpGet]
        public ActionResult Index(string idsach)
        {
            var chiTietSaches = db.ChiTietSaches.Include(c => c.Sach);
            if (idsach == null)
            {
                return View(chiTietSaches);
            }
            
            var chiTietSaches1= db.ChiTietSaches.Where(s => s.IDSach.Contains(idsach));

            if(chiTietSaches1 == null )
            {
                return View(chiTietSaches);
            }            
            return View(chiTietSaches1.ToList());
        }
            

        public ActionResult Show(string idsach)
        {
            var chiTietSaches = db.ChiTietSaches.Include(c => c.Sach);
            if (idsach == null)
            {
                return View(chiTietSaches);
            }


            var chiTietSaches1 = db.ChiTietSaches.Where(s => s.IDSach.Contains(idsach));

            if (chiTietSaches1 == null)
            {
                return View(chiTietSaches);
            }

            return View(chiTietSaches1.ToList());
        }



        // GET: ChiTietSaches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSach chiTietSach = db.ChiTietSaches.Find(id);
            if (chiTietSach == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSach);
        }

        // GET: ChiTietSaches/Create
        public ActionResult Create()
        {
            ViewBag.IDSach = new SelectList(db.Saches, "IDSach", "TenSach");
            return View();
        }

        // POST: ChiTietSaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDChiTietSach,IDSach,TinhTrang")] ChiTietSach chiTietSach)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietSaches.Add(chiTietSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDSach = new SelectList(db.Saches, "IDSach", "TenSach", chiTietSach.IDSach);
            return View(chiTietSach);
        }

        // GET: ChiTietSaches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSach chiTietSach = db.ChiTietSaches.Find(id);
            if (chiTietSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDSach = new SelectList(db.Saches, "IDSach", "TenSach", chiTietSach.IDSach);
            return View(chiTietSach);
        }

        // POST: ChiTietSaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDChiTietSach,IDSach,TinhTrang")] ChiTietSach chiTietSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietSach).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDSach = new SelectList(db.Saches, "IDSach", "TenSach", chiTietSach.IDSach);
            return View(chiTietSach);
        }

        // GET: ChiTietSaches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSach chiTietSach = db.ChiTietSaches.Find(id);
            if (chiTietSach == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSach);
        }

        // POST: ChiTietSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietSach chiTietSach = db.ChiTietSaches.Find(id);
            db.ChiTietSaches.Remove(chiTietSach);
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
