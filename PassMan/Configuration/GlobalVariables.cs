﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PassMan.Utils
{
    public  static class GlobalVariables
    {
        public static SecureString masterPassword { get; set; }
        public static SecureString newMasterPassword { get; set; }
        public static string applicationName { get; set; }
        public static string accountName { get; set; }
        public static string accountPassword { get; set; }
        public static string newAccountPassword { get; set; }
        public static bool deleteConfirmation = false;
        public static bool createConfirmation = false;
        public static bool importConfirmation = false;
        public static bool updatePwdConfirmation = false;
        public static bool closeAppConfirmation = false;
        public static string vaultName { get; set; }
        public static int vaultsCount { get; set; }
        public static string gridColor { get; set; }
        public static string messageData { get; set; }
        public static bool vaultChecks = false;
        public static bool vaultOpen = false;
        public static bool sharedVault = false;
        public static bool masterPasswordCheck = true;
        private static string s_rootPath = Path.GetPathRoot(Environment.SystemDirectory);
        private static readonly string s_accountName = Environment.UserName;
        public static readonly string passwordManagerDirectory = $"{s_rootPath}Users\\{s_accountName}\\AppData\\Local\\PassMan\\";
        public static readonly string registryPath = "SOFTWARE\\PassMan";
        public static readonly string jsonSharedVaults = Path.Combine(passwordManagerDirectory, "PassMan.Json");
        public static readonly string vaultExpireReg = "VaultExpireSession";
        public static int vaultExpireInterval { get; set; }
        public static ListView listView = new ListView();
    }
}
