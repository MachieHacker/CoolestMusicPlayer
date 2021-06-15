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
using System.Windows.Threading;
using Microsoft.Win32;
using CoolestMusicPlayer.Views.Windows;
using CoolestMusicPlayer.Core.Models;
using CoolestMusicPlayer.Core;

namespace CoolestMusicPlayer.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlaylistPage.xaml
    /// </summary>
    public partial class PlaylistPage : Page
    {
        public PlaylistPage()
        {
            InitializeComponent();
        }

        private void AddTrack_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                //mediaPlayer.Open(new Uri(openFileDialog.FileName));
                Music track = new Music()
                {
                    Id = 1,
                    Name = "Biba",
                    Authtor = "AHAHAH",
                    Source = openFileDialog.FileName
                };

                AudioManager.Playlist.Add(track);

                // openFileDialog.FileName
            }

        }
    }
}
