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

        public string GET(string url)
        {            
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    var response = client.GetStringAsync(url);
                    response.Wait();
                    //Trace.WriteLine(response.Result);
                    //CreateModels(response.Result);
                    return response.Result;
                }
                catch (HttpRequestException e)
                {
                    //show the message to the user
                    return null;
                }
                return null;
            }
        }

        public List<VideoModel> GetList(string category, int page)
        {
            //UrlBuilder urlBuilder = new UrlBuilder();
            //string url = urlBuilder.BuildUrl("girl",1);
            UrlBuilder ub = new UrlBuilder();
            string url = ub.BuildUrl(category, page);
            //string rawJson = GET("https://pt.ptawe.com/api/video-promotion/v1/list?category=girl&clientIp=2001:4c4c:2095:2600:f8a7:130e:d05a:ca2&limit=1&pageIndex=3&psid=balint&accessKey=4dcdc998265be0ffcc1e7e978fd2ccf1&primaryColor=FFEEEE&labelColor=EEFFEE");
            string rawJson = GET(url);
            List<VideoModel> videos =  CreateModels(rawJson);
            return videos;
        }

        public List<VideoModel> CreateModels(string rawJson)
        {
            List<VideoModel> videos = new List<VideoModel>();
            JObject jsonResp = JObject.Parse(rawJson);
            foreach( JToken jToken in jsonResp["data"]["videos"])
            {
                VideoModel videoModel = new VideoModel();
                
                videoModel.Title = jToken["title"].ToString();
                videoModel.Duration = jToken["duration"].ToString();
                videoModel.Tags = jToken["tags"].ToString().Split(',').ToList();
                videoModel.ProfileImage = "https:" + jToken["profileImage"].ToString();
                videoModel.PreviewImages = jToken["previewImages"].ToString().Split(',').ToList();
                videoModel.TargetUrl = "https:" + jToken["targetUrl"].ToString();
                videoModel.DetailsUrl = "https:" + jToken["detailsUrl"].ToString();
                videoModel.Quality = jToken["quality"].ToString();
                videoModel.IsHd = jToken["isHd"].ToString();
                videoModel.Uploader = jToken["uploader"].ToString();
                videoModel.UploaderLink = "https:" + jToken["uploaderLink"].ToString();
         
                videos.Add(videoModel);               
            }
            return videos;
        }


    }
}
