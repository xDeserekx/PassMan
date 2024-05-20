using Mkb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PassManTests.Util
{
    public class ClipboardClearText
    {
        private const string SetText = "brehrehrth4%Y&£%H£";
        [Theory]
        [InlineData(SetText, true)]
        [InlineData("test1", false)]
        public void ClearSpecificTextOnlyClipboard(string password, bool shouldBeClear)
        {
            ClipBoardManager.SetText(SetText);
            PassMan.Utils.ClipBoardUtil.ClearClipboard(password);
            Assert.Equal(shouldBeClear ? "" : SetText, ClipBoardManager.GetText());
        }
    }
}
