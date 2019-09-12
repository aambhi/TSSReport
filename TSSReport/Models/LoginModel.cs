using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TSSReport.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }

    public class LoginResultModel
    {
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string ResponseCode { get; set; }
        public string DBName { get; set; }
        public string CompanyName { get; set; }
        public List<CompanyModel> LstCompany { get; set; }
    }
    public class CompanyModel
    {
        public string CompanyName { get; set; }
        public string DBName { get; set; }
    }

}