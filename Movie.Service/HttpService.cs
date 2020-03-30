using Movie.Service.Interface;
using System;
using System.Net;
using System.Net.Http;

namespace Movie.Service
{
    public class HttpService : IHttpService
    { 

        public string GetHttpResponse(string url)
        {
            try
            {
            using (WebClient webClient = new WebClient())
            {
              return  webClient.DownloadString(url);
            }
                //http://www.omdbapi.com/?apikey=51a1993c&s=Avengers
            }
            catch
            {
                throw;
            }
            finally
            {
             
            }
        }
    }
}
