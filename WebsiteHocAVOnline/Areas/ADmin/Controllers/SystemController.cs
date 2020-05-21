using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteHocAVOnline.Models;

namespace WebsiteHocAVOnline.Areas.ADmin.Controllers
{
    public class SystemController : Controller
    {
        // GET: ADmin/System
        DBThiTrucTuyenEntities db = new DBThiTrucTuyenEntities();

        #region Quản Lý

        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }
        [HttpGet]
        public ActionResult AddAccount() // Thêm tài khoản quản trị
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAccount(Admin adGet)
        {
            //Session["AD_ADMIN"] = 1;
            try
            {
                db.Admins.Add(adGet);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DelAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DelAccount(int id)
        {
            Admin _id = db.Admins.Find(id);

            db.Admins.Remove(_id);

            db.SaveChanges();

            return RedirectToAction("Index");

         }

        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            return View(db.Admins.Where(Model => Model.ID == id).FirstOrDefault());
        }


        public ActionResult EditAccount(Admin adGet)
        {
            var adList = db.Admins.Where(Model => Model.ID == adGet.ID).FirstOrDefault();

            adList.TenTK = adGet.TenTK;

            adList.MatKhau = adGet.MatKhau;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Đăng nhập - Đăng xuất 

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string taikhoan = form["taikhoan"].ToString();

            string matkhau = form["matkhau"].ToString();

            Admin adminVar = db.Admins.Where(Model => Model.TenTK == taikhoan && Model.MatKhau == matkhau).SingleOrDefault();

            if (adminVar != null)
            {
                Session["ADMIN"] = adminVar.ID;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "* Sai tài khoản hoặc mật khẩu!";
            }

            return View();
        }


        public ActionResult Logout()
        {
            Session.Remove("ADMIN");

            Session.Abandon();

            return RedirectToAction("Login");
        }

        #endregion
    }
}


