﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using VideoLister.Model;
using VideoLister.ViewModel;

namespace VideoLister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<VideoModel> Videos { get; set; }
        public MainWindow()
        {
            

            InitializeComponent();
            Trace.WriteLine("main window initialized");
            VideoViewModel videoViewModel = new VideoViewModel();
            Videos = videoViewModel.GetList();
            foreach (VideoModel video in Videos)
            {
                Trace.WriteLine(video.Title);
            }
            DataContext = this;
        }
    }
}
