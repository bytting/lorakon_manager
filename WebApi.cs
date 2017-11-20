using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace lorakon_manager
{
    public static class WebApi
    {
        public static string MakeRequest(string req, string httpRequestMethod)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 30000;
            request.Method = httpRequestMethod; //  WebRequestMethods.Http.Get;
            request.Accept = "application/json";

            string json;
            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(resp.GetResponseStream()))
                json = sr.ReadToEnd();

            return json;
        }
    }
}
