using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace TrafficController
{
    public class ExtraFunctions
    {
        
        public static int RandomNumberBetween(int x, int y)
        {
            Random rnd = new Random();
            return rnd.Next(x, y);
        }
        public static void PlaySound(string sound)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Resources\sounds\" + sound + ".wav");
            player.Play();
        }
    }
}
