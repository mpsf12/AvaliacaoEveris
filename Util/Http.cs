using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Util
{
    public class Http
    {
        string strUrlBase = "";

        public Http(string strUrlBase)
        {
            this.strUrlBase = strUrlBase;
        }
        public Http()
        {
        }

        public void Get(string url)
        {
            url = string.Format(strUrlBase, url);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            string output = JsonConvert.SerializeObject("");

            byte[] bytepostArray = Encoding.UTF8.GetBytes(output);
            request.ContentLength = bytepostArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytepostArray, 0, bytepostArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();
        }
        public T GetObject<T>(string url, string authorization = null) where T : class, new()
        {

            string urlRequisicao = strUrlBase + url;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlRequisicao);

            WebRequest request = WebRequest.Create(urlRequisicao);
            request.Method = "GET";
            if (!string.IsNullOrEmpty(authorization))
                request.Headers.Add(HttpRequestHeader.Authorization, authorization);
            string output = JsonConvert.SerializeObject("");

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            T retorno = JsonConvert.DeserializeObject<T>(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return retorno;
        }

        public List<T> GetList<T>(string url, string authorization = null) where T : class, new()
        {
            string urlRequisicao = strUrlBase + url;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlRequisicao);

            WebRequest request = WebRequest.Create(urlRequisicao);
            request.Method = "GET";
            if (!string.IsNullOrEmpty(authorization))
                request.Headers.Add(HttpRequestHeader.Authorization, authorization);
            string output = JsonConvert.SerializeObject("");

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            List<T> dados = JsonConvert.DeserializeObject<List<T>>(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return dados;
        }

        public string PostObject(string url, object obj, string authorization = null)
        {
            string urlRequisicao = strUrlBase + url;
            HttpClient client = new HttpClient();
            try
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(urlRequisicao);
                request.Method = "POST";
                request.ContentType = "application/json";
                if (!string.IsNullOrEmpty(authorization))
                    request.Headers.Add(HttpRequestHeader.Authorization, authorization);

                string Jsondados = JsonConvert.SerializeObject(obj);
                byte[] bytepostArray = Encoding.UTF8.GetBytes(Jsondados);
                request.ContentLength = bytepostArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(bytepostArray, 0, bytepostArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            }
            catch (WebException ex)
            {
                //throw ex;
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
