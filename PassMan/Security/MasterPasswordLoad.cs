﻿using PassMan.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PassMan.Utils
{
   public class MasterPasswordLoad
    {
        /// <summary>
        /// Load master password form MasterPassword form after confirmation.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <returns></returns>
        public static SecureString LoadMasterPassword(string vaultName)
        {
            SecureString password;
            GlobalVariables.vaultName = vaultName;
            MasterPassword masterPassword = new MasterPassword();
            masterPassword.ShowDialog();
            password = masterPassword.masterPassword;
            masterPassword.masterPasswordPWD.Clear();
            masterPassword.masterPassword = null;
            return password;
        }
    }
}
