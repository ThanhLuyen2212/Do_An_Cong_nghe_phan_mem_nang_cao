﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Areas.Admin.Controllers
{
    public class AdminSachesController : Controller
    {
        private QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        // GET: Admin/AdminSaches
       
        public ActionResult Index(String tensach)
        {
            if(tensach == null)
            {
                return View(db.Saches.ToList());
            }
            else
            {
                return View(db.Saches.Where(s => s.TenSach == tensach).ToList());
            }
        }

        // GET: Admin/AdminSaches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Admin/AdminSaches/Create
        public ActionResult Create()
        {
            List<TheLoai> list = db.TheLoais.ToList();
            ViewBag.listcate = new SelectList(list, "IDCate", "NameCate", "");

            Sach sach = new Sach();
            return View(sach);
        }

        // POST: Admin/AdminSaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenSach,TheLoai,MoTa,TacGia,NgayXuatBan,SoLuong,HinhAnh")] Sach sach)
        {
            try
            {
                List<TheLoai> list = db.TheLoais.ToList();

                if (sach.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(sach.UploadImage.FileName);
                    string ex = Path.GetExtension(sach.UploadImage.FileName);
                    filename = filename + ex;
                    sach.HinhAnh = "~/Image/" + filename;
                    sach.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Image/"), filename));

                }
                sach.IDSach = "1";
                ViewBag.listcate = new SelectList(list, "IDCate", "NameCate", 1);
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("<script language='javascript' type='text/javascript'>alert ('Vui lòng kiểm tra lại thông tin!');</script>");
            }
        }

        // GET: Admin/AdminSaches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.TheLoai = new SelectList(db.TheLoais, "IDCate", "NameCate", sach.TheLoai);
            return View(sach);
        }

        // POST: Admin/AdminSaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSach,TenSach,TheLoai,MoTa,TacGia,NgayXuatBan,SoLuong,HinhAnh")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TheLoai = new SelectList(db.TheLoais, "IDCate", "NameCate", sach.TheLoai);
            return View(sach);
        }

        // GET: Admin/AdminSaches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Admin/AdminSaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
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