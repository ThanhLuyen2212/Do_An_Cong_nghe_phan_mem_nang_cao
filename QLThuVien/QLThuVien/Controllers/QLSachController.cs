using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;
using System.Data;
using System.IO;

namespace QLThuVien.Controllers
{
    public class QLSachController : Controller
    {
        QuanLyThuVienEntities data = new QuanLyThuVienEntities();
        // GET: QLSach
        public ActionResult Index(string tensach)
        {
            if(tensach == null)
            {
                return View(data.Saches.ToList());
            }
            else
            {
                return View(data.Saches.Where(s => s.TenSach.Contains(tensach)).ToList());
            }
        }

        public ActionResult Details(int id)
        {
            return View(data.Saches.Where(s => s.IDSach == id.ToString()).FirstOrDefault());
        }

        public ActionResult Create()
        {
            List<TheLoai> list = data.TheLoais.ToList();
            ViewBag.listcate = new SelectList(list, "IDCate", "NameCate");

            Sach sach = new Sach();
            return View(sach);
        }

        [HttpPost]
        public ActionResult Create(Sach sach)
        {
            try
            {
                List<TheLoai> list = data.TheLoais.ToList();
                if (sach.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(sach.UploadImage.FileName);
                    string ex = Path.GetExtension(sach.UploadImage.FileName);
                    filename = filename + ex;
                    sach.HinhAnh = "~/Image/" + filename;
                    sach.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Image/"), filename));

                }
                ViewBag.listcate = new SelectList(list, "IDCate", "NameCate", 1);
                data.Saches.Add(sach);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("<script language='javascript' type='text/javascript'>alert     ('Vui lòng kiểm tra lại thông tin!');</script>");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Sach sach)
        {

            // TODO: Add update logic here
            // sach = data.Saches.Where(s => s.IDSach == id).FirstOrDefault();
            data.Entry(sach).State = System.Data.Entity.EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(string id)
        {
            return View(data.Saches.Where(s => s.IDSach == id.ToString()).FirstOrDefault());
        }

        // POST: QLSach/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Sach sach)
        {
            try
            {
                // TODO: Add delete logic here
                sach = data.Saches.Where(s => s.IDSach == id.ToString()).FirstOrDefault();
                data.Saches.Remove(sach);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Bạn Không được xóa! Sách còn đang trong quá trình mượn");
            }


        }
    }
}