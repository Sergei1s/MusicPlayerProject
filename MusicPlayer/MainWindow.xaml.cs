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
using System.Windows.Media;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SoundPlayer soundPlayer;

        public MainWindow()
        {
            InitializeComponent();

        }
        private MediaPlayer player = new MediaPlayer();
        private int i = 0;//флаг полной остановки

        //START/PAUSE BUTTON//////////
        private void PlayNstopButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (i==2)
            {
                player.Pause();
                imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/play_icon.png"));//меняем фотку кнопки на плей
                i = 1;//флаг паузы
                return;
            }

            if (i == 0)
            {
                (sender as Button).Background = Brushes.Yellow;

                player.Open(new Uri("C:/Users/Serge/source/repos/MusicPlayer/MusicSourse/Yung_Lean_Afganistan.mp3", UriKind.Relative));
            }

            if (sender == PlayNstopButton)
            {
                player.Play();
                imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/pause_icon.png"));//меняем фотку кнопки на паузу
                i = 2;//ставим флаг проигрыша
            }
        }

        //private void PlayNstopButton_OnMouseEnter(object sender, MouseEventArgs e)//собыите при наведение мыши на кнопку пуск/пауза (MouseEnter xaml)
        //{
        //    (sender as Button).Background = Brushes.Yellow;
        //}

        //STOP BUTTON//////////////////
        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (i == 2 || i==1)
            {
                player.Stop();
                player.Close();
                i = 0;
                sender = PlayNstopButton;
                imageButton.Source = new BitmapImage(new Uri("C:/Users/Serge/source/repos/MusicPlayer/UISource/play_icon.png"));//меняем фотку кнопки на плей
                (sender as Button).Background = Brushes.WhiteSmoke;
            }
        }
    }
}
