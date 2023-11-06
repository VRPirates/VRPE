using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace VRPE_Installer
{
    internal class Updater
    {
        public static string Repostory { get; set; }

        public static readonly string LocalVersion = "2.5";
        public static string currentVersion = string.Empty;
        public static string changelog = string.Empty;

        //Check if there is a new version of the VRPE
        private static bool IsUpdateAvailable()
        {
            HttpClient client = new HttpClient();
            try
            {
                currentVersion = Program.HttpClient.GetStringAsync($"https://raw.githubusercontent.com/VRPirates/VRPE/main/VRPE%20Installer/VRPE%20Installer/version").Result;
                changelog = Program.HttpClient.GetStringAsync($"https://raw.githubusercontent.com/VRPirates/VRPE/main/VRPE%20Installer/VRPE%20Installer/changelog.txt").Result;
                client.Dispose();
                currentVersion = currentVersion.Trim();
            }
            catch { return false; }
            return LocalVersion.Trim() != currentVersion;
        }

        //Call this to ask the user if they want to update
        public static void Update()
        {
            if (IsUpdateAvailable())
            {
                UpdateForm upForm = new UpdateForm();
                upForm.ShowDialog();
            }
        }

        public static void Melt()
        {
            Process.Start(new ProcessStartInfo()
            {
                Arguments = "/C choice /C Y /N /D Y /T 5 & Del \"" + Application.ExecutablePath + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
            Environment.Exit(0);
        }

        //If the user wants to update
        public static async void doUpdate()
        {
                WebClient fileClient = new WebClient();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                fileClient.DownloadFile($"https://github.com/VRPirates/VRPE/releases/download/v{currentVersion}/VRPE-Installer.exe", $"VRPE-Installer(v{currentVersion}).exe");
                fileClient.Dispose();
                Process.Start($"VRPE-Installer(v{currentVersion}).exe");
                //Delete current version
                Melt();
        }
    }
}