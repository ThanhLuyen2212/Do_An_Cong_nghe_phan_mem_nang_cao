using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;
using System.Data.Entity;

namespace QLThuVien.Controllers
{
    public class HomeController : Controller
    {
        QuanLyThuVienEntities data = new QuanLyThuVienEntities();
        public ActionResult Index()
        {
            return View();
            ViewBag.NewBook = data.Saches.Take(5).OrderByDescending(s => s.IDSach).ToList();

           // muon nhieu nhat 
            string[] idsach = new string[5];
            string id = "select idsach from CT_PM"
            List<string> idsach = data.CT_PM.Take(5).OrderByDescending(s => s.IDSach).ToList();
            ViewBag.MostBorrowBook = data.Saches.Take(5).OrderByDescending((s) => s.IDSach).ToList();


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}