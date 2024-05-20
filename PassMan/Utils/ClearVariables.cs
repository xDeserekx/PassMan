using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassMan.Utils
{
    public class ClearVariables
    {
        /// <summary>
        /// Clear global variables.
        /// </summary>
        public static void VariablesClear()
        {
            GlobalVariables.applicationName = "";
            GlobalVariables.accountName = "";
            GlobalVariables.newAccountPassword = "";
            GlobalVariables.closeAppConfirmation = false;
            GlobalVariables.deleteConfirmation = false;
        }
    }
}
