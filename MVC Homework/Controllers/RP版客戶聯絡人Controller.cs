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
    public class RP版客戶聯絡人Controller : Controller
    {
        //private DBModel db = new DBModel(); 摘掉，用Repository取代
        
        客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
        客戶資料Repository repoMain;//共用db連線寫在建構式裡面。因為上面的RepositoryHelper已經有建立過一次DB連線了，所以這裡就不直接再次使用RepostiryHelper
        public RP版客戶聯絡人Controller()
        {
            repoMain = RepositoryHelper.Get客戶資料Repository(repo.UnitOfWork);
        }
       
        
        // GET: RP版客戶聯絡人
        public ActionResult Index()
        {
            var 客戶聯絡人 = repo.All();
            return View(客戶聯絡人.ToList());
        }

        // GET: RP版客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 cc =repo.All().FirstOrDefault(p=>p.客戶Id==id);
            if (cc == null)
            {
                return HttpNotFound();
            }
            return View(cc);
        }

        // GET: RP版客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(repoMain.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: RP版客戶聯絡人/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,Flag")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                repo.Add(客戶聯絡人);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(repoMain.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: RP版客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.All().FirstOrDefault(p => p.客戶Id == id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(repoMain.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: RP版客戶聯絡人/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,Flag")] 客戶聯絡人 cc)
        {
            if (ModelState.IsValid)
            {
                客戶聯絡人 mc= repo.All().FirstOrDefault(p => p.客戶Id == cc.Id);
                mc.職稱 = cc.職稱;
                mc.姓名 = cc.姓名;
                mc.Email = cc.Email;
                mc.手機 = cc.手機;
                mc.電話 = cc.電話;
                mc.Flag = cc.Flag;

                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(repoMain.All(), "Id", "客戶名稱", cc.客戶Id);
            return View(cc);
        }

        // GET: RP版客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.All().FirstOrDefault(p=>p.客戶Id==id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: RP版客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = repo.All().FirstOrDefault(p=>p.客戶Id==id);
            客戶聯絡人.Flag = false;
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
