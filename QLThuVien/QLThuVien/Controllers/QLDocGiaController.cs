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
    public class QLDocGiaController : Controller
    {
        private QuanLyThuVienEntities data = new QuanLyThuVienEntities();

        // GET: QLDocGia
        public ActionResult Index(string _name)
        {
            if (_name == null)
            {
                return View(data.DocGias.ToList());
            }
            else
            {
                return View(data.DocGias.Where(s => s.TenDG.Contains(_name)).ToList());
            }
            
        }

        // GET: QLDocGia/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = data.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // GET: QLDocGia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QLDocGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDG,TenDG,DienThoai,DiaChi,UserName,Password")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                data.DocGias.Add(docGia);
                data.SaveChanges();
                return RedirectToAction("Index","QLDocGia");
            }

            return View(docGia);
        }

       

        // GET: QLDocGia/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = data.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: QLDocGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDG,TenDG,DienThoai,DiaChi,UserName,Password")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                data.Entry(docGia).State = (System.Data.Entity.EntityState)System.Data.EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docGia);
        }

        // GET: QLDocGia/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia =data.DocGias.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: QLDocGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, DocGia dg)
        {
            try{
                DocGia docGia = data.DocGias.Find(id);
                data.DocGias.Remove(docGia);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Độc giả còn đang mượn sách không được xóa!");
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                data.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
