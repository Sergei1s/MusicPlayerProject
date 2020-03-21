using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace MusicPlayer
{
    internal  class Player
    {
        internal MediaPlayer mediaplayer = new MediaPlayer();
        private bool _isPaused;
        private bool _isTheSameSong = false;
        private bool _isPlayingFromTheList = false;
        private int _key;
        private int keyChecker;
        private bool IsPlaying = false;
        private bool IsPaused;
        private bool IsStoped;

        ListBox musicListBox;
        MainWindow mainWindow;
        FileGetter fileGetter;

        public Player()
        {
            musicListBox = new ListBox();
            mainWindow = new MainWindow();
            fileGetter = new FileGetter();
        }

        public object sender;

        internal void PlayOrPause()
        {
            if (_isPlayingFromTheList)
            {
                if (IsPlaying)
                {
                    ImageWorker.ChangeButtonImageToPause(mainWindow.imageButton.Source);
                    _isPlayingFromTheList = false;
                    return;
                }
                if(!IsPlaying)
                {
                    ImageWorker.ChangeButtonImageToPlay(mainWindow.imageButton.Source);//меняем фотку кнопки на плей
                    _isPlayingFromTheList = false;
                    return;
                }
                
            }

            if (IsPlaying)
            {
                PauseTheSong();
                ImageWorker.ChangeButtonImageToPlay(mainWindow.imageButton.Source);//меняем фотку кнопки на плей
            }
            else
            {
                if (musicListBox.SelectedIndex < 0 || IsStoped)
                {
                    musicListBox.SelectedIndex = 0;
                }
                _isTheSameSong = true;
                PlayTheSong();
                ImageWorker.ChangeButtonImageToPause(mainWindow.imageButton.Source);
            }
        }

        internal void StopOrNo()
        {
            if (IsPlaying || IsPaused)
            {
                StopTheSong();
                ImageWorker.ChangeButtonImageToPlay(mainWindow.imageButton.Source);
            }
        }

        internal void PlayFromTheList()
        {
            _isPlayingFromTheList = true;
            keyChecker = musicListBox.SelectedIndex;
            _isTheSameSong = (keyChecker == _key);
            if (_isTheSameSong && IsPlaying)
            {
                PauseTheSong();
                mainWindow.PlayNstopButton_OnClick(sender, null);
            }
            else
            {
                PlayTheSong();
                mainWindow.PlayNstopButton_OnClick(sender, null);
            }
        }

        internal void PlayTheSong()
        {
            if (_isPaused == false || !_isTheSameSong)
            {
                mediaplayer.Open(new Uri(fileGetter.SongAdress));
                _key = musicListBox.SelectedIndex;
            }
            mediaplayer.Play();
            IsPlaying = true;
        }

        internal void PauseTheSong()
        {
            mediaplayer.Pause();
            IsPlaying = false;
            _isPaused = true;
        }

        internal void StopTheSong()
        {
            mediaplayer.Stop();
            IsPlaying = false;
            IsStoped = true;
        }
    }
}
