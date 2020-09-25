using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLister.API;
using VideoLister.Model;
using System.Diagnostics;


namespace VideoLister.ViewModel
{
    class VideoViewModel
    {
        public List<VideoModel> GetList()
        {
            Api api = new Api();
            List<VideoModel> videos =  api.GetList();

            return videos;
        }
    }
}
