using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models.PartialClassManager
{
    [MetadataType(typeof(客戶銀行資訊))]
    public partial class 客戶銀行資訊 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
    public partial class 客戶銀行資訊MetaData
    {
        public int Id { get; set; }
        
        public int 客戶Id { get; set; }
        public string 銀行名稱 { get; set; }
        public int 銀行代碼 { get; set; }
        public Nullable<int> 分行代碼 { get; set; }
        public string 帳戶名稱 { get; set; }
        public string 帳戶號碼 { get; set; }
        public bool Flag { get; set; }

    }
}