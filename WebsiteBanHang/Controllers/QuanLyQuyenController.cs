using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    [Authorize(Roles = "QuanTriWeb")]
    public class QuanLyQuyenController : Controller
    {
        dbQuanLyDataContext db = Connect.GetConnect();
        // GET: QuanLyQuyen
        public ActionResult Index()
        {
            return View(db.Quyens.OrderBy(n => n.TenQuyen));
        }

        [HttpGet]
        public ActionResult TaoMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoMoi(Quyen quyen)
        {
            db.Quyens.InsertOnSubmit(quyen);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ChinhSua(string id)
        {
            if (id == "")
            {
                Response.StatusCode = 404;
                return null;
            }
            Quyen quyen = db.Quyens.SingleOrDefault(n => n.MaQuyen == id);
            if(quyen == null)
            {
                return HttpNotFound();
            }

            return View(quyen);
        }
        [HttpPost]
        public ActionResult ChinhSua([Bind(Include = "MaQuyen,TenQuyyen")] Quyen quyen)
        {
            //if (ModelState.IsValid)
            Quyen q =  db.Quyens.SingleOrDefault(n=>n.MaQuyen==quyen.MaQuyen);
            TryUpdateModel(q, new string[] { "MaQuyen", "TenQuyen"});       //ko dc phep doi ma quyen
            db.SubmitChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(string id)
        {
            if (id == "")
            {
                Response.StatusCode = 404;
                return null;
            }
            Quyen quyen = db.Quyens.SingleOrDefault(n => n.MaQuyen == id);

            if(quyen == null)
            {
                return HttpNotFound();
            }

            return View(quyen);
        }

        [HttpPost, ActionName("Xoa")]   //trùng tên
        public ActionResult XacNhanXoa(string id)
        {
            //lấy sp cần chỉnh sửa
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Quyen quyen = db.Quyens.SingleOrDefault(n => n.MaQuyen == id);
            if (quyen == null)
            {
                return HttpNotFound();
            }
            db.Quyens.DeleteOnSubmit(quyen);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }

    }
}