using MVC_Homework.Models;
using System;
using System.Collections.Generic;
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
            return View(db.客戶銀行資訊.ToList());
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: 客戶銀行資訊/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
