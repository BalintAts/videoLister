using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using VideoLister.API;

namespace VideoLister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Trace.WriteLine("main window initialized");
            Api api = new Api();
            api.GET("https://pt.ptawe.com/api/video-promotion/v1/list?category=girl&clientIp=2001:4c4c:2095:2600:f8a7:130e:d05a:ca2&limit=1&pageIndex=1&psid=balint&accessKey=4dcdc998265be0ffcc1e7e978fd2ccf1&primaryColor=FFEEEE&labelColor=EEFFEE");
        }
    }
}
