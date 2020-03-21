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
        FileGetter fileGetter =new FileGetter();
        Player player = new Player();

        public MainWindow()
        {
            InitializeComponent();
            fileGetter.GetFilesToListBox(MusicListBox);

            //DirectoryInfo directory = new DirectoryInfo("D:/musicD/");//ДИРЕКТОРИЯ С МУЗЫКОЙ
            //OpenFileDialog openFileDialog=new OpenFileDialog();
            //FileInfo[] files = directory.GetFiles();
            //foreach (FileInfo currentfile in files)
            //{
            //    if (currentfile.Extension.ToString() == ".mp3")
            //    {
            //        MusicListBox.Items.Add(currentfile.Name);
            //    }
            //}

        }

        //internal Player player =new Player();


        public void PlayNstopButton_OnClick(object sender, RoutedEventArgs e)
        {
            player.PlayOrPause();
        }


        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            player.StopOrNo();
        }

        private void MusicListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            player.PlayFromTheList();
        }
    }
}
