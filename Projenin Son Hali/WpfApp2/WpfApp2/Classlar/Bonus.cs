using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfApp2.Classlar
{
   public class Bonus
    {
        public static void SesCal()
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri("muzik/popup.wav", UriKind.Relative));
            mplayer.Play();
        }
        public static void PopupShow(Popup popup)
        {
            SesCal();

            popup.IsOpen = true;

            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(10)
            };

            timer.Tick += delegate (object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();
                if (popup.IsOpen) popup.IsOpen = false;
            };

            timer.Start();  

        }
    }
}
