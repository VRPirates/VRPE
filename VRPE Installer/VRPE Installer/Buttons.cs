using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VRPE_Installer
{
    public class Buttons
    {
        // As the method name suggests, this launches rookie, lol.
        public static void LaunchRookie()
        {
            var rookiePath = File.ReadLines(@"C:/RSL/RookiePath.txt").First();
            foreach (string fileName in Directory.GetFiles(rookiePath).Where(f => f.Contains("AndroidSideloader"))) {
                try
                {
                    ProcessStartInfo p = new ProcessStartInfo();
                    p.WorkingDirectory = rookiePath;
                    p.FileName = $"{fileName}";
                    p.CreateNoWindow = true;
                    Process startRookie = Process.Start(p);
                }
                catch (Exception ex)
                {
                    string message = $"{ex.Message}";
                    string caption = "Error when trying to launch Rookie!";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        // Opens the Path in which Rookie was last installed in.
        public static void rookiePathOpener()
        {
            var rookiePath = File.ReadLines(@"C:/RSL/RookiePath.txt").First();
            ProcessStartInfo p = new ProcessStartInfo
            {
                Arguments = rookiePath,
                FileName = "explorer.exe"
            };
            Process.Start(p);
        }
    }
}
