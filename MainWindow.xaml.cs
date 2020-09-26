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
        private VideoViewModel videoViewModel { get; set; }
        private string Category { get; set; }
        public string Actress { get; set; }
        public string Tags { get; set; }



        public MainWindow()
        {            
            InitializeComponent();
            Category = "girl";
            PageNumber.Add(pageNumber);
            Trace.WriteLine("main window initialized");
            videoViewModel = new VideoViewModel();
            UpdateList();
            DataContext = this;             
        }

        public void  NextPage(object sender, RoutedEventArgs e)
        {
            pageNumber++;
            PageNumber.Clear();
            PageNumber.Add(pageNumber);
            Videos.Clear();
            UpdateList();
        }

        public void PrevPage(object sender, RoutedEventArgs e)
        {
            if (pageNumber >= 1)
            {
                pageNumber--;
                PageNumber.Clear();
                PageNumber.Add(pageNumber);
            }
            UpdateList();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {

            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            Videos.Clear();
            List<VideoModel> videos = videoViewModel.GetList(Category, Actress, Tags, PageNumber[0]);
            videos.ForEach(x => Videos.Add(x));
        }
    }
}
