﻿using Microsoft.Azure;
using System;
using System.Configuration;

namespace InRule.CICD.Helpers
{
    public class SettingsManager
    {
        public static string Get(string settingName)
        {
            var isCloudRaw = ConfigurationManager.AppSettings["IsCloudBased"];
            bool isCloud;
            if (bool.TryParse(isCloudRaw, out isCloud))
            {
                if (isCloud)
                {
                    return CloudConfigurationManager.GetSetting(settingName);
                }
            }

            return ConfigurationManager.AppSettings[settingName] != null ? ConfigurationManager.AppSettings[settingName].Trim() : "";
        }
    }
}
