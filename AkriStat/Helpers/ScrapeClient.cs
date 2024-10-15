using System;
using System.Net;

namespace AkriStat.Helpers
{
    // Custom Client used for scraping web pages
    public class ScrapeClient : WebClient
    {
        public CookieContainer m_container = new CookieContainer();
        public WebProxy proxy = null;

        public ScrapeClient()
        {
            Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.97 Safari/537.11";
            Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            Headers[HttpRequestHeader.Accept] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            Headers[HttpRequestHeader.AcceptEncoding] = "gzip,deflate,sdch";
            Headers[HttpRequestHeader.AcceptLanguage] = "en-GB,en-US;q=0.8,en;q=0.6";
            Headers[HttpRequestHeader.AcceptCharset] = "ISO-8859-1,utf-8;q=0.7,*;q=0.3";
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            try
            {
                ServicePointManager.DefaultConnectionLimit = 1000000;
                WebRequest request = base.GetWebRequest(address);
                request.Proxy = proxy;

                HttpWebRequest webRequest = request as HttpWebRequest;
                webRequest.Pipelined = true;
                webRequest.KeepAlive = true;
                if (webRequest != null)
                {
                    webRequest.CookieContainer = m_container;
                }

                return request;
            }
            catch
            {
                return null;
            }
        }
    }
}
