using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.ValidationAttributes
{
    public class PhoneNumberAttribute:RegularExpressionAttribute
    {
        public PhoneNumberAttribute() : base(@"\d{4}-\d{6}")
        {
            base.ErrorMessage = "請輸入合法的手機號碼";
        }
    }
}