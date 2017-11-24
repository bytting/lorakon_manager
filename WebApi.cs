//  lorakon_manager - Manager for Lorakon database
//  Copyright (C) 2017  Norwegian Radiation Protection Autority
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// Authors: Dag Robole,

using System;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace lorakon_manager
{
    public static class WebApi
    {
        public static string MakeGetRequest(string req, string username, string password)
        {            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);            
            string cred = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + cred);
            request.PreAuthenticate = true;
            request.Timeout = 30000;
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";

            string json;
            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(resp.GetResponseStream()))
                json = sr.ReadToEnd();

            return json;
        }

        public static bool MakePostRequest<T>(string req, T obj, string username, string password)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);
            string cred = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + cred);
            request.PreAuthenticate = true;
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
