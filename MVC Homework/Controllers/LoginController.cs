using MVC_Homework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Windows.UI.Xaml.Controls;

namespace MVC_Homework.Controllers
{
    public class LoginController : Controller
    {
        repoAccountTest repo = new repoAccountTest();

        // GET: Login
        public ActionResult Index(AccountDateManager data)
        {
            AccountDateManager retData = new AccountDateManager();
            if (data.StartDate != DateTime.MinValue)
            {
                if(data.EndDate == DateTime.MinValue)
                {
                    data.EndDate = data.StartDate.AddDays(7);
                }
                retData.Accounts = repo.GetAll().Where(s => s.Registered >= data.StartDate && s.Registered<=data.EndDate);
            }
            else
            {
                retData.Accounts = repo.GetAll();
            }
            return View(retData);
        }
    }
}