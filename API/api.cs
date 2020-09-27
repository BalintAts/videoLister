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
using System.Windows.Automation.Peers;

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
                    return response.Result;
                }
                catch (HttpRequestException e)
                {
                    Trace.WriteLine(e.Message);
                    return null;
                }                
            }
        }

        public List<VideoModel> GetList(string category, string actress, string tags, int page)
        {
            UrlBuilder ub = new UrlBuilder();
            string url = ub.BuildUrl(category, actress, tags, page);
            string rawJson = GET(url);
            Trace.WriteLine(rawJson);
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
                videoModel.PreviewImages = CreatePreviewImageUrlStrings(jToken["previewImages"]);
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

        private List<string> CreatePreviewImageUrlStrings(JToken urls)
        {
            List<string> urlList = new List<string>();
            List<string> result = new List<string>();
            foreach( JToken imageLink in urls)
            {
                result.Add("https:" + imageLink.ToString());
            }
            return result;
        }
    }
}
