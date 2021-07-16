using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.ValidationAttributes
{
    public class EmailAttribute : DataTypeAttribute
    {
        public EmailAttribute():base(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")
        {
            base.ErrorMessage = "Email格式有誤";
        }
    }
}