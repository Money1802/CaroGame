﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CaroGame
{
    class PlayMusic
    {
        private string PlayCommand;
        private bool isOpen;

        private static PlayMusic playMusic;
        public static PlayMusic Instance
        {
            get
            {
                if (playMusic == null)
                {
                    playMusic = new PlayMusic();
                }
                return playMusic;
            }
        }

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);

        public void ClosePlayer()
        {
            PlayCommand = "Close MediaFile";
            mciSendString(PlayCommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }

        public void OpenMediaFile(string strFileName)
        {
            PlayCommand = "Open \"" + strFileName + "\" alias MediaFile";
            mciSendString(PlayCommand, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        public void PlayMediaFile(bool loop)
        {
            if (isOpen)
            {
                PlayCommand = "Play MediaFile";
                if (loop)
                    PlayCommand += " REPEAT";
                mciSendString(PlayCommand, null, 0, IntPtr.Zero);
            }
        }
    }
}
