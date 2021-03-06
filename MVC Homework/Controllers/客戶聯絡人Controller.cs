using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Homework.Models;

namespace MVC_Homework.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        private DBModel db = new DBModel();

        // GET: 客戶聯絡人
        public ActionResult Index(string sortOrder) //可是理論是上已經被隱藏的客戶不該在這裡被看到
        {
            ViewBag.jnameParm = sortOrder == "jname" ? "jname_desc" : "jname";
            ViewBag.nameParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.EmailParm = sortOrder == "Email" ? "Email_desc" : "Email";
            ViewBag.PhoneParm = sortOrder == "Phone" ? "Phone_desc" : "Phone";
            ViewBag.homePParm = sortOrder == "homeP" ? "homeP_desc" : "homeP";
            ViewBag.CompanyParm = sortOrder == "Company" ? "Company_desc" : "Company";

            var filter = db.客戶聯絡人.Where(P => P.Flag == true);
            
            //if (!String.IsNullOrEmpty(keyword))
            //{
            //    filter = filter.Where(s => s.客戶聯絡人.Contains(keyword));
            //    ViewBag.SearchParm = keyword;
            //}


            switch (sortOrder)
            {
                case "jname":
                    filter = filter.OrderBy(p=>p.職稱);
                    break;
                case "jname_desc":
                    filter = filter.OrderByDescending(p => p.職稱);
                    break;

                case "name":
                    filter = filter.OrderBy(p => p.姓名);
                    break;
                case "name_desc":
                    filter = filter.OrderByDescending(p => p.姓名);
                    break;

                case "Email":
                    filter = filter.OrderBy(p => p.Email);
                    break;
                case "Email_desc":
                    filter = filter.OrderByDescending(p => p.Email);
                    break;

                case "Phone":
                    filter = filter.OrderBy(p => p.手機);
                    break;
                case "Phone_desc":
                    filter = filter.OrderByDescending(p => p.手機);
                    break;

                case "homeP":
                    filter = filter.OrderBy(p => p.電話);
                    break;
                case "homeP_desc":
                    filter = filter.OrderByDescending(p => p.電話);
                    break;

                case "Company":
                    //無法獲取名稱資料
                    break;
                case "Company_desc":
                    //
                    break;

            }

            return View(filter.ToList());
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 cl)
        {
            if (ModelState.IsValid)
            {
                cl.Flag = true;
                db.客戶聯絡人.Add(cl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", cl.客戶Id);
            return View(cl);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(客戶聯絡人 cl)
        {
            if (ModelState.IsValid)
            {
                cl.Flag = true;
                db.Entry(cl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", cl.客戶Id);
            return View(cl);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int id)
        {
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null && 客戶聯絡人.Flag==false)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost]

        public ActionResult Delete(int id, FormCollection collection)
        {
            客戶聯絡人 cl = db.客戶聯絡人.Find(id);
            cl.Flag = false;
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
