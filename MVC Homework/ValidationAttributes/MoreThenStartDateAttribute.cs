using MVC_Homework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.ValidationAttributes
{
    public class MoreThenStartDateAttribute: ValidationAttribute
    {
        AccountDateManager aa = new AccountDateManager();
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public MoreThenStartDateAttribute(string st,string ed)
        {
           this.start = DateTime.Parse(st);
           this.end = DateTime.Parse(ed);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime upline = start.AddDays(7);
            if(end>=start||end<= upline)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}