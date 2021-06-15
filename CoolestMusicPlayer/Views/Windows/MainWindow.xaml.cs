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
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using CoolestMusicPlayer.Views.Pages;
using CoolestMusicPlayer.Core;
using System.Windows.Controls.Primitives;
using CoolestMusicPlayer.Core.Models;

namespace CoolestMusicPlayer.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Music previousTrack;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private bool userIsDraggingSlider = false;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new PlaylistPage());
        }
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayButton.Content == "Play")
            {
                PlayButton.Content = "Pause";
                Music currentTrack = AudioManager.Playlist[0];
                if (currentTrack != previousTrack)
                {
                    mediaPlayer.Open(new Uri(currentTrack.Source));
                    previousTrack = currentTrack;
                }
                mediaPlayer.Play();
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else
            {
                PlayButton.Content = "Play";
                mediaPlayer.Pause();
            }
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ProgressSlider_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void ProgressSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(ProgressSlider.Value);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
            {
                Timer.Content = String.Format("{0}", mediaPlayer.Position.ToString(@"mm\:ss"));
                FullTime.Content = String.Format("{0}", mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                ProgressSlider.Minimum = 0;
                ProgressSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                ProgressSlider.Value = mediaPlayer.Position.TotalSeconds;
            }
            else
            {
                Timer.Content = "No file selected...";
            }
        }
    }
}
