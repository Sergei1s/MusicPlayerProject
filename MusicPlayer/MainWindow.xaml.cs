using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Microsoft.Win32;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// TODO: The keys isnt working
    public partial class MainWindow : Window
    {
        private const string musicDirrectory = "D:/musicD/";
        public MainWindow()
        {
            InitializeComponent();
            DirectoryInfo directory = new DirectoryInfo("D:/musicD/");//ДИРЕКТОРИЯ С МУЗЫКОЙ
            OpenFileDialog openFileDialog=new OpenFileDialog();
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo currentfile in files)
            {
                if (currentfile.Extension.ToString() == ".mp3")
                {
                    MusicListBox.Items.Add(currentfile.Name);
                }
            }
        }
        private MediaPlayer player = new MediaPlayer();
        private int i = 0;//флаг полной остановки
        private int k;
        private int key;
        private int keyChecker;
        private bool onePasskeeper=true;
        private bool IsPlaying =false;
        private bool IsTheSameSong=false;
        private bool IsFirstTimePlaying;
        private bool IsPaused;
        private bool IsStoped;
        private bool IsPlayingFromTheList = false;
        private string songAdress;
        

        //START/PAUSE BUTTON//////////
        public void PlayNstopButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsPlayingFromTheList && IsPlaying)
            {
                ChangeButtonImageToPause();
                IsPlayingFromTheList = false;
                return;
            }

            if (IsPlayingFromTheList && !IsPlaying)
            { 
                ChangeButtonImageToPlay();//меняем фотку кнопки на плей
                IsPlayingFromTheList = false;
                return;
            }
            if (IsPlaying)
            {
                PauseTheSong();
                ChangeButtonImageToPlay();//меняем фотку кнопки на плей
            }
            else
            {
                if (MusicListBox.SelectedIndex < 0 || IsStoped)
                {
                    MusicListBox.SelectedIndex = 0;
                }
                IsTheSameSong = true;
                PlayTheSong();
                ChangeButtonImageToPause();
            }
        }
        private string SongAdress
        {
            get
            {
                return songAdress = musicDirrectory + MusicListBox.SelectedItem.ToString();
            }
        }
        //STOP BUTTON//////////////////
        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsPlaying || IsPaused)
            {
                StopTheSong();
                ChangeButtonImageToPlay();
                (sender as Button).Background = Brushes.WhiteSmoke;
            }
        }
        private void MusicListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IsPlayingFromTheList = true;
            keyChecker = MusicListBox.SelectedIndex;
            IsTheSameSong = (keyChecker == key);
            if (IsTheSameSong && IsPlaying)
            {
                PauseTheSong();
                PlayNstopButton_OnClick(sender, null);
            }
            else
            {
                PlayTheSong();
                PlayNstopButton_OnClick(sender, null);
            }
        }
        private void MusicListBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ////сдесь запускаем трэк
            ////player.Open(new Uri(MusicListBox.SelectedItem.ToString()));
            ////player.Play();

            ////СДЕСЬ НАДО ЧТОБЫ ВЫПОЛНЯЛСЯ Playnstop_ButtonClick
            /////PlayNstopButton_OnClick((sender as Button),);
            //sender = PlayNstopButton;
            //MusicListBox.MouseLeftButtonDown += new MouseButtonEventHandler(PlayNstopButton_OnClick);
        }
        private void PlayTheSong()
        {
            if (IsPaused == false || !IsTheSameSong)
            {
                player.Open(new Uri(SongAdress));
                key = MusicListBox.SelectedIndex;
            }
            player.Play();
            IsPlaying = true;
        }
        private void PauseTheSong()
        {
            player.Pause();
            IsPlaying = false;
            IsPaused = true;
        }
        private void StopTheSong()
        {
            player.Stop();
            IsPlaying = false;
            IsStoped = true;
        }
        private void ChangeButtonImageToPause()
        {
            imageButton.Source = new BitmapImage(new Uri("/Resources/pause_icon.png", UriKind.Relative));//меняем фотку кнопки на паузу
        }

        private void ChangeButtonImageToPlay()
        {
            imageButton.Source = new BitmapImage(new Uri("/Resources/play_icon.png", UriKind.Relative));
        }

        private void ChangeButtonImageToStop()
        {
            imageButton.Source = new BitmapImage(new Uri("/Resources/stop.png", UriKind.Relative));
        }
    }
}
