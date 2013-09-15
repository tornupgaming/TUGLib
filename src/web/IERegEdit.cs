using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace TUGLib.Web
{
    /// <summary>
    /// Genuinely can't remember where I got this code - absolute lifesaver for web browser programming though
    /// Accesses RegEdit for whatever program you're using and forces the webbrowser to use IE8/IE9 instead of fail debug IE
    /// </summary>
    public class IERegEdit
    {
        public static void UseIE9(string applicationExeName)
        {
            FixBrowserVersion(applicationExeName, 9000);
        }

        public static void UseIE8(string applicationExeName)
        {
            FixBrowserVersion(applicationExeName, 8000);
        }

        private static void FixBrowserVersion(string appName, int lvl)
        {
            SetRegistryValue("HKEY_LOCAL_MACHINE", appName + ".exe", lvl);
            SetRegistryValue("HKEY_LOCAL_MACHINE", appName + ".exe", lvl);
            SetRegistryValue("HKEY_CURRENT_USER", appName + ".vshost.exe", lvl);
            SetRegistryValue("HKEY_CURRENT_USER", appName + ".vshost.exe", lvl);
        }

        private static void SetRegistryValue(string root, string appName, int lvl)
        {
            try
            {
                Registry.SetValue(root + @"\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, lvl);
            }
            catch (Exception)
            {
                // some config will hit access rights exceptions
                // this is why we try with both LOCAL_MACHINE and CURRENT_USER
            }
        }
    }
}
