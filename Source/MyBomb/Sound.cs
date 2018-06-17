using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace MyBomb
{
    class Sound
    {
        WindowsMediaPlayer sound;

        public Sound(string filePath)
        {
            sound = new WindowsMediaPlayer();
            sound.URL = filePath;
            sound.controls.stop();
            
        }

        public void PlaySound()
        {
            sound.controls.play();
        }

        public void StopSound()
        {
            sound.controls.stop();
        }

        public void Pause()
        {
            sound.controls.pause();
        }

        public void ResumeSound()
        {
            if (sound.status == "Paused")
                sound.controls.play();
        }
    }
}
