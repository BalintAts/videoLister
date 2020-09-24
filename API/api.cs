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
                    CreateModels(response.Result);
                }
                catch (HttpRequestException e)
                {
                    //show the message to the user
                    return null;
                }
                return null;
            }

        }

        public List<VideoModel> CreateModels(string rawJson)
        {
            List<VideoModel> videos = new List<VideoModel>();
            JObject jsonResp = JObject.Parse(rawJson);
            foreach( JToken jToken in jsonResp["data"]["videos"])
            {
                //Trace.WriteLine(jToken["title"]);
                VideoModel videoModel = new VideoModel();
                
                videoModel.Title = jToken["title"].ToString();
         
                videos.Add(videoModel);

               
            }
            foreach(VideoModel video in videos)
            {
                Trace.WriteLine(video.Title);
            }

            return videos;
        }

    }
}
