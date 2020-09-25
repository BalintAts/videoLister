using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using VideoLister.Model;
using VideoLister.ViewModel;

namespace VideoLister
{
    public partial class MainWindow : Window
    {
        public int PageNumber { get; set; }
        public List<VideoModel> Videos { get; set; }
        public VideoViewModel videoViewModel { get; set; }
        public string Category { get; set; }

        public MainWindow()
        {            
            InitializeComponent();
            PageNumber = 1;
            Category = "girl";
            Trace.WriteLine("main window initialized");
            videoViewModel = new VideoViewModel();
            Videos = videoViewModel.GetList(Category ,PageNumber);
            foreach (VideoModel video in Videos)
            {
                Trace.WriteLine(video.Title);
            }
            DataContext = this;            
        }

        public void  NextPage(object sender, RoutedEventArgs e)
        {
            PageNumber++;
            Videos = videoViewModel.GetList(Category, PageNumber);
            Trace.WriteLine("NExtgghdfkjGEWWWOIHEGOIHEGOIHEOIHWGOIHWEGOIHWEGOIWHEGOIHWEGOIWHEGOIWHEGOIWEHGOIWEHGOWIEHGOWIEHGOIWHEGOIWEH");
        }

    }
}
