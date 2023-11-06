using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace VRPE_Installer
{
    public partial class MainWindow : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")] public static extern bool ReleaseCapture(); [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public static string fixPath = @"\";
        public string normalTitle = "VRPE Installer";
        public static bool RSLPathExists;
        public static bool RookiePathExists;
        public static bool VRPGUIPathExists;
        public static bool runningProcess;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        // On Program start, set the RSL Path, create an HTTP Client to fetch the version number of Rookie and set the string, set bools true if files exist.
        public MainWindow()
        {
            #if DEBUG
            string osVersion = Environment.OSVersion.VersionString;
            string processor = Environment.ProcessorCount.ToString();
            string currentUser = WindowsIdentity.GetCurrent().Name;
            // Print paths, device dpi, and internet state to help with debugging
            bool IsInternetAvailable()
            {
                try
                {
                    int description;
                    return InternetGetConnectedState(out description, 0);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            string INTERNETSTATE;
            Debug.WriteLine("---------------------------------\nDEBUG MODE ENABLED\nPRINTING VALUES\n---------------------------------");

            string rookiePath = "";
            if (File.Exists("C:/RSL/RookiePath.txt"))
            {
                rookiePath = File.ReadLines("C:/RSL/RookiePath.txt").FirstOrDefault();
            }

            string vrpguiPath = "";
            if (File.Exists("C:/RSL/VRPGUIPath.txt"))
            {
                vrpguiPath = File.ReadLines("C:/RSL/VRPGUIPath.txt").FirstOrDefault();
            }

            Debug.WriteLine("PATHS\nRookie Path: " + rookiePath + "\nVRPGUI Path: " + vrpguiPath);

            Debug.WriteLine("\nDEVICE DPI: " + this.DeviceDpi / 96.0);
            Debug.WriteLine($"Operating System: {osVersion}");
            Debug.WriteLine($"Processor Count: {processor}");
            Debug.WriteLine($"Current User: {currentUser}");

            if (IsInternetAvailable())
            {
                INTERNETSTATE = " TRUE";
            }
            else
            {
                INTERNETSTATE = " FALSE";
            }

            Debug.WriteLine("\nINTERNET CONNECTION:" + INTERNETSTATE);
            #endif
            InitializeComponent();
            int scaleValueWidth = 891 * (this.DeviceDpi / 96);
            int scaleValueHeight = 502 * (this.DeviceDpi / 96);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, scaleValueWidth, scaleValueHeight, 25, 25));
            var RSLPATH = @"C:\RSL\";
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            rainbowBorder.Start();
            if (Directory.Exists(RSLPATH))
            {
                RSLPathExists = true;
            }
            if (File.Exists(@"C:/RSL/RookiePath.txt"))
            {
                RookiePathExists = true;
            }
            if (File.Exists(@"C:/RSL/VRPGUIPath.txt"))
            {
                VRPGUIPathExists = true;
            }
        }

        // Minimizes the program
        private void minimizeButton_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Closes the program
        private void closeButton_Click(object sender, System.EventArgs e)
        {
            if (!runningProcess)
            {
                Application.Exit();
                Close();
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to exit?\nThis will cancel any ongoing operation", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Application.Exit();
                    Close();
                }
            }
        }

        // Is needed to make the custom tab bar moveable
        private void onMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        // Goes to the main part of the installer with all the download buttons etc
        private void nextButton_Click(object sender, EventArgs e)
        {
            themeChangerButton.Hide(); flowPanel.Show(); wikiLink.Hide(); welcomeLabel.Hide(); backButton.Show(); nextButton.Hide(); rookieButton.Show(); vrpguiButton.Show(); resilioPathCheckbox.Show(); shortcutmakerButton.Show();
            if (RookiePathExists)
            {
                rookiePathLabel.Text = File.ReadLines(@"C:/RSL/RookiePath.txt").First();
                rookiePathLabel.Refresh();
                LaunchRookie.Show();
                rookiePathOpen.Show();
            }
        }
        // Just goes back to the welcoming screen on the form
        private void backButton_Click(object sender, EventArgs e)
        {
            themeChangerButton.Show(); flowPanel.Hide(); wikiLink.Show(); backButton.Hide(); nextButton.Show(); welcomeLabel.Show(); rookieButton.Hide(); vrpguiButton.Hide(); resilioPathCheckbox.Hide(); shortcutmakerButton.Hide();
            if (RookiePathExists)
            {
                rookiePathLabel.Text = "";
                LaunchRookie.Hide();
                rookiePathOpen.Hide();
            }
        }

        // Downloads Rookie and extracts the RSL.zip onto the selected install path.
        public async void rookieButton_Click(object sender, EventArgs e)
        {
            bool success;
            var neededIcon = "https://vrpirates.wiki/downloads/rookie.ico";
            var RSLPATH = @"C:\RSL\";
            if (rookieFolderDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedPath = rookieFolderDialog.SelectedPath;
                if (selectedPath.Contains("OneDrive"))
                {
                    DialogResult dialogResult = MessageBox.Show("VRPE has detected a OneDrive Path!\nAs OneDrive breaks Rookie the VRPE will not continue downloading.", "OneDrive Path Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var ver = Program.HttpClient.GetStringAsync("https://raw.githubusercontent.com/VRPirates/rookie/master/version").Result;
                runningProcess = true;
                EnableProcessbar(sender, e);
                topLabel.Text = "Downloading Rookie...";
                topLabel.Refresh();
                success = await Downloader.GetRookie(selectedPath, fixPath);
                topLabel.Text = "Extracting Rookie...";
                topLabel.Refresh();
                success = await Installer.InstallRookie(selectedPath, fixPath);
                topLabel.Text = normalTitle;
                topLabel.Refresh();
                RookiePathExists = true;
                if (RookiePathExists)
                {
                    rookiePathLabel.Text = File.ReadLines(@"C:/RSL/RookiePath.txt").First();
                    rookiePathLabel.Refresh();
                    LaunchRookie.Show();
                    rookiePathOpen.Show();
                }
                runningProcess = false;
                downloadProgress.Hide();
                if (success)
                {
                    DialogResult dialogResult = MessageBox.Show("Would you like to create a desktop shortcut and launch Rookie?", "Create Desktop Shortcut", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        success = await Downloader.GetIcons(RSLPATH, "ROOKIE.ico", neededIcon);
                        ShortcutMaker.CreateShortcutRookie(selectedPath, fixPath, ver);
                        Buttons.LaunchRookie();
                    }
                    if (success)
                    {
                        MessageBoxes.Finish();
                    }
                }
            }
        }

        public async void rookiePCVRButton_Click(object sender, EventArgs e)
        {
            bool success;
            var RSLPATH = @"C:\RSL\";
            if (rookieFolderDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedPath = rookieFolderDialog.SelectedPath;
                if (selectedPath.Contains("OneDrive"))
                {
                    DialogResult dialogResult = MessageBox.Show("VRPE has detected a OneDrive Path!\nAs OneDrive breaks Rookie the VRPE will not continue downloading.", "OneDrive Path Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                runningProcess = true;
                EnableProcessbar(sender, e);
                topLabel.Text = "Downloading Rookie PCVR...";
                topLabel.Refresh();
                success = await Downloader.GetRookiePCVR(selectedPath, fixPath);
                topLabel.Text = "Extracting Rookie PCVR...";
                topLabel.Refresh();
                success = await Installer.InstallRookiePCVR(selectedPath, fixPath);
                topLabel.Text = normalTitle;
                topLabel.Refresh();
                runningProcess = false;
                downloadProgress.Hide();
                if (success)
                {
                    MessageBoxes.Finish();
                    Buttons.rookiePCVRPathOpener(Path.Combine(selectedPath, "Rookie-PCVR"));
                }
            }
        }

        // Downloads VRP GUI
        private async void vrpguiButton_Click(object sender, EventArgs e)
        {
            bool success;
            var neededIcon = "https://vrpirates.wiki/downloads/rclone.ico";
            var RSLPATH = @"C:\RSL\";
            if (vrpGUIFolderDialog.ShowDialog() == DialogResult.OK)
            {
                runningProcess = true;
                var selectedPathVRPGUI = vrpGUIFolderDialog.SelectedPath;
                topLabel.Text = "Downloading VRP GUI...";
                topLabel.Refresh();
                EnableProcessbar(sender, e);
                success = await Downloader.GetIcons(RSLPATH, "RCLONE.ico", neededIcon);
                success = await Downloader.GetVRPGUI(selectedPathVRPGUI, fixPath);
                topLabel.Text = "Extracting VRP GUI...";
                topLabel.Refresh();
                success = await Installer.InstallVRPGUI(selectedPathVRPGUI, fixPath);
                ShortcutMaker.CreateShortcutVRPGUI(selectedPathVRPGUI, fixPath);
                topLabel.Text = normalTitle;
                topLabel.Refresh();
                runningProcess = false;
                downloadProgress.Hide();
                if (success)
                {
                    MessageBoxes.Finish();
                }
            }
        }

        // Shows the progressbar and enables its animation
        private void EnableProcessbar(object sender, EventArgs e)
        {
            downloadProgress.Show();
            downloadProgress.Invoke((Action)(() => { downloadProgress.Style = ProgressBarStyle.Marquee; }));
        }

        // Downloads Shortcut Maker
        private async void shortcutmakerButton_Click(object sender, EventArgs e)
        {
            bool success;
            var neededIcon = "https://vrpirates.wiki/downloads/sm.ico";
            var RSLPATH = @"C:\RSL\";
            if (shortcutmakerFolderDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedPathShortcutMaker = shortcutmakerFolderDialog.SelectedPath;
                runningProcess = true;
                EnableProcessbar(sender, e);
                topLabel.Text = "Downloading Shortcut Maker...";
                topLabel.Refresh();
                success = await Downloader.GetIcons(RSLPATH, "SM.ico", neededIcon);
                success = await Downloader.GetShortcutMaker(selectedPathShortcutMaker, fixPath);
                topLabel.Text = "Extracting Shortcut Maker...";
                topLabel.Refresh();
                success = await Installer.InstallShortcutMaker(selectedPathShortcutMaker, fixPath);
                ShortcutMaker.CreateShortcutShortcutMaker(selectedPathShortcutMaker, fixPath);
                topLabel.Text = normalTitle;
                topLabel.Refresh();
                runningProcess = false;
                downloadProgress.Hide();
                if (success)
                {
                    MessageBoxes.Finish();
                }
            }
        }

        // Opens a link to our wiki!
        private void wikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vrpirates.wiki/");
        }

        private void LaunchRookie_Click(object sender, EventArgs e)
        {
            Buttons.LaunchRookie();
        }

        // Opens the Path in which Rookie was last installed into.

        private void rookiePathOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Buttons.rookiePathOpener();
            }
            catch (Exception ex)
            {
                string message = $"{ex.Message}";
                string caption = "Error while opening!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Minimized Rainbow Effect, minimized cuz like cmon we dont need to waste 15 lines for some rainbow effect lol.
        int r = 224, g = 0, b = 0, id;
        int rr = 224, gg = 0, bb = 0;
        private void stopHoverEffect(object sender, EventArgs e) { r = 224; g = 0; b = 0; rainbow.Stop(); rookieButton.StrokeColor = Color.FromArgb(34, 34, 34); rookiePCVRButton.StrokeColor = Color.FromArgb(34, 34, 34); vrpguiButton.StrokeColor = Color.FromArgb(34, 34, 34); LaunchRookie.StrokeColor = Color.FromArgb(34, 34, 34); themeChangerButton.StrokeColor = Color.FromArgb(34, 34, 34); rookiePathOpen.StrokeColor = Color.FromArgb(34, 34, 34); backButton.StrokeColor = Color.FromArgb(34, 34, 34); nextButton.StrokeColor = Color.FromArgb(34, 34, 34); shortcutmakerButton.StrokeColor = Color.FromArgb(34, 34, 34); }
        private void vrpguiButton_MouseHover(object sender, EventArgs e) { id = 1; rainbow.Start(); }
        private void LaunchRookie_MouseHover(object sender, EventArgs e) { id = 3; rainbow.Start(); }
        private void rainbowBorder_Tick(object sender, EventArgs e) { rainbowBorderBottom.BackColor = Color.FromArgb(rr, gg, bb); rainbowBorderTop.BackColor = Color.FromArgb(rr, gg, bb); rainbowBorderLeft.BackColor = Color.FromArgb(rr, gg, bb); topLabel.ForeColor = Color.FromArgb(rr, gg, bb); panel1.BackColor = Color.FromArgb(rr, gg, bb); rainbowBorderRight.BackColor = Color.FromArgb(rr, gg, bb); if (rr > 0 && bb == 0) { rr--; gg++; } if (gg > 0 && rr == 0) { gg--; bb++; } if (bb > 0 && gg == 0) { bb--; rr++; } }
        private void shortcutmakerButton_MouseEnter(object sender, EventArgs e) { id = 7; rainbow.Start(); }


        // On Launch check for an update and change the VRPEs theme accordingly to what the lightmode boolean is set to.
        private void MainWindow_Shown(object sender, EventArgs e) { var lightrgbhoverbuttons = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234))))); var darkrgbhoverbuttons = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54))))); var lightrgbbuttons = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204))))); var lightrgbpanels = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))); var darkrgbpanels = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14))))); var darkrgbbuttons = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34))))); Updater.Update(); if (!Properties.Settings.Default.lightModeEnabled) { themeChangerButton.Text = "LIGHT MODE"; this.BackgroundImage = Properties.Resources.backgrounddark; backButton.Active1 = darkrgbhoverbuttons; backButton.Active2 = darkrgbhoverbuttons; nextButton.Active1 = darkrgbhoverbuttons; nextButton.Active2 = darkrgbhoverbuttons; rookieButton.Active1 = darkrgbhoverbuttons; rookieButton.Active2 = darkrgbhoverbuttons; rookiePCVRButton.Active1 = darkrgbhoverbuttons; rookiePCVRButton.Active2 = darkrgbhoverbuttons; vrpguiButton.Active1 = darkrgbhoverbuttons; vrpguiButton.Active2 = darkrgbhoverbuttons; shortcutmakerButton.Active1 = darkrgbhoverbuttons; shortcutmakerButton.Active2 = darkrgbhoverbuttons; themeChangerButton.Active1 = darkrgbhoverbuttons; themeChangerButton.Active2 = darkrgbhoverbuttons; LaunchRookie.Active1 = darkrgbhoverbuttons; LaunchRookie.Active2 = darkrgbhoverbuttons; rookiePathOpen.Active1 = darkrgbhoverbuttons; rookiePathOpen.Active2 = darkrgbhoverbuttons; backButton.Inactive1 = darkrgbbuttons; backButton.Inactive2 = darkrgbbuttons; backButton.ForeColor = Color.White; nextButton.Inactive1 = darkrgbbuttons; nextButton.Inactive2 = darkrgbbuttons; nextButton.ForeColor = Color.White; rookieButton.Inactive1 = darkrgbbuttons; rookieButton.Inactive2 = darkrgbbuttons; rookieButton.ForeColor = Color.White; rookiePCVRButton.Inactive1 = darkrgbbuttons; rookiePCVRButton.Inactive2 = darkrgbbuttons; rookiePCVRButton.ForeColor = Color.White; vrpguiButton.Inactive1 = darkrgbbuttons; vrpguiButton.Inactive2 = darkrgbbuttons; vrpguiButton.ForeColor = Color.White; shortcutmakerButton.Inactive1 = darkrgbbuttons; shortcutmakerButton.Inactive2 = darkrgbbuttons; shortcutmakerButton.ForeColor = Color.White; themeChangerButton.Inactive1 = darkrgbbuttons; themeChangerButton.Inactive2 = darkrgbbuttons; themeChangerButton.ForeColor = Color.White; LaunchRookie.Inactive1 = darkrgbbuttons; LaunchRookie.Inactive2 = darkrgbbuttons; LaunchRookie.ForeColor = Color.White; rookiePathOpen.Inactive1 = darkrgbbuttons; rookiePathOpen.Inactive2 = darkrgbbuttons; rookiePathOpen.ForeColor = Color.White; minimizeButton.BackColor = darkrgbbuttons; closeButton.BackColor = darkrgbbuttons; minimizeButton.ForeColor = Color.White; closeButton.ForeColor = Color.White; contentPanel.BackColor = darkrgbpanels; titleBar.BackColor = darkrgbpanels; contentPanel.ForeColor = Color.White; label1.ForeColor = Color.White; welcomeLabel.ForeColor = Color.White; wikiLink.LinkColor = Color.White; resilioPathCheckbox.ForeColor = Color.White; rookiePathLabel.ForeColor = Color.White; } if (Properties.Settings.Default.lightModeEnabled) { themeChangerButton.Text = "DARK MODE"; this.BackgroundImage = Properties.Resources.backgroundlight; backButton.Active1 = lightrgbhoverbuttons; backButton.Active2 = lightrgbhoverbuttons; nextButton.Active1 = lightrgbhoverbuttons; nextButton.Active2 = lightrgbhoverbuttons; rookieButton.Active1 = lightrgbhoverbuttons; rookieButton.Active2 = lightrgbhoverbuttons; rookiePCVRButton.Active1 = lightrgbhoverbuttons; rookiePCVRButton.Active2 = lightrgbhoverbuttons; vrpguiButton.Active1 = lightrgbhoverbuttons; vrpguiButton.Active2 = lightrgbhoverbuttons; shortcutmakerButton.Active1 = lightrgbhoverbuttons; shortcutmakerButton.Active2 = lightrgbhoverbuttons; themeChangerButton.Active1 = lightrgbhoverbuttons; themeChangerButton.Active2 = lightrgbhoverbuttons; LaunchRookie.Active1 = lightrgbhoverbuttons; LaunchRookie.Active2 = lightrgbhoverbuttons; rookiePathOpen.Active1 = lightrgbhoverbuttons; rookiePathOpen.Active2 = lightrgbhoverbuttons; backButton.Inactive1 = lightrgbbuttons; backButton.Inactive2 = lightrgbbuttons; backButton.ForeColor = Color.Black; nextButton.Inactive1 = lightrgbbuttons; nextButton.Inactive2 = lightrgbbuttons; nextButton.ForeColor = Color.Black; rookieButton.Inactive1 = lightrgbbuttons; rookieButton.Inactive2 = lightrgbbuttons; rookieButton.ForeColor = Color.Black; rookiePCVRButton.Inactive1 = lightrgbbuttons; rookiePCVRButton.Inactive2 = lightrgbbuttons; rookiePCVRButton.ForeColor = Color.Black; vrpguiButton.Inactive1 = lightrgbbuttons; vrpguiButton.Inactive2 = lightrgbbuttons; vrpguiButton.ForeColor = Color.Black; shortcutmakerButton.Inactive1 = lightrgbbuttons; shortcutmakerButton.Inactive2 = lightrgbbuttons; shortcutmakerButton.ForeColor = Color.Black; themeChangerButton.Inactive1 = lightrgbbuttons; themeChangerButton.Inactive2 = lightrgbbuttons; themeChangerButton.ForeColor = Color.Black; LaunchRookie.Inactive1 = lightrgbbuttons; LaunchRookie.Inactive2 = lightrgbbuttons; LaunchRookie.ForeColor = Color.Black; rookiePathOpen.Inactive1 = lightrgbbuttons; rookiePathOpen.Inactive2 = lightrgbbuttons; rookiePathOpen.ForeColor = Color.Black; minimizeButton.BackColor = lightrgbbuttons; closeButton.BackColor = lightrgbbuttons; minimizeButton.ForeColor = Color.Black; closeButton.ForeColor = Color.Black; contentPanel.BackColor = lightrgbpanels; titleBar.BackColor = lightrgbpanels; contentPanel.ForeColor = Color.Black; label1.ForeColor = Color.Black; welcomeLabel.ForeColor = Color.Black; wikiLink.LinkColor = Color.Black; resilioPathCheckbox.ForeColor = Color.Black; rookiePathLabel.ForeColor = Color.Black; } }

        private void themeChangerButton_Click(object sender, EventArgs e) { var lightrgbhoverbuttons = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234))))); var darkrgbhoverbuttons = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54))))); var lightrgbbuttons = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204))))); var lightrgbpanels = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))); var darkrgbpanels = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14))))); var darkrgbbuttons = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34))))); if (!Properties.Settings.Default.lightModeEnabled) { Properties.Settings.Default.lightModeEnabled = true; themeChangerButton.Text = "DARK MODE"; MainWindow.ActiveForm.BackgroundImage = Properties.Resources.backgroundlight; backButton.Active1 = lightrgbhoverbuttons; backButton.Active2 = lightrgbhoverbuttons; nextButton.Active1 = lightrgbhoverbuttons; nextButton.Active2 = lightrgbhoverbuttons; rookieButton.Active1 = lightrgbhoverbuttons; rookieButton.Active2 = lightrgbhoverbuttons; rookiePCVRButton.Active1 = lightrgbhoverbuttons; rookiePCVRButton.Active2 = lightrgbhoverbuttons; vrpguiButton.Active1 = lightrgbhoverbuttons; vrpguiButton.Active2 = lightrgbhoverbuttons; shortcutmakerButton.Active1 = lightrgbhoverbuttons; shortcutmakerButton.Active2 = lightrgbhoverbuttons; themeChangerButton.Active1 = lightrgbhoverbuttons; themeChangerButton.Active2 = lightrgbhoverbuttons; LaunchRookie.Active1 = lightrgbhoverbuttons; LaunchRookie.Active2 = lightrgbhoverbuttons; rookiePathOpen.Active1 = lightrgbhoverbuttons; rookiePathOpen.Active2 = lightrgbhoverbuttons; backButton.Inactive1 = lightrgbbuttons; backButton.Inactive2 = lightrgbbuttons; backButton.ForeColor = Color.Black; nextButton.Inactive1 = lightrgbbuttons; nextButton.Inactive2 = lightrgbbuttons; nextButton.ForeColor = Color.Black; rookieButton.Inactive1 = lightrgbbuttons; rookieButton.Inactive2 = lightrgbbuttons; rookieButton.ForeColor = Color.Black; rookiePCVRButton.Inactive1 = lightrgbbuttons; rookiePCVRButton.Inactive2 = lightrgbbuttons; rookiePCVRButton.ForeColor = Color.Black; vrpguiButton.Inactive1 = lightrgbbuttons; vrpguiButton.Inactive2 = lightrgbbuttons; vrpguiButton.ForeColor = Color.Black; shortcutmakerButton.Inactive1 = lightrgbbuttons; shortcutmakerButton.Inactive2 = lightrgbbuttons; shortcutmakerButton.ForeColor = Color.Black; themeChangerButton.Inactive1 = lightrgbbuttons; themeChangerButton.Inactive2 = lightrgbbuttons; themeChangerButton.ForeColor = Color.Black; LaunchRookie.Inactive1 = lightrgbbuttons; LaunchRookie.Inactive2 = lightrgbbuttons; LaunchRookie.ForeColor = Color.Black; rookiePathOpen.Inactive1 = lightrgbbuttons; rookiePathOpen.Inactive2 = lightrgbbuttons; rookiePathOpen.ForeColor = Color.Black; minimizeButton.BackColor = lightrgbbuttons; closeButton.BackColor = lightrgbbuttons; minimizeButton.ForeColor = Color.Black; closeButton.ForeColor = Color.Black; contentPanel.BackColor = lightrgbpanels; titleBar.BackColor = lightrgbpanels; contentPanel.ForeColor = Color.Black; label1.ForeColor = Color.Black; welcomeLabel.ForeColor = Color.Black; wikiLink.LinkColor = Color.Black; resilioPathCheckbox.ForeColor = Color.Black; rookiePathLabel.ForeColor = Color.Black; Properties.Settings.Default.Save(); } else { Properties.Settings.Default.lightModeEnabled = false; themeChangerButton.Text = "LIGHT MODE"; MainWindow.ActiveForm.BackgroundImage = Properties.Resources.backgrounddark; backButton.Active1 = darkrgbhoverbuttons; backButton.Active2 = darkrgbhoverbuttons; nextButton.Active1 = darkrgbhoverbuttons; nextButton.Active2 = darkrgbhoverbuttons; rookieButton.Active1 = darkrgbhoverbuttons; rookieButton.Active2 = darkrgbhoverbuttons; vrpguiButton.Active1 = darkrgbhoverbuttons; rookiePCVRButton.Active1 = darkrgbhoverbuttons; rookiePCVRButton.Active2 = darkrgbhoverbuttons; vrpguiButton.Active2 = darkrgbhoverbuttons; shortcutmakerButton.Active1 = darkrgbhoverbuttons; shortcutmakerButton.Active2 = darkrgbhoverbuttons; themeChangerButton.Active1 = darkrgbhoverbuttons; themeChangerButton.Active2 = darkrgbhoverbuttons; LaunchRookie.Active1 = darkrgbhoverbuttons; LaunchRookie.Active2 = darkrgbhoverbuttons; rookiePathOpen.Active1 = darkrgbhoverbuttons; rookiePathOpen.Active2 = darkrgbhoverbuttons; backButton.Inactive1 = darkrgbbuttons; backButton.Inactive2 = darkrgbbuttons; backButton.ForeColor = Color.White; nextButton.Inactive1 = darkrgbbuttons; nextButton.Inactive2 = darkrgbbuttons; nextButton.ForeColor = Color.White; rookieButton.Inactive1 = darkrgbbuttons; rookieButton.Inactive2 = darkrgbbuttons; rookieButton.ForeColor = Color.White; rookiePCVRButton.Inactive1 = darkrgbbuttons; rookiePCVRButton.Inactive2 = darkrgbbuttons; rookiePCVRButton.ForeColor = Color.White; vrpguiButton.Inactive1 = darkrgbbuttons; vrpguiButton.Inactive2 = darkrgbbuttons; vrpguiButton.ForeColor = Color.White; shortcutmakerButton.Inactive1 = darkrgbbuttons; shortcutmakerButton.Inactive2 = darkrgbbuttons; shortcutmakerButton.ForeColor = Color.White; themeChangerButton.Inactive1 = darkrgbbuttons; themeChangerButton.Inactive2 = darkrgbbuttons; themeChangerButton.ForeColor = Color.White; LaunchRookie.Inactive1 = darkrgbbuttons; LaunchRookie.Inactive2 = darkrgbbuttons; LaunchRookie.ForeColor = Color.White; rookiePathOpen.Inactive1 = darkrgbbuttons; rookiePathOpen.Inactive2 = darkrgbbuttons; rookiePathOpen.ForeColor = Color.White; minimizeButton.BackColor = darkrgbbuttons; closeButton.BackColor = darkrgbbuttons; minimizeButton.ForeColor = Color.White; closeButton.ForeColor = Color.White; contentPanel.BackColor = darkrgbpanels; titleBar.BackColor = darkrgbpanels; contentPanel.ForeColor = Color.White; label1.ForeColor = Color.White; welcomeLabel.ForeColor = Color.White; wikiLink.LinkColor = Color.White; resilioPathCheckbox.ForeColor = Color.White; rookiePathLabel.ForeColor = Color.White; Properties.Settings.Default.Save(); } }

        private void themeChangerButton_MouseEnter(object sender, EventArgs e)
        {
            id = 8; rainbow.Start(); 
        }

        private void backButton_MouseEnter(object sender, EventArgs e) { id = 5; rainbow.Start(); }
        private void nextButton_MouseEnter(object sender, EventArgs e) { id = 6; rainbow.Start(); }
        private void rookiePathOpen_MouseHover(object sender, EventArgs e) { id = 4; rainbow.Start(); }
        private void rookieButton_MouseHover(object sender, EventArgs e) { id = 0; rainbow.Start(); }
        private void rookiePCVRButton_MouseHover(object sender, EventArgs e) { id = 9; rainbow.Start(); }
        private void rainbow_Tick(object sender, EventArgs e)
        {
            if (id == 0) { rookieButton.StrokeColor = Color.FromArgb(r, g, b); }
            if (id == 1) { vrpguiButton.StrokeColor = Color.FromArgb(r, g, b); }
            if (id == 3) { LaunchRookie.StrokeColor = Color.FromArgb(r, g, b); }
            if (id == 4) { rookiePathOpen.StrokeColor = Color.FromArgb(r, g, b); }
            if (id == 5) { backButton.StrokeColor = Color.FromArgb(r, g, b); }
            if (id == 6) { nextButton.StrokeColor = Color.FromArgb(r, g, b); }
            if (id == 7) { shortcutmakerButton.StrokeColor = Color.FromArgb(r, g, b); };
            if (id == 8) { themeChangerButton.StrokeColor = Color.FromArgb(r, g, b); };
            if (id == 9) { rookiePCVRButton.StrokeColor = Color.FromArgb(r, g, b); };
            if (r > 0 && b == 0) { r--; g++; }
            if (g > 0 && r == 0) { g--; b++; }
            if (b > 0 && g == 0) { b--; r++; }
        }
    }
}