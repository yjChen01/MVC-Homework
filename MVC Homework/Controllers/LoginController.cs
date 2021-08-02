using MVC_Homework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Windows.UI.Xaml.Controls;
using X.PagedList;

namespace MVC_Homework.Controllers
{
    public class LoginController : Controller
    {
        repoAccountTest repo = new repoAccountTest();
        public DateTime ed;

        // GET: Login
        public ActionResult Index(AccountDateManager data, int pageNo = 1, int pageSize = 3)
        {
            AccountDateManager retData = new AccountDateManager();

            if (ModelState.IsValid)
            {
                DateTime st = DateTime.Parse(data.StartDate);
                if (String.IsNullOrEmpty(data.EndDate)) //給model餵end day時間
                {
                    ed = st.AddDays(7);
                }
                else
                {
                    ed = DateTime.Parse(data.EndDate);
                }

                if (st != DateTime.MinValue)
                {
                    retData.Accounts = repo.GetAll().Where(s => s.Registered >= st && s.Registered <= ed).OrderBy(p => p.Registered).ToPagedList(pageNo, pageSize);
                    retData.EndDate = ed.ToString("yyyy-MM-dd");
                }
                else
                {
                    retData.Accounts = repo.GetAll().OrderBy(p => p.Registered).ToPagedList(pageNo, pageSize);
                }
            }
            else
            {
                retData.Accounts = repo.GetAll().OrderBy(p => p.Registered).ToPagedList(pageNo, pageSize);
            }
            return View(retData);
        }
    }
}