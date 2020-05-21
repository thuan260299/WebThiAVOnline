using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteHocAVOnline.Models;

namespace WebsiteHocAVOnline.Areas.ADmin.Controllers
{
    public class UserController : Controller
    {
        DBThiTrucTuyenEntities db = new DBThiTrucTuyenEntities();
        // GET: ADmin/User
        public ActionResult Index()
        {
            return View(db.TaiKhoans.ToList());
        }

        [HttpGet]
        public ActionResult DelUser()
        {
            return View(db.TaiKhoans.ToList());
        }

        [HttpPost]
        public ActionResult DelUser(int id)
        {
            TaiKhoan _id = db.TaiKhoans.Find(id);

            db.TaiKhoans.Remove(_id);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}