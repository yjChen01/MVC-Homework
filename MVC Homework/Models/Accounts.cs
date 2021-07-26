using MVC_Homework.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models
{
    public partial class Accounts
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Registered { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
    }

    public partial class AccountDateManager
    {
        public IEnumerable<Accounts> Accounts { get; set; }

        //[MoreThenStartDate("StartDate", "EndDate",ErrorMessage ="結束日期不符合")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string EndDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string StartDate { get; set; }
    }
    
}