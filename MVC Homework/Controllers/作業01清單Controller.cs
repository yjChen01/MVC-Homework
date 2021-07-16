using MVC_Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class 作業01清單Controller : Controller
    {
        DBModel db = new DBModel();
        // GET: 作業01清單
        public ActionResult Index()
        {
            return View(db.作業檢視表01.ToList());
        }
    }
}