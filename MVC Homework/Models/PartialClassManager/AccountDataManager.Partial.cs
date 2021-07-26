using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models
{
    public partial class AccountDateManager : IValidatableObject
    {
        //AccountDateManager retData = new AccountDateManager();
        public DateTime ed;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            DateTime upline = DateTime.Parse(StartDate).AddDays(7);
            DateTime st = DateTime.Parse(StartDate);
            if (String.IsNullOrEmpty(EndDate)) //若投入值為空，自動雖便丟個合法範圍
            {
                ed = st;
            }
            else
            {
                ed = DateTime.Parse(EndDate);  
            }


            if (ed < st)
            {
                yield return new ValidationResult("訖不能大於起" ,new string[] { "EndDate" });
            }
            else if(ed > upline)
            {
                yield return new ValidationResult("搜尋超過七天的值", new string[] { "EndDate" });

            }
            //throw new NotImplementedException();
        }
    }
}