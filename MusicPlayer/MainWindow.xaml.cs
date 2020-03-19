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

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// TODO: The keys isnt working
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DirectoryInfo directory = new DirectoryInfo("D:/musicD/");//ДИРЕКТОРИЯ С МУЗЫКОЙ
            

            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo currentfile in files)
            {
                MusicListBox.Items.Add(currentfile);
                MusicListBox.Items.Add(MusicListBox.Items.CurrentPosition.ToString());
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
        private bool IsPlayingFromTheList=false;

        //START/PAUSE BUTTON//////////
        public void PlayNstopButton_OnClick(object sender, RoutedEventArgs e)
        {

            //if ( IsPlaying==true && IsTheSameSong==true )
            //{
            //    player.Pause();
            //    imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/play_icon.png"));//меняем фотку кнопки на плей
            //    IsPlaying = false;//флаг паузы
            //    return;
            //}

            //if (i == 0)
            //{
            //    //(sender as Button).Background = Brushes.Yellow;

            //    //player.Open(new Uri("C:/Users/Serge/source/repos/MusicPlayer/MusicSourse/Yung_Lean_Afganistan.mp3", UriKind.Relative));
            //    // player.Open(new Uri(MusicListBox.SelectedItem.ToString()));
            //    //player.Open(new Uri(MusicListBox.SelectedItem.ToString()/*, UriKind.Relative*/));
            //}

            //if (true)
            //{
            //    player.Play();
            //    imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/pause_icon.png"));//меняем фотку кнопки на паузу
            //    IsPlaying = true; //ставим флаг проигрыша
            //}
            if (IsPlayingFromTheList && IsPlaying)
            {
                imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/pause_icon.png"));//меняем фотку кнопки на паузу
                IsPlayingFromTheList = false;
                return;
            }

            if (IsPlayingFromTheList && !IsPlaying)
            {

                imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/play_icon.png"));//меняем фотку кнопки на плей
                IsPlayingFromTheList = false;
                return;
            }
            if (IsPlaying)
            {
                PauseTheSong();
                imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/play_icon.png"));//меняем фотку кнопки на плей
            }
            else
            {
                if (MusicListBox.SelectedIndex < 0 || IsStoped)
                {
                    MusicListBox.SelectedIndex = 0;
                }

                IsTheSameSong = true;
                PlayTheSong();
                imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/pause_icon.png"));//меняем фотку кнопки на паузу
            }

            

           

        }

        //private void PlayNstopButton_OnMouseEnter(object sender, MouseEventArgs e)//собыите при наведение мыши на кнопку пуск/пауза (MouseEnter xaml)
        //{
        //    (sender as Button).Background = Brushes.Yellow;
        //}

        //STOP BUTTON//////////////////
        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsPlaying || IsPaused)
            {
                //player.Stop();
                //player.Close();
                //i = 0;
                //IsPlaying = false;
                //sender = PlayNstopButton;
                StopTheSong();
                imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/play_icon.png"));//меняем фотку кнопки на плей
                (sender as Button).Background = Brushes.WhiteSmoke;
            }
        }

        private void MusicListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IsPlayingFromTheList = true;
            keyChecker = MusicListBox.SelectedIndex;
            IsTheSameSong = (keyChecker == key);
            // MusicListBox.MouseDoubleClick += new MouseButtonEventHandler(PlayNstopButton_OnClick);
            if (IsTheSameSong && IsPlaying)
            {
                PauseTheSong();
                PlayNstopButton_OnClick(sender, null);
            }
            else
            {
                PlayTheSong();
                PlayNstopButton_OnClick(sender,null);
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
                player.Open(new Uri(MusicListBox.SelectedItem.ToString()));
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
            //player.Close();
            IsPlaying = false;
            IsStoped = true;
        }
    }
}
