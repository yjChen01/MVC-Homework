﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models.PartialClassManager
{
    [MetadataType(typeof (客戶資料MetaData))]
    public partial class 客戶資料 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
        DBModel db = new DBModel();

    }


    //Collect all modle valid data, if have lots of view modle, then need to gether all off them below(try to use inhier繼承 to unite all same validation)
    public partial class 客戶資料MetaData
    {

        public int Id { get; set; }

        [Required]
        public string 客戶名稱 { get; set; }
        public string 統一編號 { get; set; }
        public string 電話 { get; set; }
        public string 傳真 { get; set; }
        public string 地址 { get; set; }
        public string Email { get; set; }
    }
}