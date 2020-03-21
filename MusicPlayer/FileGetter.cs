using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using Microsoft.Win32;

namespace MusicPlayer
{
    class FileGetter
    {
        private const string musicDirectory = @"D:\musicD\";

        ListBox musicListBox;
        
        DirectoryInfo directory = new DirectoryInfo(musicDirectory);//ДИРЕКТОРИЯ С МУЗЫКОЙ

        OpenFileDialog openFileDialog;

        internal string _songAdress;

        public FileGetter()
        {
            musicListBox = new ListBox();
            openFileDialog = new OpenFileDialog();
        }

        internal string SongAdress
        {
            get
            {
                return _songAdress = musicDirectory + GetSongAdress(musicListBox);
            }
        }

        private string GetSongAdress(ListBox listBox)
        {
            return listBox.SelectedItem.ToString();
        }

        internal void GetFilesToListBox(ListBox listBox)
        {
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo currentfile in files)
            {
                if (currentfile.Extension.ToString() == ".mp3")
                {
                    listBox.Items.Add(currentfile.Name);
                }
            }
        }
    }
}
