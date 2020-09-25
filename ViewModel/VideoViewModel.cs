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
        public void Call()
        {
            Api api = new Api();
            List<VideoModel> videos =  api.GetList();
            foreach (VideoModel video in videos)
            {
                Trace.WriteLine(video.Title);
            }
        }
    }
}
