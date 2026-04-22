namespace EyeCameraStreamer
{
    partial class EyeCameraStreamer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxCameras = new ComboBox();
            btnToggle = new Button();
            pictureBoxPreview = new PictureBox();
            txtPortLeft = new TextBox();
            txtPortRight = new TextBox();
            Label_LeftPort = new Label();
            Label_RightPort = new Label();
            Label_TargetFps = new Label();
            txtFps = new TextBox();
            ckbClahe = new CheckBox();
            txtPreview = new TextBox();
            StaticSetting = new GroupBox();
            Label_SizeX = new Label();
            txtH = new TextBox();
            txtW = new TextBox();
            Label_Size = new Label();
            Label_CameraId = new Label();
            EffectSetting = new GroupBox();
            sliderGamma = new TrackBar();
            ckbGamma = new CheckBox();
            sliderClahe = new TrackBar();
            ckbAutoStart = new CheckBox();
            ProcessTime = new Label();
            Address = new GroupBox();
            RightAddress = new TextBox();
            LeftAddress = new TextBox();
            ExternalOptions = new GroupBox();
            Label_ETVR = new Label();
            btnAffinityApply = new Button();
            txtAffinity = new TextBox();
            Label_Affinity = new Label();
            ckbETVR = new CheckBox();
            btnBrowse = new Button();
            txtETVRPath = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            StaticSetting.SuspendLayout();
            EffectSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sliderGamma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderClahe).BeginInit();
            Address.SuspendLayout();
            ExternalOptions.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxCameras
            // 
            comboBoxCameras.BackColor = Color.FromArgb(64, 64, 64);
            comboBoxCameras.FlatStyle = FlatStyle.Flat;
            comboBoxCameras.ForeColor = Color.White;
            comboBoxCameras.FormattingEnabled = true;
            comboBoxCameras.Location = new Point(12, 27);
            comboBoxCameras.Name = "comboBoxCameras";
            comboBoxCameras.Size = new Size(121, 23);
            comboBoxCameras.TabIndex = 0;
            // 
            // btnToggle
            // 
            btnToggle.BackColor = Color.FromArgb(64, 64, 64);
            btnToggle.FlatAppearance.BorderColor = Color.DimGray;
            btnToggle.FlatStyle = FlatStyle.Flat;
            btnToggle.ForeColor = Color.White;
            btnToggle.Location = new Point(12, 56);
            btnToggle.Name = "btnToggle";
            btnToggle.Size = new Size(121, 23);
            btnToggle.TabIndex = 1;
            btnToggle.Text = "Start";
            btnToggle.UseVisualStyleBackColor = false;
            btnToggle.Click += btnToggle_Click;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BackColor = SystemColors.ActiveCaptionText;
            pictureBoxPreview.Location = new Point(149, 20);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(600, 300);
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPreview.TabIndex = 2;
            pictureBoxPreview.TabStop = false;
            // 
            // txtPortLeft
            // 
            txtPortLeft.BackColor = Color.FromArgb(64, 64, 64);
            txtPortLeft.BorderStyle = BorderStyle.None;
            txtPortLeft.ForeColor = Color.White;
            txtPortLeft.Location = new Point(69, 59);
            txtPortLeft.Name = "txtPortLeft";
            txtPortLeft.Size = new Size(46, 16);
            txtPortLeft.TabIndex = 3;
            txtPortLeft.Text = "8080";
            txtPortLeft.TextAlign = HorizontalAlignment.Center;
            // 
            // txtPortRight
            // 
            txtPortRight.BackColor = Color.FromArgb(64, 64, 64);
            txtPortRight.BorderStyle = BorderStyle.None;
            txtPortRight.ForeColor = Color.White;
            txtPortRight.Location = new Point(69, 81);
            txtPortRight.Name = "txtPortRight";
            txtPortRight.Size = new Size(46, 16);
            txtPortRight.TabIndex = 4;
            txtPortRight.Text = "8081";
            txtPortRight.TextAlign = HorizontalAlignment.Center;
            // 
            // Label_LeftPort
            // 
            Label_LeftPort.AutoSize = true;
            Label_LeftPort.Location = new Point(7, 60);
            Label_LeftPort.Name = "Label_LeftPort";
            Label_LeftPort.Size = new Size(49, 15);
            Label_LeftPort.TabIndex = 5;
            Label_LeftPort.Text = "LeftPort";
            // 
            // Label_RightPort
            // 
            Label_RightPort.AutoSize = true;
            Label_RightPort.Location = new Point(6, 82);
            Label_RightPort.Name = "Label_RightPort";
            Label_RightPort.Size = new Size(57, 15);
            Label_RightPort.TabIndex = 6;
            Label_RightPort.Text = "RightPort";
            // 
            // Label_TargetFps
            // 
            Label_TargetFps.AutoSize = true;
            Label_TargetFps.Location = new Point(7, 104);
            Label_TargetFps.Name = "Label_TargetFps";
            Label_TargetFps.Size = new Size(56, 15);
            Label_TargetFps.TabIndex = 8;
            Label_TargetFps.Text = "TargetFps";
            // 
            // txtFps
            // 
            txtFps.BackColor = Color.FromArgb(64, 64, 64);
            txtFps.BorderStyle = BorderStyle.None;
            txtFps.ForeColor = Color.White;
            txtFps.Location = new Point(69, 103);
            txtFps.Name = "txtFps";
            txtFps.Size = new Size(46, 16);
            txtFps.TabIndex = 7;
            txtFps.Text = "30";
            txtFps.TextAlign = HorizontalAlignment.Center;
            // 
            // ckbClahe
            // 
            ckbClahe.AutoSize = true;
            ckbClahe.FlatStyle = FlatStyle.Flat;
            ckbClahe.Location = new Point(7, 22);
            ckbClahe.Name = "ckbClahe";
            ckbClahe.Size = new Size(52, 19);
            ckbClahe.TabIndex = 12;
            ckbClahe.Text = "Clahe";
            ckbClahe.UseVisualStyleBackColor = true;
            // 
            // txtPreview
            // 
            txtPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPreview.BackColor = SystemColors.ActiveCaptionText;
            txtPreview.BorderStyle = BorderStyle.None;
            txtPreview.Font = new Font("Yu Gothic UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 128);
            txtPreview.ForeColor = Color.White;
            txtPreview.Location = new Point(193, 141);
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.Size = new Size(513, 64);
            txtPreview.TabIndex = 13;
            txtPreview.Text = "PREVIEW PAUSED";
            txtPreview.TextAlign = HorizontalAlignment.Center;
            // 
            // StaticSetting
            // 
            StaticSetting.Controls.Add(Label_SizeX);
            StaticSetting.Controls.Add(txtH);
            StaticSetting.Controls.Add(txtW);
            StaticSetting.Controls.Add(Label_Size);
            StaticSetting.Controls.Add(Label_LeftPort);
            StaticSetting.Controls.Add(txtPortLeft);
            StaticSetting.Controls.Add(Label_RightPort);
            StaticSetting.Controls.Add(txtPortRight);
            StaticSetting.Controls.Add(Label_TargetFps);
            StaticSetting.Controls.Add(txtFps);
            StaticSetting.FlatStyle = FlatStyle.Flat;
            StaticSetting.ForeColor = Color.White;
            StaticSetting.Location = new Point(12, 108);
            StaticSetting.Name = "StaticSetting";
            StaticSetting.Size = new Size(121, 135);
            StaticSetting.TabIndex = 0;
            StaticSetting.TabStop = false;
            StaticSetting.Text = "Static Setting";
            // 
            // Label_SizeX
            // 
            Label_SizeX.BackColor = Color.Transparent;
            Label_SizeX.FlatStyle = FlatStyle.Flat;
            Label_SizeX.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Label_SizeX.Location = new Point(49, 37);
            Label_SizeX.Margin = new Padding(0);
            Label_SizeX.Name = "Label_SizeX";
            Label_SizeX.RightToLeft = RightToLeft.No;
            Label_SizeX.Size = new Size(24, 16);
            Label_SizeX.TabIndex = 16;
            Label_SizeX.Text = "x";
            Label_SizeX.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtH
            // 
            txtH.BackColor = Color.FromArgb(64, 64, 64);
            txtH.BorderStyle = BorderStyle.None;
            txtH.ForeColor = Color.White;
            txtH.Location = new Point(69, 37);
            txtH.Name = "txtH";
            txtH.Size = new Size(46, 16);
            txtH.TabIndex = 15;
            txtH.Text = "400";
            txtH.TextAlign = HorizontalAlignment.Center;
            // 
            // txtW
            // 
            txtW.BackColor = Color.FromArgb(64, 64, 64);
            txtW.BorderStyle = BorderStyle.None;
            txtW.ForeColor = Color.White;
            txtW.Location = new Point(7, 37);
            txtW.Name = "txtW";
            txtW.Size = new Size(46, 16);
            txtW.TabIndex = 14;
            txtW.Text = "800";
            txtW.TextAlign = HorizontalAlignment.Center;
            // 
            // Label_Size
            // 
            Label_Size.AutoSize = true;
            Label_Size.Location = new Point(6, 19);
            Label_Size.Name = "Label_Size";
            Label_Size.Size = new Size(27, 15);
            Label_Size.TabIndex = 13;
            Label_Size.Text = "Size";
            // 
            // Label_CameraId
            // 
            Label_CameraId.AutoSize = true;
            Label_CameraId.ForeColor = Color.White;
            Label_CameraId.Location = new Point(12, 9);
            Label_CameraId.Name = "Label_CameraId";
            Label_CameraId.Size = new Size(59, 15);
            Label_CameraId.TabIndex = 13;
            Label_CameraId.Text = "Camera Id";
            // 
            // EffectSetting
            // 
            EffectSetting.Controls.Add(sliderGamma);
            EffectSetting.Controls.Add(ckbGamma);
            EffectSetting.Controls.Add(sliderClahe);
            EffectSetting.Controls.Add(ckbClahe);
            EffectSetting.ForeColor = Color.White;
            EffectSetting.Location = new Point(12, 325);
            EffectSetting.Name = "EffectSetting";
            EffectSetting.Size = new Size(163, 71);
            EffectSetting.TabIndex = 17;
            EffectSetting.TabStop = false;
            EffectSetting.Text = "Effect Setting";
            // 
            // sliderGamma
            // 
            sliderGamma.AutoSize = false;
            sliderGamma.Location = new Point(65, 45);
            sliderGamma.Margin = new Padding(3, 0, 3, 3);
            sliderGamma.Maximum = 100;
            sliderGamma.Minimum = 20;
            sliderGamma.Name = "sliderGamma";
            sliderGamma.Size = new Size(92, 24);
            sliderGamma.TabIndex = 15;
            sliderGamma.TickStyle = TickStyle.None;
            sliderGamma.Value = 50;
            sliderGamma.Scroll += sliderGamma_Scroll;
            // 
            // ckbGamma
            // 
            ckbGamma.AutoSize = true;
            ckbGamma.FlatStyle = FlatStyle.Flat;
            ckbGamma.Location = new Point(7, 45);
            ckbGamma.Name = "ckbGamma";
            ckbGamma.Size = new Size(63, 19);
            ckbGamma.TabIndex = 14;
            ckbGamma.Text = "Gamma";
            ckbGamma.UseVisualStyleBackColor = true;
            // 
            // sliderClahe
            // 
            sliderClahe.AutoSize = false;
            sliderClahe.Location = new Point(65, 22);
            sliderClahe.Margin = new Padding(3, 0, 3, 3);
            sliderClahe.Maximum = 100;
            sliderClahe.Minimum = 1;
            sliderClahe.Name = "sliderClahe";
            sliderClahe.Size = new Size(92, 24);
            sliderClahe.TabIndex = 13;
            sliderClahe.TickStyle = TickStyle.None;
            sliderClahe.Value = 50;
            sliderClahe.Scroll += sliderClahe_Scroll;
            // 
            // ckbAutoStart
            // 
            ckbAutoStart.AutoSize = true;
            ckbAutoStart.FlatStyle = FlatStyle.Flat;
            ckbAutoStart.ForeColor = Color.White;
            ckbAutoStart.Location = new Point(12, 83);
            ckbAutoStart.Name = "ckbAutoStart";
            ckbAutoStart.Size = new Size(73, 19);
            ckbAutoStart.TabIndex = 13;
            ckbAutoStart.Text = "AutoStart";
            ckbAutoStart.UseVisualStyleBackColor = true;
            // 
            // ProcessTime
            // 
            ProcessTime.AutoSize = true;
            ProcessTime.BackColor = Color.Black;
            ProcessTime.FlatStyle = FlatStyle.Flat;
            ProcessTime.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            ProcessTime.ForeColor = Color.White;
            ProcessTime.ImageAlign = ContentAlignment.BottomLeft;
            ProcessTime.Location = new Point(149, 295);
            ProcessTime.Name = "ProcessTime";
            ProcessTime.Size = new Size(70, 25);
            ProcessTime.TabIndex = 17;
            ProcessTime.Text = "0.00ms";
            ProcessTime.TextAlign = ContentAlignment.BottomLeft;
            // 
            // Address
            // 
            Address.Controls.Add(RightAddress);
            Address.Controls.Add(LeftAddress);
            Address.ForeColor = Color.White;
            Address.Location = new Point(12, 249);
            Address.Name = "Address";
            Address.Size = new Size(121, 70);
            Address.TabIndex = 18;
            Address.TabStop = false;
            Address.Text = "Address";
            // 
            // RightAddress
            // 
            RightAddress.BackColor = Color.FromArgb(64, 64, 64);
            RightAddress.BorderStyle = BorderStyle.None;
            RightAddress.ForeColor = Color.White;
            RightAddress.Location = new Point(8, 43);
            RightAddress.Margin = new Padding(5);
            RightAddress.Name = "RightAddress";
            RightAddress.ReadOnly = true;
            RightAddress.Size = new Size(105, 16);
            RightAddress.TabIndex = 1;
            // 
            // LeftAddress
            // 
            LeftAddress.BackColor = Color.FromArgb(64, 64, 64);
            LeftAddress.BorderStyle = BorderStyle.None;
            LeftAddress.ForeColor = Color.White;
            LeftAddress.Location = new Point(8, 17);
            LeftAddress.Margin = new Padding(5);
            LeftAddress.Name = "LeftAddress";
            LeftAddress.ReadOnly = true;
            LeftAddress.Size = new Size(105, 16);
            LeftAddress.TabIndex = 0;
            // 
            // ExternalOptions
            // 
            ExternalOptions.Controls.Add(Label_ETVR);
            ExternalOptions.Controls.Add(btnAffinityApply);
            ExternalOptions.Controls.Add(txtAffinity);
            ExternalOptions.Controls.Add(Label_Affinity);
            ExternalOptions.Controls.Add(ckbETVR);
            ExternalOptions.Controls.Add(btnBrowse);
            ExternalOptions.Controls.Add(txtETVRPath);
            ExternalOptions.ForeColor = Color.White;
            ExternalOptions.Location = new Point(270, 326);
            ExternalOptions.Name = "ExternalOptions";
            ExternalOptions.Size = new Size(479, 70);
            ExternalOptions.TabIndex = 2;
            ExternalOptions.TabStop = false;
            ExternalOptions.Text = "ExternalOptions";
            // 
            // Label_ETVR
            // 
            Label_ETVR.AutoSize = true;
            Label_ETVR.Location = new Point(8, 18);
            Label_ETVR.Margin = new Padding(5);
            Label_ETVR.Name = "Label_ETVR";
            Label_ETVR.Size = new Size(60, 15);
            Label_ETVR.TabIndex = 20;
            Label_ETVR.Text = "ETVR Path";
            // 
            // btnAffinityApply
            // 
            btnAffinityApply.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAffinityApply.BackColor = Color.FromArgb(64, 64, 64);
            btnAffinityApply.BackgroundImageLayout = ImageLayout.None;
            btnAffinityApply.FlatAppearance.BorderColor = Color.DimGray;
            btnAffinityApply.FlatAppearance.BorderSize = 0;
            btnAffinityApply.FlatStyle = FlatStyle.Flat;
            btnAffinityApply.Font = new Font("Yu Gothic UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAffinityApply.ForeColor = Color.White;
            btnAffinityApply.Location = new Point(398, 39);
            btnAffinityApply.Name = "btnAffinityApply";
            btnAffinityApply.Size = new Size(73, 21);
            btnAffinityApply.TabIndex = 19;
            btnAffinityApply.Text = "Apply";
            btnAffinityApply.TextAlign = ContentAlignment.TopCenter;
            btnAffinityApply.UseVisualStyleBackColor = true;
            btnAffinityApply.Click += btnAffinity_Click;
            // 
            // txtAffinity
            // 
            txtAffinity.BackColor = Color.FromArgb(64, 64, 64);
            txtAffinity.BorderStyle = BorderStyle.None;
            txtAffinity.ForeColor = Color.White;
            txtAffinity.Location = new Point(88, 42);
            txtAffinity.Margin = new Padding(5);
            txtAffinity.MaxLength = 64;
            txtAffinity.Name = "txtAffinity";
            txtAffinity.ShortcutsEnabled = false;
            txtAffinity.Size = new Size(304, 16);
            txtAffinity.TabIndex = 2;
            txtAffinity.TextChanged += txtAffinity_TextChanged;
            // 
            // Label_Affinity
            // 
            Label_Affinity.AutoSize = true;
            Label_Affinity.Location = new Point(8, 43);
            Label_Affinity.Margin = new Padding(5);
            Label_Affinity.Name = "Label_Affinity";
            Label_Affinity.Size = new Size(70, 15);
            Label_Affinity.TabIndex = 17;
            Label_Affinity.Text = "CPU Affinity";
            // 
            // ckbETVR
            // 
            ckbETVR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckbETVR.AutoSize = true;
            ckbETVR.FlatStyle = FlatStyle.Flat;
            ckbETVR.Location = new Point(398, 14);
            ckbETVR.Margin = new Padding(5);
            ckbETVR.Name = "ckbETVR";
            ckbETVR.Size = new Size(73, 19);
            ckbETVR.TabIndex = 13;
            ckbETVR.Text = "Auto Run";
            ckbETVR.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(64, 64, 64);
            btnBrowse.FlatAppearance.BorderColor = Color.DimGray;
            btnBrowse.FlatStyle = FlatStyle.Popup;
            btnBrowse.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(370, 14);
            btnBrowse.Margin = new Padding(0, 0, 0, 3);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(22, 18);
            btnBrowse.TabIndex = 19;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtETVRPath
            // 
            txtETVRPath.BackColor = Color.FromArgb(64, 64, 64);
            txtETVRPath.BorderStyle = BorderStyle.None;
            txtETVRPath.ForeColor = Color.White;
            txtETVRPath.Location = new Point(88, 16);
            txtETVRPath.Margin = new Padding(5);
            txtETVRPath.Name = "txtETVRPath";
            txtETVRPath.ReadOnly = true;
            txtETVRPath.Size = new Size(304, 16);
            txtETVRPath.TabIndex = 2;
            // 
            // EyeCameraStreamer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(764, 406);
            Controls.Add(ExternalOptions);
            Controls.Add(Address);
            Controls.Add(ProcessTime);
            Controls.Add(txtPreview);
            Controls.Add(pictureBoxPreview);
            Controls.Add(ckbAutoStart);
            Controls.Add(EffectSetting);
            Controls.Add(Label_CameraId);
            Controls.Add(btnToggle);
            Controls.Add(comboBoxCameras);
            Controls.Add(StaticSetting);
            MaximizeBox = false;
            MaximumSize = new Size(780, 445);
            MinimumSize = new Size(780, 445);
            Name = "EyeCameraStreamer";
            Text = "EyeCameraStreamer";
            FormClosing += OnClosing;
            Load += OnLoad;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            StaticSetting.ResumeLayout(false);
            StaticSetting.PerformLayout();
            EffectSetting.ResumeLayout(false);
            EffectSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sliderGamma).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderClahe).EndInit();
            Address.ResumeLayout(false);
            Address.PerformLayout();
            ExternalOptions.ResumeLayout(false);
            ExternalOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCameras;
        private Button btnToggle;
        private PictureBox pictureBoxPreview;
        private TextBox txtPortLeft;
        private TextBox txtPortRight;
        private Label Label_LeftPort;
        private Label Label_RightPort;
        private Label Label_TargetFps;
        private TextBox txtFps;
        private CheckBox ckbClahe;
        private TextBox txtPreview;
        private GroupBox EffectSetting;
        private GroupBox StaticSetting;
        private Label Label_CameraId;
        private Label Label_SizeX;
        private TextBox txtH;
        private TextBox txtW;
        private Label Label_Size;
        private CheckBox ckbAutoStart;
        private Label ProcessTime;
        private GroupBox Address;
        private TextBox RightAddress;
        private TextBox LeftAddress;
        private GroupBox ExternalOptions;
        private TextBox txtETVRPath;
        private Button btnBrowse;
        private CheckBox ckbETVR;
        private Label Label_Affinity;
        private TextBox txtAffinity;
        private Button btnAffinityApply;
        private Label Label_ETVR;
        private TrackBar sliderClahe;
        private TrackBar sliderGamma;
        private CheckBox ckbGamma;
    }
}
