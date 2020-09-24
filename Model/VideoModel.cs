using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLister.Model
{
    class VideoModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public List<string> Tags { get; set; }
        public string ProfileImage { get; set; }
        public string PreviewImages { get; set; }
        public string TargetUrl { get; set; }
        public string DetailsUrl { get; set; }
        public string Quality { get; set; }
        public string IsHd{ get; set; }
        public string Uploader { get; set; }
        public string UploaderLink { get; set; }
    }
}
