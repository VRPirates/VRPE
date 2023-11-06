namespace VRPE_Installer
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.topLabel = new System.Windows.Forms.Label();
            this.titleBar = new System.Windows.Forms.Panel();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.themeChangerButton = new VRPE_Installer.CustomButton();
            this.backButton = new VRPE_Installer.CustomButton();
            this.nextButton = new VRPE_Installer.CustomButton();
            this.rookiePathOpen = new VRPE_Installer.CustomButton();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.rookieButton = new VRPE_Installer.CustomButton();
            this.rookiePCVRButton = new VRPE_Installer.CustomButton();
            this.vrpguiButton = new VRPE_Installer.CustomButton();
            this.shortcutmakerButton = new VRPE_Installer.CustomButton();
            this.rookiePathLabel = new System.Windows.Forms.Label();
            this.wikiLink = new System.Windows.Forms.LinkLabel();
            this.LaunchRookie = new VRPE_Installer.CustomButton();
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.rookieFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.vrpGUIFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.resilioFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.resiliotoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rookietoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.VRPGUItoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.firewalltoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.customFoldertooltip = new System.Windows.Forms.ToolTip(this.components);
            this.openPathtoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.launchRookietoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rainbow = new System.Windows.Forms.Timer(this.components);
            this.rainbowBorderTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rainbowBorderLeft = new System.Windows.Forms.Panel();
            this.rainbowBorderRight = new System.Windows.Forms.Panel();
            this.rainbowBorderBottom = new System.Windows.Forms.Panel();
            this.rainbowBorder = new System.Windows.Forms.Timer(this.components);
            this.shortcutmakerFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.shortcutmakerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.titleBar.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.flowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.BackColor = System.Drawing.Color.Transparent;
            this.topLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLabel.ForeColor = System.Drawing.Color.White;
            this.topLabel.Location = new System.Drawing.Point(10, 7);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(78, 15);
            this.topLabel.TabIndex = 0;
            this.topLabel.Text = "VRPE Installer";
            this.topLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.titleBar.Controls.Add(this.minimizeButton);
            this.titleBar.Controls.Add(this.closeButton);
            this.titleBar.Controls.Add(this.topLabel);
            this.titleBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titleBar.Location = new System.Drawing.Point(-1, -1);
            this.titleBar.Name = "titleBar";
            this.titleBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.titleBar.Size = new System.Drawing.Size(896, 28);
            this.titleBar.TabIndex = 1;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onMouseDown);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.minimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Location = new System.Drawing.Point(806, -2);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(28, 22);
            this.minimizeButton.TabIndex = 2;
            this.minimizeButton.TabStop = false;
            this.minimizeButton.Text = "-";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(840, -2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 22);
            this.closeButton.TabIndex = 3;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPanel.Controls.Add(this.themeChangerButton);
            this.contentPanel.Controls.Add(this.backButton);
            this.contentPanel.Controls.Add(this.nextButton);
            this.contentPanel.Controls.Add(this.rookiePathOpen);
            this.contentPanel.Controls.Add(this.flowPanel);
            this.contentPanel.Controls.Add(this.rookiePathLabel);
            this.contentPanel.Controls.Add(this.wikiLink);
            this.contentPanel.Controls.Add(this.LaunchRookie);
            this.contentPanel.Controls.Add(this.downloadProgress);
            this.contentPanel.Controls.Add(this.welcomeLabel);
            this.contentPanel.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentPanel.Location = new System.Drawing.Point(23, 80);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(844, 359);
            this.contentPanel.TabIndex = 2;
            // 
            // themeChangerButton
            // 
            this.themeChangerButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.themeChangerButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.themeChangerButton.BackColor = System.Drawing.Color.Transparent;
            this.themeChangerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.themeChangerButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.themeChangerButton.ForeColor = System.Drawing.Color.White;
            this.themeChangerButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.themeChangerButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.themeChangerButton.Location = new System.Drawing.Point(3, 326);
            this.themeChangerButton.Name = "themeChangerButton";
            this.themeChangerButton.Radius = 5;
            this.themeChangerButton.Size = new System.Drawing.Size(117, 28);
            this.themeChangerButton.Stroke = true;
            this.themeChangerButton.StrokeColor = System.Drawing.Color.Transparent;
            this.themeChangerButton.TabIndex = 26;
            this.themeChangerButton.Text = "LIGHT MODE";
            this.themeChangerButton.Transparency = false;
            this.themeChangerButton.Click += new System.EventHandler(this.themeChangerButton_Click);
            this.themeChangerButton.MouseEnter += new System.EventHandler(this.themeChangerButton_MouseEnter);
            this.themeChangerButton.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // backButton
            // 
            this.backButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.backButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.backButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.backButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.backButton.Location = new System.Drawing.Point(767, 326);
            this.backButton.Name = "backButton";
            this.backButton.Radius = 5;
            this.backButton.Size = new System.Drawing.Size(72, 28);
            this.backButton.Stroke = true;
            this.backButton.StrokeColor = System.Drawing.Color.Transparent;
            this.backButton.TabIndex = 25;
            this.backButton.Text = "BACK";
            this.backButton.Transparency = false;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.backButton.MouseEnter += new System.EventHandler(this.backButton_MouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // nextButton
            // 
            this.nextButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.nextButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.nextButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.nextButton.ForeColor = System.Drawing.Color.White;
            this.nextButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.nextButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.nextButton.Location = new System.Drawing.Point(767, 326);
            this.nextButton.Name = "nextButton";
            this.nextButton.Radius = 5;
            this.nextButton.Size = new System.Drawing.Size(72, 28);
            this.nextButton.Stroke = true;
            this.nextButton.StrokeColor = System.Drawing.Color.Transparent;
            this.nextButton.TabIndex = 24;
            this.nextButton.Text = "NEXT";
            this.nextButton.Transparency = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            this.nextButton.MouseEnter += new System.EventHandler(this.nextButton_MouseEnter);
            this.nextButton.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // rookiePathOpen
            // 
            this.rookiePathOpen.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rookiePathOpen.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rookiePathOpen.BackColor = System.Drawing.Color.Transparent;
            this.rookiePathOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rookiePathOpen.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rookiePathOpen.ForeColor = System.Drawing.Color.White;
            this.rookiePathOpen.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rookiePathOpen.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rookiePathOpen.Location = new System.Drawing.Point(3, 292);
            this.rookiePathOpen.Name = "rookiePathOpen";
            this.rookiePathOpen.Radius = 5;
            this.rookiePathOpen.Size = new System.Drawing.Size(117, 28);
            this.rookiePathOpen.Stroke = true;
            this.rookiePathOpen.StrokeColor = System.Drawing.Color.Transparent;
            this.rookiePathOpen.TabIndex = 23;
            this.rookiePathOpen.Text = "OPEN PATH";
            this.rookiePathOpen.Transparency = false;
            this.rookiePathOpen.Visible = false;
            this.rookiePathOpen.Click += new System.EventHandler(this.rookiePathOpen_Click);
            this.rookiePathOpen.MouseEnter += new System.EventHandler(this.rookiePathOpen_MouseHover);
            this.rookiePathOpen.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // flowPanel
            // 
            this.flowPanel.Controls.Add(this.label1);
            this.flowPanel.Controls.Add(this.rookieButton);
            this.flowPanel.Controls.Add(this.rookiePCVRButton);
            this.flowPanel.Controls.Add(this.vrpguiButton);
            this.flowPanel.Controls.Add(this.shortcutmakerButton);
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanel.Location = new System.Drawing.Point(284, 6);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(266, 217);
            this.flowPanel.TabIndex = 17;
            this.flowPanel.TabStop = true;
            this.flowPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 35);
            this.label1.TabIndex = 16;
            this.label1.Text = "DOWNLOAD AND INSTALL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rookieButton
            // 
            this.rookieButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rookieButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rookieButton.BackColor = System.Drawing.Color.Transparent;
            this.rookieButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rookieButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rookieButton.ForeColor = System.Drawing.Color.White;
            this.rookieButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rookieButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rookieButton.Location = new System.Drawing.Point(3, 38);
            this.rookieButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.rookieButton.Name = "rookieButton";
            this.rookieButton.Radius = 5;
            this.rookieButton.Size = new System.Drawing.Size(263, 38);
            this.rookieButton.Stroke = true;
            this.rookieButton.StrokeColor = System.Drawing.Color.Transparent;
            this.rookieButton.TabIndex = 18;
            this.rookieButton.Text = "ROOKIE";
            this.rookieButton.Transparency = false;
            this.rookieButton.Click += new System.EventHandler(this.rookieButton_Click);
            this.rookieButton.MouseEnter += new System.EventHandler(this.rookieButton_MouseHover);
            this.rookieButton.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // rookiePCVRButton
            // 
            this.rookiePCVRButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rookiePCVRButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.rookiePCVRButton.BackColor = System.Drawing.Color.Transparent;
            this.rookiePCVRButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rookiePCVRButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rookiePCVRButton.ForeColor = System.Drawing.Color.White;
            this.rookiePCVRButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rookiePCVRButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rookiePCVRButton.Location = new System.Drawing.Point(3, 82);
            this.rookiePCVRButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.rookiePCVRButton.Name = "rookiePCVRButton";
            this.rookiePCVRButton.Radius = 5;
            this.rookiePCVRButton.Size = new System.Drawing.Size(263, 38);
            this.rookiePCVRButton.Stroke = true;
            this.rookiePCVRButton.StrokeColor = System.Drawing.Color.Transparent;
            this.rookiePCVRButton.TabIndex = 22;
            this.rookiePCVRButton.Text = "ROOKIE-PCVR";
            this.rookiePCVRButton.Transparency = false;
            this.rookiePCVRButton.Click += new System.EventHandler(this.rookiePCVRButton_Click);
            this.rookiePCVRButton.MouseEnter += new System.EventHandler(this.rookiePCVRButton_MouseHover);
            this.rookiePCVRButton.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // vrpguiButton
            // 
            this.vrpguiButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.vrpguiButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.vrpguiButton.BackColor = System.Drawing.Color.Transparent;
            this.vrpguiButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.vrpguiButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.vrpguiButton.ForeColor = System.Drawing.Color.White;
            this.vrpguiButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.vrpguiButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.vrpguiButton.Location = new System.Drawing.Point(3, 126);
            this.vrpguiButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.vrpguiButton.Name = "vrpguiButton";
            this.vrpguiButton.Radius = 5;
            this.vrpguiButton.Size = new System.Drawing.Size(263, 38);
            this.vrpguiButton.Stroke = true;
            this.vrpguiButton.StrokeColor = System.Drawing.Color.Transparent;
            this.vrpguiButton.TabIndex = 19;
            this.vrpguiButton.Text = "VRP-GUI";
            this.vrpguiButton.Transparency = false;
            this.vrpguiButton.Click += new System.EventHandler(this.vrpguiButton_Click);
            this.vrpguiButton.MouseEnter += new System.EventHandler(this.vrpguiButton_MouseHover);
            this.vrpguiButton.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // shortcutmakerButton
            // 
            this.shortcutmakerButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.shortcutmakerButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.shortcutmakerButton.BackColor = System.Drawing.Color.Transparent;
            this.shortcutmakerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.shortcutmakerButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.shortcutmakerButton.ForeColor = System.Drawing.Color.White;
            this.shortcutmakerButton.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.shortcutmakerButton.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.shortcutmakerButton.Location = new System.Drawing.Point(3, 170);
            this.shortcutmakerButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.shortcutmakerButton.Name = "shortcutmakerButton";
            this.shortcutmakerButton.Radius = 5;
            this.shortcutmakerButton.Size = new System.Drawing.Size(263, 38);
            this.shortcutmakerButton.Stroke = true;
            this.shortcutmakerButton.StrokeColor = System.Drawing.Color.Transparent;
            this.shortcutmakerButton.TabIndex = 20;
            this.shortcutmakerButton.Text = "SHORTCUT MAKER";
            this.shortcutmakerButton.Transparency = false;
            this.shortcutmakerButton.Click += new System.EventHandler(this.shortcutmakerButton_Click);
            this.shortcutmakerButton.MouseEnter += new System.EventHandler(this.shortcutmakerButton_MouseEnter);
            this.shortcutmakerButton.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // rookiePathLabel
            // 
            this.rookiePathLabel.AutoEllipsis = true;
            this.rookiePathLabel.AutoSize = true;
            this.rookiePathLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rookiePathLabel.ForeColor = System.Drawing.Color.White;
            this.rookiePathLabel.Location = new System.Drawing.Point(128, 283);
            this.rookiePathLabel.MaximumSize = new System.Drawing.Size(670, 0);
            this.rookiePathLabel.Name = "rookiePathLabel";
            this.rookiePathLabel.Size = new System.Drawing.Size(0, 15);
            this.rookiePathLabel.TabIndex = 12;
            this.rookiePathLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // wikiLink
            // 
            this.wikiLink.ActiveLinkColor = System.Drawing.Color.Gray;
            this.wikiLink.AutoSize = true;
            this.wikiLink.BackColor = System.Drawing.Color.Transparent;
            this.wikiLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wikiLink.LinkColor = System.Drawing.Color.White;
            this.wikiLink.Location = new System.Drawing.Point(103, 218);
            this.wikiLink.Name = "wikiLink";
            this.wikiLink.Size = new System.Drawing.Size(102, 17);
            this.wikiLink.TabIndex = 0;
            this.wikiLink.TabStop = true;
            this.wikiLink.Text = "Official Wiki Link";
            this.wikiLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.wikiLink_LinkClicked);
            // 
            // LaunchRookie
            // 
            this.LaunchRookie.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.LaunchRookie.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.LaunchRookie.BackColor = System.Drawing.Color.Transparent;
            this.LaunchRookie.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.LaunchRookie.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.LaunchRookie.ForeColor = System.Drawing.Color.White;
            this.LaunchRookie.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.LaunchRookie.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.LaunchRookie.Location = new System.Drawing.Point(3, 258);
            this.LaunchRookie.Name = "LaunchRookie";
            this.LaunchRookie.Radius = 5;
            this.LaunchRookie.Size = new System.Drawing.Size(117, 28);
            this.LaunchRookie.Stroke = true;
            this.LaunchRookie.StrokeColor = System.Drawing.Color.Transparent;
            this.LaunchRookie.TabIndex = 22;
            this.LaunchRookie.Text = "LAUNCH ROOKIE";
            this.LaunchRookie.Transparency = false;
            this.LaunchRookie.Visible = false;
            this.LaunchRookie.Click += new System.EventHandler(this.LaunchRookie_Click);
            this.LaunchRookie.MouseEnter += new System.EventHandler(this.LaunchRookie_MouseHover);
            this.LaunchRookie.MouseLeave += new System.EventHandler(this.stopHoverEffect);
            // 
            // downloadProgress
            // 
            this.downloadProgress.Location = new System.Drawing.Point(3, 327);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(758, 26);
            this.downloadProgress.TabIndex = 8;
            this.downloadProgress.Visible = false;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(100, 112);
            this.welcomeLabel.MaximumSize = new System.Drawing.Size(650, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(645, 96);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to the official VRPE Installer, the next step will let you choose which p" +
    "rograms you want to install from our suite. ";
            // 
            // rookieFolderDialog
            // 
            this.rookieFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // vrpGUIFolderDialog
            // 
            this.vrpGUIFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // resilioFolderDialog
            // 
            this.resilioFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // resiliotoolTip
            // 
            this.resiliotoolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.resiliotoolTip.ToolTipTitle = "Downloads";
            // 
            // rookietoolTip
            // 
            this.rookietoolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.rookietoolTip.ToolTipTitle = "Downloads";
            // 
            // VRPGUItoolTip
            // 
            this.VRPGUItoolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.VRPGUItoolTip.ToolTipTitle = "Downloads";
            // 
            // firewalltoolTip
            // 
            this.firewalltoolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.firewalltoolTip.ToolTipTitle = "Selections";
            // 
            // customFoldertooltip
            // 
            this.customFoldertooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.customFoldertooltip.ToolTipTitle = "Selections";
            // 
            // rainbow
            // 
            this.rainbow.Interval = 5;
            this.rainbow.Tick += new System.EventHandler(this.rainbow_Tick);
            // 
            // rainbowBorderTop
            // 
            this.rainbowBorderTop.BackColor = System.Drawing.Color.White;
            this.rainbowBorderTop.Location = new System.Drawing.Point(23, 80);
            this.rainbowBorderTop.Name = "rainbowBorderTop";
            this.rainbowBorderTop.Size = new System.Drawing.Size(844, 1);
            this.rainbowBorderTop.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(-1, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 1);
            this.panel1.TabIndex = 15;
            // 
            // rainbowBorderLeft
            // 
            this.rainbowBorderLeft.BackColor = System.Drawing.Color.White;
            this.rainbowBorderLeft.Location = new System.Drawing.Point(23, 80);
            this.rainbowBorderLeft.Name = "rainbowBorderLeft";
            this.rainbowBorderLeft.Size = new System.Drawing.Size(1, 359);
            this.rainbowBorderLeft.TabIndex = 14;
            // 
            // rainbowBorderRight
            // 
            this.rainbowBorderRight.BackColor = System.Drawing.Color.White;
            this.rainbowBorderRight.Location = new System.Drawing.Point(866, 80);
            this.rainbowBorderRight.Name = "rainbowBorderRight";
            this.rainbowBorderRight.Size = new System.Drawing.Size(1, 359);
            this.rainbowBorderRight.TabIndex = 15;
            // 
            // rainbowBorderBottom
            // 
            this.rainbowBorderBottom.BackColor = System.Drawing.Color.White;
            this.rainbowBorderBottom.Location = new System.Drawing.Point(23, 438);
            this.rainbowBorderBottom.Name = "rainbowBorderBottom";
            this.rainbowBorderBottom.Size = new System.Drawing.Size(844, 1);
            this.rainbowBorderBottom.TabIndex = 15;
            // 
            // rainbowBorder
            // 
            this.rainbowBorder.Interval = 5;
            this.rainbowBorder.Tick += new System.EventHandler(this.rainbowBorder_Tick);
            // 
            // shortcutmakerFolderDialog
            // 
            this.shortcutmakerFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // shortcutmakerToolTip
            // 
            this.shortcutmakerToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.shortcutmakerToolTip.ToolTipTitle = "Downloads";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.BackgroundImage = global::VRPE_Installer.Properties.Resources.backgrounddark;
            this.ClientSize = new System.Drawing.Size(894, 502);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rainbowBorderBottom);
            this.Controls.Add(this.rainbowBorderRight);
            this.Controls.Add(this.rainbowBorderLeft);
            this.Controls.Add(this.rainbowBorderTop);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.titleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VRPE Installer";
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.flowPanel.ResumeLayout(false);
            this.flowPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.FolderBrowserDialog rookieFolderDialog;
        public System.Windows.Forms.ProgressBar downloadProgress;
        private System.Windows.Forms.FolderBrowserDialog vrpGUIFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog resilioFolderDialog;
        private System.Windows.Forms.LinkLabel wikiLink;
        private System.Windows.Forms.ToolTip resiliotoolTip;
        private System.Windows.Forms.ToolTip rookietoolTip;
        private System.Windows.Forms.ToolTip VRPGUItoolTip;
        private System.Windows.Forms.ToolTip customFoldertooltip;
        private System.Windows.Forms.ToolTip firewalltoolTip;
        private System.Windows.Forms.Label rookiePathLabel;
        private System.Windows.Forms.ToolTip openPathtoolTip;
        private System.Windows.Forms.ToolTip launchRookietoolTip;
        private System.Windows.Forms.Timer rainbow;
        private System.Windows.Forms.Panel rainbowBorderTop;
        private System.Windows.Forms.Panel rainbowBorderLeft;
        private System.Windows.Forms.Panel rainbowBorderRight;
        private System.Windows.Forms.Panel rainbowBorderBottom;
        private System.Windows.Forms.Timer rainbowBorder;
        private System.Windows.Forms.FolderBrowserDialog shortcutmakerFolderDialog;
        private System.Windows.Forms.ToolTip shortcutmakerToolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private CustomButton shortcutmakerButton;
        private CustomButton vrpguiButton;
        private CustomButton rookieButton;
        private CustomButton LaunchRookie;
        private CustomButton rookiePathOpen;
        private CustomButton nextButton;
        private CustomButton backButton;
        private System.Windows.Forms.Panel panel1;
        private CustomButton themeChangerButton;
        private CustomButton rookiePCVRButton;
    }
}