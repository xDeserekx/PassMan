using PassMan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PassMan.Utils
{
    public static class ClipBoardUtil
    {
        private static IClipboardService _clipboardService = ClipboardService.Instance;

        public static void SetClipboardService(IClipboardService clipboardService)
        {
            _clipboardService = clipboardService;
        }

        /// <summary>
        /// Check if password is copied on clipboard and clear if true only. 
        /// </summary>
        /// <param name="accPassword"></param>
        public static void ClearClipboard(string accPassword)
        {
            if (_clipboardService.ContainsText() && _clipboardService.GetText() == accPassword)
        {
            _clipboardService.Clear();
        }
        }
    }
}
