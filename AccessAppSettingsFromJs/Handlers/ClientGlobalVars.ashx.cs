using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;

namespace DevelopmentSimplyPut.Handlers
{
    public class ClientGlobalVars : IHttpHandler, IRequiresSessionState 
    {
        public void ProcessRequest(HttpContext context)
        {
			context.Response.ClearHeaders();
			context.Response.ContentType = "application/x-javascript";
			context.Response.Cache.SetCacheability(HttpCacheability.Public);
			context.Response.CacheControl = Convert.ToString(HttpCacheability.Public);
            context.Response.Write("var AppSettings = new Object();\n");

            NameValueCollection appSettings = ConfigurationManager.AppSettings;

            for (int i = 0; i < appSettings.Count; i++)
            {
                string key = appSettings.GetKey(i);
                string value = appSettings.Get(i);
                context.Response.Write(string.Format(CultureInfo.InvariantCulture, "AppSettings.{0} = '{1}';\n", key, value));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}