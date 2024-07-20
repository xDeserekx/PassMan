using Microsoft.Win32;
using PassManLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PassMan.Views
{
    /// <summary>
    /// Interaction logic for MasterPassword.xaml
    /// </summary>
    public partial class MasterPassword : Window
    {

        public SecureString masterPassword;
        public MasterPassword()
        {
            InitializeComponent();
            vaultNameLBL.Text = Utils.GlobalVariables.vaultName;
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged; // Exit vault on suspend.
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch); // Exit vault on lock screen.
        }

        /// <summary>
        /// Check if PC enters sleep or hibernate mode and closes window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Suspend:
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Check if lock screen and closes window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
                this.Close();
        }

        /// <summary>
        /// Mouse window drag function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)    
                this.DragMove();
        }

        /// <summary>
        /// Pass the secure password from passwordbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmBTN_Click(object sender, RoutedEventArgs e)
        {
            var (isValid, message) = PasswordValidator.ValidatePassword(masterPasswordPWD.Password);
            if (!isValid)
            {
                Utils.Notification.ShowNotificationInfo("orange", "Password must be at least 12 characters, and must include at least one upper case letter, one lower case letter, one numeric digit, one special character and no space!");
                masterPasswordPWD.Clear();
                return;
            }
            Utils.GlobalVariables.masterPasswordCheck = true;
            Utils.MasterPasswordTimerStart.MasterPasswordCheck_TimerStart(MainWindow.s_masterPassCheckTimer);
            masterPassword = masterPasswordPWD.SecurePassword;
            this.Close();
        }

        /// <summary>
        /// Close button label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
 this.Close();
        }

        /// <summary>
        /// Show/hide master password from passwordbox using a textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHideMasterPassword(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                Utils.TextPassBoxChanges.ShowPassword(masterPasswordPWD, ShowMasterPassword);
            }
            else if (e.ButtonState == MouseButtonState.Released)
            {
                Utils.TextPassBoxChanges.HidePassword(masterPasswordPWD, ShowMasterPassword);
            }
        }

        /// <summary>
        /// Hide master password when mouse is moved over from button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ShowPassword_Click(object sender, RoutedEventArgs e)
        {
Utils.TextPassBoxChanges.HidePassword(masterPasswordPWD, ShowMasterPassword);
        }


    }
}
