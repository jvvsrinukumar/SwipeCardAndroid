using System;
using System.Net.Http;

namespace SwipeCardAndroid
{
    public class RestServiceCls
    {

        /// <summary>
        /// this method provides object of httpclient for calling Rest Api
        /// </summary>
        /// <returns>HttpClient</returns>
        public HttpClient ConfigurateHttpClient()
        {
            var client = new HttpClient();           
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            return client;
        }
    }
}
