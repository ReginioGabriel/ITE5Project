using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp7
{
    public static class Session
    {
        public static int CurrentUserId { get; set; }
        public static string CurrentUsername { get; set; }
        public static void Clear()
        {
            CurrentUserId = 0;
            CurrentUsername = null;
        }
    }
}
