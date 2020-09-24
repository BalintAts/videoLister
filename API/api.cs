using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using VideoLister.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                    //Trace.WriteLine(response.Result);
                    CreateModel(response.Result);
                }
                catch (HttpRequestException e)
                {
                    //show the message to the user
                    return null;
                }
                return null;
            }

        }

        public VideoModel CreateModel(string rawJson)
        {
            VideoModel videoModel = new VideoModel();
            JObject jsonResp = JObject.Parse(rawJson);
            foreach( JToken jToken in jsonResp["data"]["videos"])
            {
                Trace.WriteLine(jToken["title"]);
            }

            return videoModel;
        }

    }
}
