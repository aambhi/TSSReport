using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TSSReport.Utilities
{
    public class Common
    {
        public static void LogError(string Controller, string PageUrl, string Action, string ErrorMessage = null, string InnerException = null, string userCode = null, string UserIp = null)
        {

            string LOG_FILE = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory) + "Log\\" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt";
            //set up a filestream
            FileStream fs = new FileStream(LOG_FILE, FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text
            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream
            sw.BaseStream.Seek(0, SeekOrigin.End);

            //add the text
            sw.WriteLine("==================================================================\r\nDateTime" + DateTime.Now.ToString() + "\r\n Controller: " +
                 Controller + "\r\n URL: " + PageUrl + "\r\n Action: " + Action + "\r\n Error Message: " + ErrorMessage + "\r\n Inner Exception: " + InnerException + "\r\n User: " + userCode + "\r\n UserIP: " + UserIp + "\r\n==================================================================");
            //add the text to the underlying filestream

            sw.Flush();
            //close the writersw.Close();

            sw.Close();
        }
    }
}