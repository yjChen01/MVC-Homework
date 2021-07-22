using MVC_Homework.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models
{

    [MetadataType(typeof(客戶資料MetaData))]
    public partial class 客戶資料
    {

    }


    //Collect all modle valid data, if have lots of view modle, then need to gether all off them below(try to use inhier繼承 to unite all same validation)
    public partial class 客戶資料MetaData
    {

        public int Id { get; set; }

        [Required]
        public string 客戶名稱 { get; set; }
        
        [Required]
        public string 統一編號 { get; set; }
        
        [Required,PhoneNumber]
        public string 電話 { get; set; }
        
        public string 傳真 { get; set; }

        public string 地址 { get; set; }

        [Required, EmailAddress(ErrorMessage ="請輸入正確的信箱格式")]
        public string Email { get; set; }
    }
}