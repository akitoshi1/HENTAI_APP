
namespace Civitai_Love
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblShowInfo = new System.Windows.Forms.Label();
            this.lblShowInfo2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbl_PleaseDropDownVideo2 = new System.Windows.Forms.Label();
            this.lbl_PleaseDropDownVideo = new System.Windows.Forms.Label();
            this.btnTEST_FFMPEG = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSystemSeting = new System.Windows.Forms.Panel();
            this.btnSystemSettingClose = new System.Windows.Forms.Button();
            this.btnSystemOutput = new System.Windows.Forms.Button();
            this.txtSystemOutput = new System.Windows.Forms.TextBox();
            this.lblSystemOutput = new System.Windows.Forms.Label();
            this.lblSystemSetting = new System.Windows.Forms.Label();
            this.pnlEditVideo = new System.Windows.Forms.Panel();
            this.pnlsplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxStart = new System.Windows.Forms.PictureBox();
            this.trackBar_TrimStart = new System.Windows.Forms.TrackBar();
            this.lblTrimStartTime = new System.Windows.Forms.Label();
            this.btnSp = new System.Windows.Forms.Button();
            this.lblCutStart1 = new System.Windows.Forms.Label();
            this.btnSm = new System.Windows.Forms.Button();
            this.lblCutStart2 = new System.Windows.Forms.Label();
            this.txtTrimStart = new System.Windows.Forms.TextBox();
            this.pictureBoxEnd = new System.Windows.Forms.PictureBox();
            this.btnEp = new System.Windows.Forms.Button();
            this.trackBar_TrimEnd = new System.Windows.Forms.TrackBar();
            this.btnEm = new System.Windows.Forms.Button();
            this.lblTrimEndTime = new System.Windows.Forms.Label();
            this.txtTrimEnd = new System.Windows.Forms.TextBox();
            this.lblCutEnd1 = new System.Windows.Forms.Label();
            this.lblCutEnd2 = new System.Windows.Forms.Label();
            this.groupBoxNext = new System.Windows.Forms.GroupBox();
            this.txtCutOutPath = new System.Windows.Forms.TextBox();
            this.chkCloseMe = new System.Windows.Forms.CheckBox();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.lblOutputFiles = new System.Windows.Forms.Label();
            this.btnSend_Packer = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlTranspose2 = new System.Windows.Forms.Panel();
            this.pnlTranspose1 = new System.Windows.Forms.Panel();
            this.rdoTranspose2 = new System.Windows.Forms.RadioButton();
            this.rdoTranspose1 = new System.Windows.Forms.RadioButton();
            this.chkIsTranspose = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalFrameImageCout = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.cmbFrameInterval = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoPng = new System.Windows.Forms.RadioButton();
            this.rdoJpg = new System.Windows.Forms.RadioButton();
            this.lblSystemInfo = new System.Windows.Forms.Label();
            this.txtFrameCount = new System.Windows.Forms.TextBox();
            this.lblFrameCount = new System.Windows.Forms.Label();
            this.lblShowInfo3 = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.pnlSystemSeting.SuspendLayout();
            this.pnlEditVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlsplitContainer1)).BeginInit();
            this.pnlsplitContainer1.Panel1.SuspendLayout();
            this.pnlsplitContainer1.Panel2.SuspendLayout();
            this.pnlsplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TrimStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TrimEnd)).BeginInit();
            this.groupBoxNext.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblShowInfo
            // 
            this.lblShowInfo.AutoSize = true;
            this.lblShowInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowInfo.Location = new System.Drawing.Point(9, 40);
            this.lblShowInfo.Name = "lblShowInfo";
            this.lblShowInfo.Size = new System.Drawing.Size(37, 15);
            this.lblShowInfo.TabIndex = 8;
            this.lblShowInfo.Text = "info1:";
            // 
            // lblShowInfo2
            // 
            this.lblShowInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowInfo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowInfo2.Location = new System.Drawing.Point(857, 43);
            this.lblShowInfo2.Name = "lblShowInfo2";
            this.lblShowInfo2.Size = new System.Drawing.Size(133, 12);
            this.lblShowInfo2.TabIndex = 10;
            this.lblShowInfo2.Text = "info2:";
            this.lblShowInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 7);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(978, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 11;
            this.progressBar.Visible = false;
            // 
            // lbl_PleaseDropDownVideo2
            // 
            this.lbl_PleaseDropDownVideo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PleaseDropDownVideo2.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PleaseDropDownVideo2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_PleaseDropDownVideo2.Location = new System.Drawing.Point(12, 103);
            this.lbl_PleaseDropDownVideo2.Name = "lbl_PleaseDropDownVideo2";
            this.lbl_PleaseDropDownVideo2.Size = new System.Drawing.Size(987, 104);
            this.lbl_PleaseDropDownVideo2.TabIndex = 8;
            this.lbl_PleaseDropDownVideo2.Text = "[📽️]";
            this.lbl_PleaseDropDownVideo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PleaseDropDownVideo
            // 
            this.lbl_PleaseDropDownVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PleaseDropDownVideo.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PleaseDropDownVideo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_PleaseDropDownVideo.Location = new System.Drawing.Point(12, 83);
            this.lbl_PleaseDropDownVideo.Name = "lbl_PleaseDropDownVideo";
            this.lbl_PleaseDropDownVideo.Size = new System.Drawing.Size(990, 20);
            this.lbl_PleaseDropDownVideo.TabIndex = 7;
            this.lbl_PleaseDropDownVideo.Text = "Please Drop & Down Video File";
            this.lbl_PleaseDropDownVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTEST_FFMPEG
            // 
            this.btnTEST_FFMPEG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTEST_FFMPEG.Font = new System.Drawing.Font("Segoe UI Emoji", 30F);
            this.btnTEST_FFMPEG.Location = new System.Drawing.Point(255, 476);
            this.btnTEST_FFMPEG.Name = "btnTEST_FFMPEG";
            this.btnTEST_FFMPEG.Size = new System.Drawing.Size(204, 67);
            this.btnTEST_FFMPEG.TabIndex = 11;
            this.btnTEST_FFMPEG.Text = "📽️➡️🖼️";
            this.btnTEST_FFMPEG.UseVisualStyleBackColor = true;
            this.btnTEST_FFMPEG.Click += new System.EventHandler(this.btnTEST_FFMPEG_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // pnlSystemSeting
            // 
            this.pnlSystemSeting.Controls.Add(this.btnSystemSettingClose);
            this.pnlSystemSeting.Controls.Add(this.btnSystemOutput);
            this.pnlSystemSeting.Controls.Add(this.txtSystemOutput);
            this.pnlSystemSeting.Controls.Add(this.lblSystemOutput);
            this.pnlSystemSeting.Controls.Add(this.lblSystemSetting);
            this.pnlSystemSeting.Location = new System.Drawing.Point(12, 625);
            this.pnlSystemSeting.Name = "pnlSystemSeting";
            this.pnlSystemSeting.Size = new System.Drawing.Size(986, 191);
            this.pnlSystemSeting.TabIndex = 0;
            this.pnlSystemSeting.Visible = false;
            // 
            // btnSystemSettingClose
            // 
            this.btnSystemSettingClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemSettingClose.Font = new System.Drawing.Font("Segoe UI Emoji", 45F);
            this.btnSystemSettingClose.Location = new System.Drawing.Point(856, 88);
            this.btnSystemSettingClose.Name = "btnSystemSettingClose";
            this.btnSystemSettingClose.Size = new System.Drawing.Size(124, 100);
            this.btnSystemSettingClose.TabIndex = 2;
            this.btnSystemSettingClose.Text = "👍";
            this.btnSystemSettingClose.UseVisualStyleBackColor = true;
            this.btnSystemSettingClose.Click += new System.EventHandler(this.btnSystemSettingClose_Click);
            // 
            // btnSystemOutput
            // 
            this.btnSystemOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemOutput.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystemOutput.Location = new System.Drawing.Point(926, 40);
            this.btnSystemOutput.Name = "btnSystemOutput";
            this.btnSystemOutput.Size = new System.Drawing.Size(53, 23);
            this.btnSystemOutput.TabIndex = 1;
            this.btnSystemOutput.Text = "📁";
            this.btnSystemOutput.UseVisualStyleBackColor = true;
            this.btnSystemOutput.Click += new System.EventHandler(this.btnSystemOutput_Click);
            // 
            // txtSystemOutput
            // 
            this.txtSystemOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSystemOutput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSystemOutput.Location = new System.Drawing.Point(123, 40);
            this.txtSystemOutput.Name = "txtSystemOutput";
            this.txtSystemOutput.ReadOnly = true;
            this.txtSystemOutput.Size = new System.Drawing.Size(797, 23);
            this.txtSystemOutput.TabIndex = 0;
            // 
            // lblSystemOutput
            // 
            this.lblSystemOutput.AutoSize = true;
            this.lblSystemOutput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemOutput.Location = new System.Drawing.Point(18, 40);
            this.lblSystemOutput.Name = "lblSystemOutput";
            this.lblSystemOutput.Size = new System.Drawing.Size(99, 15);
            this.lblSystemOutput.TabIndex = 10;
            this.lblSystemOutput.Text = "Output Directory:";
            // 
            // lblSystemSetting
            // 
            this.lblSystemSetting.AutoSize = true;
            this.lblSystemSetting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemSetting.Location = new System.Drawing.Point(3, 10);
            this.lblSystemSetting.Name = "lblSystemSetting";
            this.lblSystemSetting.Size = new System.Drawing.Size(114, 21);
            this.lblSystemSetting.TabIndex = 9;
            this.lblSystemSetting.Text = "System Setting";
            // 
            // pnlEditVideo
            // 
            this.pnlEditVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEditVideo.Controls.Add(this.pnlsplitContainer1);
            this.pnlEditVideo.Controls.Add(this.groupBoxNext);
            this.pnlEditVideo.Controls.Add(this.groupBox3);
            this.pnlEditVideo.Controls.Add(this.groupBox1);
            this.pnlEditVideo.Controls.Add(this.groupBox2);
            this.pnlEditVideo.Controls.Add(this.btnTEST_FFMPEG);
            this.pnlEditVideo.Controls.Add(this.lblSystemInfo);
            this.pnlEditVideo.Location = new System.Drawing.Point(12, 62);
            this.pnlEditVideo.Name = "pnlEditVideo";
            this.pnlEditVideo.Size = new System.Drawing.Size(987, 557);
            this.pnlEditVideo.TabIndex = 1;
            this.pnlEditVideo.Visible = false;
            // 
            // pnlsplitContainer1
            // 
            this.pnlsplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlsplitContainer1.Location = new System.Drawing.Point(4, 3);
            this.pnlsplitContainer1.Name = "pnlsplitContainer1";
            // 
            // pnlsplitContainer1.Panel1
            // 
            this.pnlsplitContainer1.Panel1.Controls.Add(this.pictureBoxStart);
            this.pnlsplitContainer1.Panel1.Controls.Add(this.trackBar_TrimStart);
            this.pnlsplitContainer1.Panel1.Controls.Add(this.lblTrimStartTime);
            this.pnlsplitContainer1.Panel1.Controls.Add(this.btnSp);
            this.pnlsplitContainer1.Panel1.Controls.Add(this.lblCutStart1);
            this.pnlsplitContainer1.Panel1.Controls.Add(this.btnSm);
            this.pnlsplitContainer1.Panel1.Controls.Add(this.lblCutStart2);
            this.pnlsplitContainer1.Panel1.Controls.Add(this.txtTrimStart);
            // 
            // pnlsplitContainer1.Panel2
            // 
            this.pnlsplitContainer1.Panel2.Controls.Add(this.pictureBoxEnd);
            this.pnlsplitContainer1.Panel2.Controls.Add(this.btnEp);
            this.pnlsplitContainer1.Panel2.Controls.Add(this.trackBar_TrimEnd);
            this.pnlsplitContainer1.Panel2.Controls.Add(this.btnEm);
            this.pnlsplitContainer1.Panel2.Controls.Add(this.lblTrimEndTime);
            this.pnlsplitContainer1.Panel2.Controls.Add(this.txtTrimEnd);
            this.pnlsplitContainer1.Panel2.Controls.Add(this.lblCutEnd1);
            this.pnlsplitContainer1.Panel2.Controls.Add(this.lblCutEnd2);
            this.pnlsplitContainer1.Size = new System.Drawing.Size(974, 272);
            this.pnlsplitContainer1.SplitterDistance = 490;
            this.pnlsplitContainer1.TabIndex = 20;
            this.pnlsplitContainer1.Visible = false;
            // 
            // pictureBoxStart
            // 
            this.pictureBoxStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxStart.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxStart.Name = "pictureBoxStart";
            this.pictureBoxStart.Size = new System.Drawing.Size(484, 156);
            this.pictureBoxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStart.TabIndex = 7;
            this.pictureBoxStart.TabStop = false;
            this.pictureBoxStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxStart_MouseDown);
            // 
            // trackBar_TrimStart
            // 
            this.trackBar_TrimStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_TrimStart.Location = new System.Drawing.Point(3, 165);
            this.trackBar_TrimStart.Minimum = 1;
            this.trackBar_TrimStart.Name = "trackBar_TrimStart";
            this.trackBar_TrimStart.Size = new System.Drawing.Size(498, 45);
            this.trackBar_TrimStart.TabIndex = 0;
            this.trackBar_TrimStart.Value = 1;
            this.trackBar_TrimStart.ValueChanged += new System.EventHandler(this.trackBar_TrimStart_ValueChanged);
            this.trackBar_TrimStart.Leave += new System.EventHandler(this.trackBar_TrimStart_Leave);
            // 
            // lblTrimStartTime
            // 
            this.lblTrimStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrimStartTime.AutoSize = true;
            this.lblTrimStartTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTrimStartTime.Location = new System.Drawing.Point(387, 211);
            this.lblTrimStartTime.Name = "lblTrimStartTime";
            this.lblTrimStartTime.Size = new System.Drawing.Size(100, 21);
            this.lblTrimStartTime.TabIndex = 15;
            this.lblTrimStartTime.Text = "00:00:00.000";
            // 
            // btnSp
            // 
            this.btnSp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSp.Location = new System.Drawing.Point(168, 240);
            this.btnSp.Name = "btnSp";
            this.btnSp.Size = new System.Drawing.Size(64, 32);
            this.btnSp.TabIndex = 3;
            this.btnSp.Text = "+30";
            this.btnSp.UseVisualStyleBackColor = true;
            this.btnSp.Click += new System.EventHandler(this.btnSp30_Click);
            // 
            // lblCutStart1
            // 
            this.lblCutStart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCutStart1.AutoSize = true;
            this.lblCutStart1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCutStart1.Location = new System.Drawing.Point(10, 212);
            this.lblCutStart1.Name = "lblCutStart1";
            this.lblCutStart1.Size = new System.Drawing.Size(93, 21);
            this.lblCutStart1.TabIndex = 11;
            this.lblCutStart1.Text = "Start Frame:";
            // 
            // btnSm
            // 
            this.btnSm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSm.Location = new System.Drawing.Point(102, 240);
            this.btnSm.Name = "btnSm";
            this.btnSm.Size = new System.Drawing.Size(64, 32);
            this.btnSm.TabIndex = 2;
            this.btnSm.Text = "-30";
            this.btnSm.UseVisualStyleBackColor = true;
            this.btnSm.Click += new System.EventHandler(this.btnSm30_Click);
            // 
            // lblCutStart2
            // 
            this.lblCutStart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCutStart2.AutoSize = true;
            this.lblCutStart2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCutStart2.Location = new System.Drawing.Point(299, 211);
            this.lblCutStart2.Name = "lblCutStart2";
            this.lblCutStart2.Size = new System.Drawing.Size(83, 21);
            this.lblCutStart2.TabIndex = 12;
            this.lblCutStart2.Text = "Start Time:";
            // 
            // txtTrimStart
            // 
            this.txtTrimStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTrimStart.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTrimStart.Location = new System.Drawing.Point(102, 208);
            this.txtTrimStart.Name = "txtTrimStart";
            this.txtTrimStart.ReadOnly = true;
            this.txtTrimStart.Size = new System.Drawing.Size(130, 29);
            this.txtTrimStart.TabIndex = 1;
            this.txtTrimStart.TabStop = false;
            this.txtTrimStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxEnd
            // 
            this.pictureBoxEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEnd.Location = new System.Drawing.Point(5, 3);
            this.pictureBoxEnd.Name = "pictureBoxEnd";
            this.pictureBoxEnd.Size = new System.Drawing.Size(485, 156);
            this.pictureBoxEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEnd.TabIndex = 8;
            this.pictureBoxEnd.TabStop = false;
            this.pictureBoxEnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEnd_MouseDown);
            // 
            // btnEp
            // 
            this.btnEp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEp.Location = new System.Drawing.Point(165, 237);
            this.btnEp.Name = "btnEp";
            this.btnEp.Size = new System.Drawing.Size(64, 32);
            this.btnEp.TabIndex = 7;
            this.btnEp.Text = "+30";
            this.btnEp.UseVisualStyleBackColor = true;
            this.btnEp.Click += new System.EventHandler(this.btnEp30_Click);
            // 
            // trackBar_TrimEnd
            // 
            this.trackBar_TrimEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_TrimEnd.Location = new System.Drawing.Point(3, 165);
            this.trackBar_TrimEnd.Minimum = 2;
            this.trackBar_TrimEnd.Name = "trackBar_TrimEnd";
            this.trackBar_TrimEnd.Size = new System.Drawing.Size(457, 45);
            this.trackBar_TrimEnd.TabIndex = 4;
            this.trackBar_TrimEnd.Value = 2;
            this.trackBar_TrimEnd.ValueChanged += new System.EventHandler(this.trackBar_TrimEnd_ValueChanged);
            this.trackBar_TrimEnd.Leave += new System.EventHandler(this.trackBar_TrimEnd_Leave);
            // 
            // btnEm
            // 
            this.btnEm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEm.Location = new System.Drawing.Point(99, 237);
            this.btnEm.Name = "btnEm";
            this.btnEm.Size = new System.Drawing.Size(64, 32);
            this.btnEm.TabIndex = 6;
            this.btnEm.Text = "-30";
            this.btnEm.UseVisualStyleBackColor = true;
            this.btnEm.Click += new System.EventHandler(this.btnEm30_Click);
            // 
            // lblTrimEndTime
            // 
            this.lblTrimEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrimEndTime.AutoSize = true;
            this.lblTrimEndTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTrimEndTime.Location = new System.Drawing.Point(374, 208);
            this.lblTrimEndTime.Name = "lblTrimEndTime";
            this.lblTrimEndTime.Size = new System.Drawing.Size(100, 21);
            this.lblTrimEndTime.TabIndex = 16;
            this.lblTrimEndTime.Text = "00:00:00.000";
            // 
            // txtTrimEnd
            // 
            this.txtTrimEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTrimEnd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTrimEnd.Location = new System.Drawing.Point(99, 205);
            this.txtTrimEnd.Name = "txtTrimEnd";
            this.txtTrimEnd.ReadOnly = true;
            this.txtTrimEnd.Size = new System.Drawing.Size(130, 29);
            this.txtTrimEnd.TabIndex = 5;
            this.txtTrimEnd.TabStop = false;
            this.txtTrimEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCutEnd1
            // 
            this.lblCutEnd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCutEnd1.AutoSize = true;
            this.lblCutEnd1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCutEnd1.Location = new System.Drawing.Point(6, 209);
            this.lblCutEnd1.Name = "lblCutEnd1";
            this.lblCutEnd1.Size = new System.Drawing.Size(87, 21);
            this.lblCutEnd1.TabIndex = 21;
            this.lblCutEnd1.Text = "End Frame:";
            // 
            // lblCutEnd2
            // 
            this.lblCutEnd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCutEnd2.AutoSize = true;
            this.lblCutEnd2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCutEnd2.Location = new System.Drawing.Point(285, 208);
            this.lblCutEnd2.Name = "lblCutEnd2";
            this.lblCutEnd2.Size = new System.Drawing.Size(77, 21);
            this.lblCutEnd2.TabIndex = 22;
            this.lblCutEnd2.Text = "End Time:";
            // 
            // groupBoxNext
            // 
            this.groupBoxNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxNext.Controls.Add(this.txtCutOutPath);
            this.groupBoxNext.Controls.Add(this.chkCloseMe);
            this.groupBoxNext.Controls.Add(this.lblOutputPath);
            this.groupBoxNext.Controls.Add(this.lblOutputFiles);
            this.groupBoxNext.Controls.Add(this.btnSend_Packer);
            this.groupBoxNext.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBoxNext.Location = new System.Drawing.Point(499, 281);
            this.groupBoxNext.Name = "groupBoxNext";
            this.groupBoxNext.Size = new System.Drawing.Size(478, 263);
            this.groupBoxNext.TabIndex = 12;
            this.groupBoxNext.TabStop = false;
            this.groupBoxNext.Text = "CutOut Frame Image Files";
            this.groupBoxNext.Visible = false;
            // 
            // txtCutOutPath
            // 
            this.txtCutOutPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCutOutPath.Location = new System.Drawing.Point(14, 101);
            this.txtCutOutPath.Multiline = true;
            this.txtCutOutPath.Name = "txtCutOutPath";
            this.txtCutOutPath.ReadOnly = true;
            this.txtCutOutPath.Size = new System.Drawing.Size(450, 76);
            this.txtCutOutPath.TabIndex = 0;
            // 
            // chkCloseMe
            // 
            this.chkCloseMe.AutoSize = true;
            this.chkCloseMe.Checked = true;
            this.chkCloseMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCloseMe.Location = new System.Drawing.Point(21, 234);
            this.chkCloseMe.Name = "chkCloseMe";
            this.chkCloseMe.Size = new System.Drawing.Size(176, 25);
            this.chkCloseMe.TabIndex = 2;
            this.chkCloseMe.Text = "Close this application";
            this.chkCloseMe.UseVisualStyleBackColor = true;
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputPath.Location = new System.Drawing.Point(21, 83);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(76, 15);
            this.lblOutputPath.TabIndex = 27;
            this.lblOutputPath.Text = "CutOut Path:";
            // 
            // lblOutputFiles
            // 
            this.lblOutputFiles.AutoSize = true;
            this.lblOutputFiles.Location = new System.Drawing.Point(17, 194);
            this.lblOutputFiles.Name = "lblOutputFiles";
            this.lblOutputFiles.Size = new System.Drawing.Size(211, 21);
            this.lblOutputFiles.TabIndex = 1;
            this.lblOutputFiles.Text = "Tortal CutOut Image Count: 0";
            // 
            // btnSend_Packer
            // 
            this.btnSend_Packer.Font = new System.Drawing.Font("Segoe UI Emoji", 30F);
            this.btnSend_Packer.Location = new System.Drawing.Point(260, 192);
            this.btnSend_Packer.Name = "btnSend_Packer";
            this.btnSend_Packer.Size = new System.Drawing.Size(204, 67);
            this.btnSend_Packer.TabIndex = 3;
            this.btnSend_Packer.Text = "🖼️➡️📦";
            this.btnSend_Packer.UseVisualStyleBackColor = true;
            this.btnSend_Packer.Click += new System.EventHandler(this.btnSend_Packer_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.pnlTranspose2);
            this.groupBox3.Controls.Add(this.pnlTranspose1);
            this.groupBox3.Controls.Add(this.rdoTranspose2);
            this.groupBox3.Controls.Add(this.rdoTranspose1);
            this.groupBox3.Controls.Add(this.chkIsTranspose);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox3.Location = new System.Drawing.Point(11, 370);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(467, 88);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transpose";
            // 
            // pnlTranspose2
            // 
            this.pnlTranspose2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTranspose2.BackgroundImage")));
            this.pnlTranspose2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTranspose2.Location = new System.Drawing.Point(311, 26);
            this.pnlTranspose2.Name = "pnlTranspose2";
            this.pnlTranspose2.Size = new System.Drawing.Size(125, 48);
            this.pnlTranspose2.TabIndex = 2;
            this.pnlTranspose2.Visible = false;
            // 
            // pnlTranspose1
            // 
            this.pnlTranspose1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTranspose1.BackgroundImage")));
            this.pnlTranspose1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTranspose1.Location = new System.Drawing.Point(136, 26);
            this.pnlTranspose1.Name = "pnlTranspose1";
            this.pnlTranspose1.Size = new System.Drawing.Size(125, 48);
            this.pnlTranspose1.TabIndex = 1;
            this.pnlTranspose1.Visible = false;
            // 
            // rdoTranspose2
            // 
            this.rdoTranspose2.AutoSize = true;
            this.rdoTranspose2.Location = new System.Drawing.Point(291, 44);
            this.rdoTranspose2.Name = "rdoTranspose2";
            this.rdoTranspose2.Size = new System.Drawing.Size(14, 13);
            this.rdoTranspose2.TabIndex = 2;
            this.rdoTranspose2.TabStop = true;
            this.rdoTranspose2.UseVisualStyleBackColor = true;
            this.rdoTranspose2.Visible = false;
            this.rdoTranspose2.CheckedChanged += new System.EventHandler(this.rdoTranspose2_CheckedChanged);
            // 
            // rdoTranspose1
            // 
            this.rdoTranspose1.AutoSize = true;
            this.rdoTranspose1.Location = new System.Drawing.Point(116, 44);
            this.rdoTranspose1.Name = "rdoTranspose1";
            this.rdoTranspose1.Size = new System.Drawing.Size(14, 13);
            this.rdoTranspose1.TabIndex = 1;
            this.rdoTranspose1.TabStop = true;
            this.rdoTranspose1.UseVisualStyleBackColor = true;
            this.rdoTranspose1.Visible = false;
            this.rdoTranspose1.CheckedChanged += new System.EventHandler(this.rdoTranspose1_CheckedChanged);
            // 
            // chkIsTranspose
            // 
            this.chkIsTranspose.AutoSize = true;
            this.chkIsTranspose.Location = new System.Drawing.Point(15, 38);
            this.chkIsTranspose.Name = "chkIsTranspose";
            this.chkIsTranspose.Size = new System.Drawing.Size(53, 25);
            this.chkIsTranspose.TabIndex = 0;
            this.chkIsTranspose.Text = "ON";
            this.chkIsTranspose.UseVisualStyleBackColor = true;
            this.chkIsTranspose.CheckedChanged += new System.EventHandler(this.chkIsTranspose_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblTotalFrameImageCout);
            this.groupBox1.Controls.Add(this.lblSelect);
            this.groupBox1.Controls.Add(this.cmbFrameInterval);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(11, 281);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frame interval";
            // 
            // lblTotalFrameImageCout
            // 
            this.lblTotalFrameImageCout.AutoSize = true;
            this.lblTotalFrameImageCout.Location = new System.Drawing.Point(259, 34);
            this.lblTotalFrameImageCout.Name = "lblTotalFrameImageCout";
            this.lblTotalFrameImageCout.Size = new System.Drawing.Size(159, 21);
            this.lblTotalFrameImageCout.TabIndex = 2;
            this.lblTotalFrameImageCout.Text = "Tortal Frame Image: 0";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(11, 34);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(122, 21);
            this.lblSelect.TabIndex = 1;
            this.lblSelect.Text = "Set Frame Point:";
            // 
            // cmbFrameInterval
            // 
            this.cmbFrameInterval.AutoCompleteCustomSource.AddRange(new string[] {
            "10",
            "30",
            "60",
            "90",
            "120",
            "180",
            "210",
            "300",
            "600",
            "900"});
            this.cmbFrameInterval.FormattingEnabled = true;
            this.cmbFrameInterval.Items.AddRange(new object[] {
            "30",
            "60",
            "90",
            "120",
            "150",
            "180",
            "210",
            "300",
            "600",
            "900",
            "1200"});
            this.cmbFrameInterval.Location = new System.Drawing.Point(136, 31);
            this.cmbFrameInterval.Name = "cmbFrameInterval";
            this.cmbFrameInterval.Size = new System.Drawing.Size(83, 29);
            this.cmbFrameInterval.TabIndex = 0;
            this.cmbFrameInterval.Text = "30";
            this.cmbFrameInterval.TextChanged += new System.EventHandler(this.cmbFrameInterval_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.rdoPng);
            this.groupBox2.Controls.Add(this.rdoJpg);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox2.Location = new System.Drawing.Point(11, 468);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 76);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Image Format";
            // 
            // rdoPng
            // 
            this.rdoPng.AutoSize = true;
            this.rdoPng.Location = new System.Drawing.Point(116, 40);
            this.rdoPng.Name = "rdoPng";
            this.rdoPng.Size = new System.Drawing.Size(60, 25);
            this.rdoPng.TabIndex = 1;
            this.rdoPng.Text = "PNG";
            this.rdoPng.UseVisualStyleBackColor = true;
            // 
            // rdoJpg
            // 
            this.rdoJpg.AutoSize = true;
            this.rdoJpg.Checked = true;
            this.rdoJpg.Location = new System.Drawing.Point(15, 40);
            this.rdoJpg.Name = "rdoJpg";
            this.rdoJpg.Size = new System.Drawing.Size(54, 25);
            this.rdoJpg.TabIndex = 0;
            this.rdoJpg.TabStop = true;
            this.rdoJpg.Text = "JPG";
            this.rdoJpg.UseVisualStyleBackColor = true;
            // 
            // lblSystemInfo
            // 
            this.lblSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemInfo.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSystemInfo.Location = new System.Drawing.Point(617, 539);
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Size = new System.Drawing.Size(352, 15);
            this.lblSystemInfo.TabIndex = 34;
            this.lblSystemInfo.Text = "SystemInfo";
            this.lblSystemInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFrameCount
            // 
            this.txtFrameCount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFrameCount.Location = new System.Drawing.Point(509, 30);
            this.txtFrameCount.Name = "txtFrameCount";
            this.txtFrameCount.ReadOnly = true;
            this.txtFrameCount.Size = new System.Drawing.Size(94, 29);
            this.txtFrameCount.TabIndex = 18;
            this.txtFrameCount.TabStop = false;
            this.txtFrameCount.Visible = false;
            // 
            // lblFrameCount
            // 
            this.lblFrameCount.AutoSize = true;
            this.lblFrameCount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFrameCount.Location = new System.Drawing.Point(346, 37);
            this.lblFrameCount.Name = "lblFrameCount";
            this.lblFrameCount.Size = new System.Drawing.Size(157, 21);
            this.lblFrameCount.TabIndex = 17;
            this.lblFrameCount.Text = "Between Frame Cout:";
            this.lblFrameCount.Visible = false;
            // 
            // lblShowInfo3
            // 
            this.lblShowInfo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowInfo3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowInfo3.Location = new System.Drawing.Point(857, 31);
            this.lblShowInfo3.Name = "lblShowInfo3";
            this.lblShowInfo3.Size = new System.Drawing.Size(133, 12);
            this.lblShowInfo3.TabIndex = 15;
            this.lblShowInfo3.Text = "info3:";
            this.lblShowInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlLogo.Location = new System.Drawing.Point(12, 246);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(987, 116);
            this.pnlLogo.TabIndex = 19;
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 627);
            this.Controls.Add(this.lblShowInfo3);
            this.Controls.Add(this.pnlEditVideo);
            this.Controls.Add(this.pnlSystemSeting);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbl_PleaseDropDownVideo2);
            this.Controls.Add(this.lbl_PleaseDropDownVideo);
            this.Controls.Add(this.lblShowInfo2);
            this.Controls.Add(this.lblShowInfo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtFrameCount);
            this.Controls.Add(this.lblFrameCount);
            this.Controls.Add(this.pnlLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Please Drop the Video File.";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSystemSeting.ResumeLayout(false);
            this.pnlSystemSeting.PerformLayout();
            this.pnlEditVideo.ResumeLayout(false);
            this.pnlsplitContainer1.Panel1.ResumeLayout(false);
            this.pnlsplitContainer1.Panel1.PerformLayout();
            this.pnlsplitContainer1.Panel2.ResumeLayout(false);
            this.pnlsplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlsplitContainer1)).EndInit();
            this.pnlsplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TrimStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TrimEnd)).EndInit();
            this.groupBoxNext.ResumeLayout(false);
            this.groupBoxNext.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblShowInfo;
        private System.Windows.Forms.Label lblShowInfo2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnTEST_FFMPEG;
        private System.Windows.Forms.Label lbl_PleaseDropDownVideo;
        private System.Windows.Forms.Label lbl_PleaseDropDownVideo2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSystemSeting;
        private System.Windows.Forms.Label lblSystemOutput;
        private System.Windows.Forms.Label lblSystemSetting;
        private System.Windows.Forms.Button btnSystemSettingClose;
        private System.Windows.Forms.Button btnSystemOutput;
        private System.Windows.Forms.TextBox txtSystemOutput;
        private System.Windows.Forms.Panel pnlEditVideo;
        private System.Windows.Forms.PictureBox pictureBoxEnd;
        private System.Windows.Forms.PictureBox pictureBoxStart;
        private System.Windows.Forms.TextBox txtTrimEnd;
        private System.Windows.Forms.TextBox txtTrimStart;
        private System.Windows.Forms.Label lblCutStart2;
        private System.Windows.Forms.Label lblCutStart1;
        private System.Windows.Forms.TrackBar trackBar_TrimEnd;
        private System.Windows.Forms.TrackBar trackBar_TrimStart;
        private System.Windows.Forms.Label lblTrimEndTime;
        private System.Windows.Forms.Label lblTrimStartTime;
        private System.Windows.Forms.Label lblFrameCount;
        private System.Windows.Forms.TextBox txtFrameCount;
        private System.Windows.Forms.Label lblCutEnd2;
        private System.Windows.Forms.Label lblCutEnd1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoPng;
        private System.Windows.Forms.RadioButton rdoJpg;
        private System.Windows.Forms.Label lblTotalFrameImageCout;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.ComboBox cmbFrameInterval;
        private System.Windows.Forms.GroupBox groupBoxNext;
        private System.Windows.Forms.Button btnSend_Packer;
        private System.Windows.Forms.Label lblOutputFiles;
        private System.Windows.Forms.CheckBox chkCloseMe;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.TextBox txtCutOutPath;
        private System.Windows.Forms.Label lblShowInfo3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkIsTranspose;
        private System.Windows.Forms.RadioButton rdoTranspose2;
        private System.Windows.Forms.RadioButton rdoTranspose1;
        private System.Windows.Forms.Panel pnlTranspose2;
        private System.Windows.Forms.Panel pnlTranspose1;
        private System.Windows.Forms.Button btnSp;
        private System.Windows.Forms.Button btnSm;
        private System.Windows.Forms.Button btnEp;
        private System.Windows.Forms.Button btnEm;
        private System.Windows.Forms.Label lblSystemInfo;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.SplitContainer pnlsplitContainer1;
    }
}

