using MVC_Homework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class ClientDataController : Controller
    {
        DBModel db = new DBModel();

        // GET: ClientData
        public ActionResult Index(string sortOrder, string keyword)
        {
        
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";//客戶名稱
            ViewBag.TaxParm = sortOrder=="tax" ? "tax_desc" : "tax";//統一編號
            ViewBag.PhonParm = sortOrder=="phon" ? "phon_d" : "phon";
            ViewBag.faxParm = sortOrder == "fax" ? "fax_desc" : "fax";
            ViewBag.addrParm = sortOrder == "addr" ? "addr_desc" : "addr";
            ViewBag.EmailParm = sortOrder == "mail" ? "mail_desc" : "mail";

            var filter = db.客戶資料.Where(p => p.Flag == true);

            if (!String.IsNullOrEmpty(keyword))
            {
                 filter = filter.Where(s => s.客戶名稱.Contains(keyword));
                ViewBag.SearchParm = keyword;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    filter = filter.OrderByDescending(s => s.客戶名稱);
                    break;

                case "tax_desc":
                    filter = filter.OrderByDescending(s => s.統一編號);
                    break;
                case "tax":
                    filter = filter.OrderBy(s => s.統一編號);
                    break;

                case "phon_d":
                    filter = filter.OrderByDescending(s => s.電話);
                    break;
                case "phon":
                    filter = filter.OrderBy(s => s.電話);
                    break;

                case "fax_desc":
                    filter = filter.OrderByDescending(s => s.傳真);
                    break;
                case "fax":
                    filter = filter.OrderBy(s => s.傳真);
                    break;

                case "addr_desc":
                    filter = filter.OrderByDescending(s => s.地址);
                    break;
                case "addr":
                    filter = filter.OrderBy(s => s.地址);
                    break;

                case "mail_desc":
                    filter = filter.OrderByDescending(s => s.Email);
                    break;
                case "mail":
                    filter = filter.OrderBy(s => s.Email);
                    break;


                default:
                      filter = filter.OrderBy(s => s.客戶名稱);
                    break;
            }

            return View(filter.ToList());

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
                cd.Flag = true;
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
                    cd.Flag = true;
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
