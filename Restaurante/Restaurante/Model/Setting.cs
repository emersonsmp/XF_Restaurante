using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Model
{
    public static class Setting
    {
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }


        private const string UserNameKey = "username_key";
        private static readonly string UserNameDefault = string.Empty;
        public static string UserName
        {
            //get { return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault); }
            //set { AppSettings.AddOrUpdateValue<string>(UserNameKey, value); }
            get { return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault); }
            set { AppSettings.AddOrUpdateValue(UserNameKey, value); }
        }


        private const string UserPasswordKey = "userpassword_key";
        private static readonly string UserPasswordDefault = string.Empty;
        public static string UserPassword
        {
            //get { return AppSettings.GetValueOrDefault<string>(UserPasswordKey, UserPasswordDefault); }
            //set { AppSettings.AddOrUpdateValue<string>(UserPasswordKey, value); }
            get { return AppSettings.GetValueOrDefault(UserPasswordKey, UserPasswordDefault); }
            set { AppSettings.AddOrUpdateValue(UserPasswordKey, value); }
        }
    }
}
