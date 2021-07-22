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
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime Registered { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
    }

    public class AccountDateManager
    {
        public IEnumerable<Accounts> Accounts { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}