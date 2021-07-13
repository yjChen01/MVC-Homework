﻿using MVC_Homework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class ClientDataController : Controller
    {
        DBModel db = new DBModel();

        // GET: ClientData
        public ActionResult Index()
        {
            return View(db.客戶資料.ToList());
        }

        // GET: ClientData/Details/5
        public ActionResult Details(int id)
        {
            客戶資料 cd = db.客戶資料.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            return View(cd);
        }

        // GET: ClientData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientData/Create
        [HttpPost]
        public ActionResult Create(客戶資料 cd)
        {
            try
            {
                db.客戶資料.Add(cd);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientData/Edit/5
        public ActionResult Edit(int id)
        {

            客戶資料 cd = db.客戶資料.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            return View(cd);
        }

        // POST: ClientData/Edit/5
        [HttpPost]
        public ActionResult Edit(客戶資料 cd)
        {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(cd).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");//儲存後重新導向回index並用View印出新傳入的資料
                }
                return View(cd);
        }

        // GET: ClientData/Delete/5
        public ActionResult Delete(int id)
        {

            客戶資料 cd = db.客戶資料.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            return View(cd);
        }

        // POST: ClientData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                客戶資料 cd = db.客戶資料.Find(id);
                cd.Flag = false;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
