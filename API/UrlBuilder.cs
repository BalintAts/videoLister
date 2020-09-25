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
            Key = GetFromTxt("Key");
            //MyIp = GetFromTxt("myIp.txt");
            Trace.WriteLine(Key);
            Trace.WriteLine(MyIp);
        }
        public string BuildUrl(string category, int pageIndex)
        {
            return "aaa";
        }

        public string GetFromTxt(string path)
        {
            //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"API\Key.txt");
            StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}
