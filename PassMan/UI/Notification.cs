﻿using PassMan.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassMan.Utils
{
    public class Notification
    {
        /// <summary>
        /// Show notificaiton pop up message box with diferent case color.
        /// </summary>
        /// <param name="gridColor">red - Error| green -  Confirmation | orange - Warning</param>
        /// <param name="messageData"></param>
        public static void ShowNotificationInfo(string gridColor, string messageData)
        {
            GlobalVariables.gridColor = gridColor;
            GlobalVariables.messageData = messageData;
            PopMessage popMessage = new PopMessage();
            popMessage.ShowDialog();
        }
    }
}
