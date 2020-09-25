using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VideoLister.API
{
    class UrlBuilder
    {
        private string Key { get; set; }
        private string MyIp { get; set; }

        public UrlBuilder()
        {
            //Key = GetFromTxt("Key");
            //MyIp = GetFromTxt("myIp.txt");
            Trace.WriteLine(Key);
            Trace.WriteLine(MyIp);
        }
        public string BuildUrl(string category, int pageIndex)
        {
            return "https://pt.ptawe.com/api/video-promotion/v1/list?category=" + category + "&clientIp=2001:4c4c:2095:2600:f8a7:130e:d05a:ca2&limit=10&pageIndex=" + pageIndex + "3&psid=balint&accessKey=4dcdc998265be0ffcc1e7e978fd2ccf1&primaryColor=FFEEEE&labelColor=EEFFEE";
        }

        public string GetFromTxt(string path)
        {
            //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"API\Key.txt");
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}
