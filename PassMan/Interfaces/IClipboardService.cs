using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassMan
{
    public interface IClipboardService
    {
        bool ContainsText();
        string GetText();
        void Clear();
    }
}
