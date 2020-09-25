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
using VideoLister.ViewModel;
using VideoLister.Model;

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
            VideoViewModel videoViewModel = new VideoViewModel();
            List<VideoModel> videos = videoViewModel.GetList();
            foreach (VideoModel video in videos)
            {
                Trace.WriteLine(video.PreviewImages[0]);
            }
            this.DataContext = videos[0];

        }
    }
}
