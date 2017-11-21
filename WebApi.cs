using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace lorakon_manager
{
    public static class WebApi
    {
        public static string MakeGetRequest(string req)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 30000;
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";

            string json;
            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(resp.GetResponseStream()))
                json = sr.ReadToEnd();

            return json;
        }

        public static bool MakePostRequest<T>(string req, T obj)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 30000;
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(obj);
            using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                sw.Write(json);
            
            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            if(resp.StatusCode != HttpStatusCode.OK)            
                throw new Exception(resp.StatusDescription);

            return true;
        }
    }
}
