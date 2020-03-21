using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MusicPlayer
{
    static class ImageWorker
    {
        internal static void ChangeButtonImageToPause(ImageSource source)
        {
            source = new BitmapImage(new Uri("/Resources/pause_icon.png", UriKind.Relative));//меняем фотку кнопки на паузу
        }

        internal static void ChangeButtonImageToPlay(ImageSource source)
        {
            source = new BitmapImage(new Uri("/Resources/play_icon.png", UriKind.Relative));
        }

        internal static void ChangeButtonImageToStop(ImageSource source)
        {
            source = new BitmapImage(new Uri("/Resources/stop.png", UriKind.Relative));
        }
    }
}
