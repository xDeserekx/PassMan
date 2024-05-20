using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PassMan.Utils
{
    public class WindowCloser
    {
        /// <summary>
        /// Close current opened WPF window.
        /// </summary>
        /// <param name="windowXmlName"></param>
        public static void CloseWindow(string windowXmlName)
        {
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Name == windowXmlName)
                {
                    w.Close();
                }
            }
        }
    }
}
