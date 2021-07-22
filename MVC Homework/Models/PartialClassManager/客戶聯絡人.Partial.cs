using MVC_Homework.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models
{
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人: IValidatableObject
    {
       DBModel db = new DBModel();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //回傳0 為可新增  , 大於1為重複。
            int idx = db.客戶聯絡人.Where(q => q.Email == this.Email).Count();
            int tempId = this.Id;
            //新增 => id是0，且總數不等於0
            if (idx != 0 && tempId==0) {
                 yield return new ValidationResult("重複的Email",new string[] { "Email"});
            }
            //throw new NotImplementedException();
        }
    }
    public partial class 客戶聯絡人MetaData
    {
        public int Id { get; set; }
        public int 客戶Id { get; set; }
        [Required]
        public string 職稱 { get; set; }
        [Required]
        public string 姓名 { get; set; }

        [Required, RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [PhoneNumber]
        public string 手機 { get; set; }
        public string 電話 { get; set; }
        public bool Flag { get; set; }

    }
}