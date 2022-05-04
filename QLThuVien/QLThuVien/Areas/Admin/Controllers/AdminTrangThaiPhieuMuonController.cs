using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Areas.Admin.Controllers
{
    public class AdminTrangThaiPhieuMuonController : Controller
    {
        private QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        // GET: Admin/AdminTrangThaiPhieuMuon
        public ActionResult Index()
        {
            return View(db.TrangThais.ToList());
        }

        // GET: Admin/AdminTrangThaiPhieuMuon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThai trangThai = db.TrangThais.Find(id);
            if (trangThai == null)
            {
                return HttpNotFound();
            }
            return View(trangThai);
        }

        // GET: Admin/AdminTrangThaiPhieuMuon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminTrangThaiPhieuMuon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDTT,TT")] TrangThai trangThai)
        {
            if (ModelState.IsValid)
            {
                db.TrangThais.Add(trangThai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trangThai);
        }

        // GET: Admin/AdminTrangThaiPhieuMuon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThai trangThai = db.TrangThais.Find(id);
            if (trangThai == null)
            {
                return HttpNotFound();
            }
            return View(trangThai);
        }

        // POST: Admin/AdminTrangThaiPhieuMuon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDTT,TT")] TrangThai trangThai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trangThai).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trangThai);
        }

        // GET: Admin/AdminTrangThaiPhieuMuon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrangThai trangThai = db.TrangThais.Find(id);
            if (trangThai == null)
            {
                return HttpNotFound();
            }
            return View(trangThai);
        }

        // POST: Admin/AdminTrangThaiPhieuMuon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TrangThai trangThai = db.TrangThais.Find(id);
            db.TrangThais.Remove(trangThai);
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
