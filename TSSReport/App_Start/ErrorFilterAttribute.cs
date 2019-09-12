using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TSSReport.Models;
using TSSReport.Utilities;

namespace TSSReport.App_Start
{
    public class ErrorFilterAttribute : HandleErrorAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            string Controller = string.Empty;
            string Action = string.Empty;
            string User_code = string.Empty;
            string CurrentUrl = string.Empty;
            try
            {
                Exception e = filterContext.Exception;
                //Log Exception e
                filterContext.ExceptionHandled = true;
                var url = filterContext.RequestContext.HttpContext.Request.Url;

                if (url != null)
                {
                    CurrentUrl = url.ToString();
                }
                Controller = (filterContext.RequestContext.RouteData.Values.ToList())[0].Value.ToString();
                Action = (filterContext.RequestContext.RouteData.Values.ToList())[1].Value.ToString();
                User_code = ((LoginResultModel)HttpContext.Current.Session["UserDetails"]).UserName;

                if (e.InnerException != null)
                    Common.LogError(Controller, CurrentUrl, Action, e.Message.ToString(), e.InnerException.Message.ToString(), User_code, GetIP4Address());
                else
                    Common.LogError(Controller, CurrentUrl, Action, e.Message.ToString(), e.InnerException.Message.ToString(), User_code, GetIP4Address());

                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Error");
                redirectTargetDictionary.Add("controller", "Login");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);

            }
            catch (Exception ex)
            {
                Common.LogError(Controller, CurrentUrl,
               Action, ex.Message.ToString(), ex.Message.ToString(), User_code, GetIP4Address());
            }

        }

        private string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }
    }
}