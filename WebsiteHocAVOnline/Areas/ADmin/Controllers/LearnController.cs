using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteHocAVOnline.Models;

namespace WebsiteHocAVOnline.Areas.ADmin.Controllers
{
    public class LearnController : Controller
    {
        // GET: ADmin/Learn
        DBThiTrucTuyenEntities db = new DBThiTrucTuyenEntities();

        public ActionResult Index(int page = 1, int pageSize = 8)
        {

            if (Session["ADMIN"] == null)
            {
                return RedirectToAction("Login");
            }

            Learnning learning = new Learnning();

            var model = learning.NumberPagePagination(page, pageSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult AddLearn()
        {

            if (Session["ADMIN"] == null)
            {
                return RedirectToAction("Login");
            }

            List<Category> list = db.Categories.ToList();

            ViewBag.List = new SelectList(list, "ID_Category", "TênCategory");

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddLearn(Learning leGet)
        {
            if (Session["ADMIN"] == null)
            {
                return RedirectToAction("Login");
            }

            List<Category> list = db.Categories.ToList();

            ViewBag.List = new SelectList(list, "ID_Category", "TênCategory");

            try
            {
                db.Learnings.Add(leGet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult DelLearn(int id)
        {
            Learning _id = db.Learnings.Find(id);

            db.Learnings.Remove(_id);

            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditLearn(int id)
        {
            List<Category> list = db.Categories.ToList();

            ViewBag.List = new SelectList(list, "ID_Category", "TênCategory");

            var lst = db.Learnings.Where(model => model.ID_BaiHoc == id).FirstOrDefault();

            return View(lst);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditLearn(Learning leGet)
        {

            List<Category> list = db.Categories.ToList();

            ViewBag.List = new SelectList(list, "ID_Category", "TênCategory");

            try
            {

                var leList = db.Learnings.Where(model => model.ID_BaiHoc == leGet.ID_BaiHoc).FirstOrDefault();

                leList.TenBaiHoc = leGet.TenBaiHoc;

                leList.Link = leGet.Link;

                leList.MoTa = leGet.MoTa;

                leList.ID_Category = leGet.ID_Category;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}