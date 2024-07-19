using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace PassMan.Services
{
    public class ClipboardService : IClipboardService
    {
        private static readonly ClipboardService _instance = new ClipboardService();

        private ClipboardService() { }
        public static ClipboardService Instance => _instance;
        public bool ContainsText() { return Clipboard.ContainsText(); }

        public string GetText() { return Clipboard.GetText(); }

        public void Clear() { Clipboard.Clear(); }
        
    }
}
