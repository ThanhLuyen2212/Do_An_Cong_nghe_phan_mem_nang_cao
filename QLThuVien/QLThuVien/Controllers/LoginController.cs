using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThuVien.Models;

namespace QLThuVien.Controllers
{
    public class LoginController : Controller
    {
        QuanLyThuVienEntities data = new QuanLyThuVienEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAcc(DocGia user)
        {
            var check = data.DocGias.Where(s => s.UserName == user.UserName && s.Password == user.Password).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfor = "Sai thông tin tài khoản";
                return View("Index");
            }
            else
            {
                data.Configuration.ValidateOnSaveEnabled = false;
                Session["UserNmae"] = user.UserName;
                Session["Password"] = user.Password;
                return RedirectToAction("Index", "ListBook");
            }
        }

        public ActionResult IndexAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(DangNhap admin)
        {
            var check = data.DangNhaps.Where(s => s.UserName == admin.UserName && s.Password == admin.Password).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai thông tin tài khoản";
                return View("Index");
            }
            else
            {
                data.Configuration.ValidateOnSaveEnabled = false;
                Session["NameUser"] = admin.UserName;
                Session["Password"] = admin.Password;
                return RedirectToAction("Index", "QLDocGia");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Resister(DocGia user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = data.DocGias.Where(s => s.IDDG == user.IDDG).FirstOrDefault();
                    if (check == null)
                    {
                        /*Disable entity validation tắt xác thực thực thể*/
                        data.Configuration.ValidateOnSaveEnabled = false;
                        data.DocGias.Add(user);
                        data.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorRegister = "ID này đã tồn tại";
                        return View();
                    }
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "Vui lòng nhập đầy đủ thông tin";
            }
            return View();
        }

    }
}