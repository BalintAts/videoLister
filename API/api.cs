using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace VideoLister.API
{
    class Api
    {

        public HttpResponseMessage GET(string url)
        {            
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    var response = client.GetStringAsync(url);
                    response.Wait();
                    Trace.WriteLine(response.Result);
                }
                catch (HttpRequestException e)
                {
                    //show the message to the user
                    return null;
                }
                return null;
            }

        }

    }
}
