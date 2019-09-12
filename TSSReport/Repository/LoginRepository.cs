using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TSSReport.Data;
using TSSReport.Models;
using TSSReport.Utilities;

namespace TSSReport.Repository
{
    public class LoginRepository
    {
        public static LoginResultModel ValidateUserLogin(LoginModel userlogin)
        {
            var loginResult = new LoginResultModel();
            try
            {
                var UserName = new SqlParameter { ParameterName = "UserName", Value = userlogin.UserName };
                var Password = new SqlParameter { ParameterName = "Password", SqlDbType = SqlDbType.NVarChar, Value = Encrypt(userlogin.Password) };

                using (var dbContext = new CompanyDBEntities())
                {
                    var results = dbContext
                       .MultipleResults("[dbo].[PROC_ValidateUserLoginReport]")
                       .With<LoginResultModel>()
                       .With<CompanyModel>()
                       .Execute(UserName, Password);
                    if (results != null && results.Count > 0)
                    {
                        loginResult = ((List<LoginResultModel>)results[0]).SingleOrDefault();
                        if (loginResult != null)
                        {
                            if (loginResult.ResponseCode.Equals("00"))
                            {
                                loginResult.LstCompany = ((List<CompanyModel>)results[1]).ToList();
                                if (loginResult.LstCompany.Count > 0)
                                {
                                    loginResult.DBName = loginResult.LstCompany.FirstOrDefault().DBName;
                                    loginResult.CompanyName = loginResult.LstCompany.FirstOrDefault().CompanyName;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.LogError("Login", "ValidateUserLogin", "ValidateUserLogin", ex.Message.ToString(), ex.InnerException.Message.ToString(), "", "");
            }

            return loginResult;

        }

        private static string Encrypt(string Text)
        {
            string EncryptRet = default(string);
            int I = 0;
            string encr = "";
            var loopTo = Text.Length;
            for (I = 1; I <= loopTo; I++)
                encr = encr + Strings.Chr((Strings.Asc(Strings.Mid(Text, I, 1))) + 100);

            EncryptRet = encr;
            return EncryptRet;
        }


    }
}