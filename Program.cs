using Microsoft.Win32;
using System;
using System.IO;

namespace Unity_Cache_Remover
{
    static class Program
    {

        /// <summary>
        /// // Project Name: Main
        /// // Description: Cache Removal Tool: {Server AUTH: api.outerspace.store}
        /// // Project Developer's: Josh(UrFingPoor), Fish(Fish0rgy), Kanna, Swordsith 
        /// </summary>
        [STAThread]

        public static void RemoveFolder(this DirectoryInfo directory)
        {
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }

        static void Main()
        {
            string vrchat = @"Computer\HKEY_CURRENT_USER\SOFTWARE\VRChat";
            string unitytech = @"Computer\HKEY_CURRENT_USER\SOFTWARE\Unity Technologies";
            string unity = @"Computer\HKEY_CURRENT_USER\SOFTWARE\Unity";
            string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LocalLowPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            var Unity = new DirectoryInfo(RoamingPath + @"/Unity");
            var UnityLocalLow = new DirectoryInfo(LocalLowPath + @"/Unity");
            var VRChatLocalLow = new DirectoryInfo(LocalLowPath + @"/VRChat");
            Console.WriteLine("Simple Unity Cache Remover | https://outerspace.store | Discord: .gg/copyandpasted");
            Console.WriteLine("Press any key to start...");
            Console.Read();
            RemoveFolder(Unity);
            RemoveFolder(UnityLocalLow);
            RemoveFolder(VRChatLocalLow);
            Console.WriteLine("Temp Folders Removed!");
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(vrchat, true)) { if (key == null) { } else { key.DeleteValue(vrchat); } }
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(vrchat, true)) { if (key == null) { } else { key.DeleteValue(unitytech); } }
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(vrchat, true)) { if (key == null) { } else { key.DeleteValue(unity); } }
            Console.WriteLine("Registry Keys Removed!");
        }
    }
}
