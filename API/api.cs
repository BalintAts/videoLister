using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VideoLister.API
{
    class Api
    {

        protected HttpResponseMessage GET(string url)
        {
            using(HttpClient client = new HttpClient())
            {
                
                var response = client.GetAsync(url);
                response.Wait();

                return response.Result;
            }

            return null;
        }

    }
}
