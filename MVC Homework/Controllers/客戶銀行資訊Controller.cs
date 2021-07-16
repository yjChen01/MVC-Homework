using MVC_Homework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class 客戶銀行資訊Controller : Controller
    {
        DBModel db = new DBModel();

        // GET: 客戶銀行資訊
        public ActionResult Index()
        {
            var filter = db.客戶銀行資訊.Where(p => p.Flag == true);
            return View(filter.ToList());
        }
        
        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int id)
        {
            客戶銀行資訊 cb = db.客戶銀行資訊.Find(id);
            if (cb == null)
            {
                return HttpNotFound();
            }
            return View(cb);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        [HttpPost]
        public ActionResult Create(客戶銀行資訊 cb)
        {
            try
            {
                cb.Flag = true;
                db.客戶銀行資訊.Add(cb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int id)
        {
            客戶銀行資訊 cb = db.客戶銀行資訊.Find(id);
            if (cb == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", cb.客戶Id);
            return View(cb);
        }

        // POST: 客戶銀行資訊/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(客戶銀行資訊 cb)
        {
            if (ModelState.IsValid)
            {
                cb.Flag = true;
                db.Entry(cb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", cb.客戶Id);
            return View(cb);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int id)
        {
            客戶銀行資訊 cb = db.客戶銀行資訊.Find(id);
            if (cb == null && cb.Flag == false)
            {
                return HttpNotFound();
            }
            return View(cb);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            客戶銀行資訊 cb = db.客戶銀行資訊.Find(id);
            cb.Flag = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
