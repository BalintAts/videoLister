using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using VideoLister.Model;
using VideoLister.ViewModel;
using System.Windows.Navigation;

namespace VideoLister
{
    public partial class MainWindow : Window
    {
        private int pageNumber = 1; 
        public ObservableCollection<int> PageNumber { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<VideoModel> Videos { get; set; } = new ObservableCollection<VideoModel>();
        public VideoViewModel videoViewModel { get; set; }
        public string Category { get; set; }

        public MainWindow()
        {            
            InitializeComponent();
            Category = "girl";
            PageNumber.Add(pageNumber);
            Trace.WriteLine("main window initialized");
            videoViewModel = new VideoViewModel();
            Videos.Clear();
            List<VideoModel> videos = videoViewModel.GetList(Category, PageNumber[0]);
            videos.ForEach(x => Videos.Add(x)); ;
            //foreach (VideoModel video in Videos)
            //{
            //    Trace.WriteLine(video.Title);
            //}
            DataContext = this;
            //foreach (VideoModel item in Videos)
               
            //{
            //    Trace.WriteLine("This is a video");
            //    foreach (string tag in item.Tags)
            //    {
            //        Trace.WriteLine(tag);
            //    }
            //}
        }


        public void  NextPage(object sender, RoutedEventArgs e)
        {
            pageNumber++;
            PageNumber.Clear();
            PageNumber.Add(pageNumber);
            Videos.Clear();
            List<VideoModel> videos = videoViewModel.GetList(Category, PageNumber[0]);
            videos.ForEach(x => Videos.Add(x));
            Trace.WriteLine(PageNumber);


        }

        public void PrevPage(object sender, RoutedEventArgs e)
        {
            if (pageNumber >= 1)
            {
                pageNumber--;
                PageNumber.Clear();
                PageNumber.Add(pageNumber);
            }
            Videos.Clear();
            List<VideoModel> videos = videoViewModel.GetList(Category, PageNumber[0]);
            videos.ForEach(x => Videos.Add(x));
            Trace.WriteLine(PageNumber);
         
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {

            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
