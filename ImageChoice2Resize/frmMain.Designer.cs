
namespace ImageChoiceAndResize
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblImageWidth = new System.Windows.Forms.Label();
            this.lblImageHeight = new System.Windows.Forms.Label();
            this.lblFileIndex = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblShowInfo = new System.Windows.Forms.Label();
            this.btnResize = new System.Windows.Forms.Button();
            this.lblShowInfo2 = new System.Windows.Forms.Label();
            this.btnRelord = new System.Windows.Forms.Button();
            this.pnlResize = new System.Windows.Forms.Panel();
            this.lblSystemInfo = new System.Windows.Forms.Label();
            this.chkAutoRelord = new System.Windows.Forms.CheckBox();
            this.chkRenameFile = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoWEBP = new System.Windows.Forms.RadioButton();
            this.rdoPng = new System.Windows.Forms.RadioButton();
            this.rdoJpg90 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPacageFolderName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPackageName_Version = new System.Windows.Forms.TextBox();
            this.txtPackageName_model = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPackageName_type = new System.Windows.Forms.TextBox();
            this.txtPackageName_Name = new System.Windows.Forms.TextBox();
            this.txtPackageName_Head = new System.Windows.Forms.TextBox();
            this.grpSetSize = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkPortrait = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLandscapeCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSquare = new System.Windows.Forms.CheckBox();
            this.txtSquareCount = new System.Windows.Forms.TextBox();
            this.chkLandscape = new System.Windows.Forms.CheckBox();
            this.txtPortraitCount = new System.Windows.Forms.TextBox();
            this.txtPortraitWidth = new System.Windows.Forms.TextBox();
            this.txtSquareWidth = new System.Windows.Forms.TextBox();
            this.txtLandscapeWidth = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnResizePack = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblpleaseDorpDown = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblShowInfo3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.pnlResize.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpSetSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Location = new System.Drawing.Point(11, 83);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(675, 558);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(9, 33);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(36, 12);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "Name:";
            this.lblFileName.Visible = false;
            // 
            // lblImageWidth
            // 
            this.lblImageWidth.AutoSize = true;
            this.lblImageWidth.Location = new System.Drawing.Point(9, 45);
            this.lblImageWidth.Name = "lblImageWidth";
            this.lblImageWidth.Size = new System.Drawing.Size(35, 12);
            this.lblImageWidth.TabIndex = 2;
            this.lblImageWidth.Text = "Width:";
            this.lblImageWidth.Visible = false;
            // 
            // lblImageHeight
            // 
            this.lblImageHeight.AutoSize = true;
            this.lblImageHeight.Location = new System.Drawing.Point(9, 57);
            this.lblImageHeight.Name = "lblImageHeight";
            this.lblImageHeight.Size = new System.Drawing.Size(40, 12);
            this.lblImageHeight.TabIndex = 3;
            this.lblImageHeight.Text = "Height:";
            this.lblImageHeight.Visible = false;
            // 
            // lblFileIndex
            // 
            this.lblFileIndex.AutoSize = true;
            this.lblFileIndex.Location = new System.Drawing.Point(9, 21);
            this.lblFileIndex.Name = "lblFileIndex";
            this.lblFileIndex.Size = new System.Drawing.Size(34, 12);
            this.lblFileIndex.TabIndex = 4;
            this.lblFileIndex.Text = "Index:";
            this.lblFileIndex.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.Enabled = false;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Emoji", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(82, 21);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(64, 56);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "⬅️";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Emoji", 27.75F);
            this.btnNext.Location = new System.Drawing.Point(553, 21);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 56);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "➡️";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI Emoji", 27.75F);
            this.btnRemove.Location = new System.Drawing.Point(152, 21);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(395, 56);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "🗑️";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblShowInfo
            // 
            this.lblShowInfo.AutoSize = true;
            this.lblShowInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowInfo.Location = new System.Drawing.Point(9, 6);
            this.lblShowInfo.Name = "lblShowInfo";
            this.lblShowInfo.Size = new System.Drawing.Size(31, 15);
            this.lblShowInfo.TabIndex = 8;
            this.lblShowInfo.Text = "info:";
            // 
            // btnResize
            // 
            this.btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResize.Enabled = false;
            this.btnResize.Font = new System.Drawing.Font("Segoe UI Emoji", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResize.Location = new System.Drawing.Point(622, 21);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(64, 56);
            this.btnResize.TabIndex = 5;
            this.btnResize.Text = "📦";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // lblShowInfo2
            // 
            this.lblShowInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowInfo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowInfo2.Location = new System.Drawing.Point(553, 6);
            this.lblShowInfo2.Name = "lblShowInfo2";
            this.lblShowInfo2.Size = new System.Drawing.Size(133, 12);
            this.lblShowInfo2.TabIndex = 10;
            this.lblShowInfo2.Text = "info:";
            this.lblShowInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRelord
            // 
            this.btnRelord.Enabled = false;
            this.btnRelord.Font = new System.Drawing.Font("Segoe UI Emoji", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelord.Location = new System.Drawing.Point(12, 21);
            this.btnRelord.Name = "btnRelord";
            this.btnRelord.Size = new System.Drawing.Size(64, 56);
            this.btnRelord.TabIndex = 1;
            this.btnRelord.Text = "🔃";
            this.btnRelord.UseVisualStyleBackColor = true;
            this.btnRelord.Click += new System.EventHandler(this.btnRelord_Click);
            // 
            // pnlResize
            // 
            this.pnlResize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResize.Controls.Add(this.lblSystemInfo);
            this.pnlResize.Controls.Add(this.chkAutoRelord);
            this.pnlResize.Controls.Add(this.chkRenameFile);
            this.pnlResize.Controls.Add(this.groupBox2);
            this.pnlResize.Controls.Add(this.groupBox1);
            this.pnlResize.Controls.Add(this.grpSetSize);
            this.pnlResize.Controls.Add(this.btnCancel);
            this.pnlResize.Controls.Add(this.btnResizePack);
            this.pnlResize.Location = new System.Drawing.Point(11, 83);
            this.pnlResize.Name = "pnlResize";
            this.pnlResize.Size = new System.Drawing.Size(674, 531);
            this.pnlResize.TabIndex = 5;
            this.pnlResize.Visible = false;
            // 
            // lblSystemInfo
            // 
            this.lblSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemInfo.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSystemInfo.Location = new System.Drawing.Point(315, 510);
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Size = new System.Drawing.Size(352, 15);
            this.lblSystemInfo.TabIndex = 33;
            this.lblSystemInfo.Text = "SystemInfo";
            this.lblSystemInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkAutoRelord
            // 
            this.chkAutoRelord.Checked = true;
            this.chkAutoRelord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRelord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoRelord.Location = new System.Drawing.Point(37, 475);
            this.chkAutoRelord.Name = "chkAutoRelord";
            this.chkAutoRelord.Size = new System.Drawing.Size(355, 32);
            this.chkAutoRelord.TabIndex = 4;
            this.chkAutoRelord.Text = "Auto ReLord Package (After Package Output)";
            this.chkAutoRelord.UseVisualStyleBackColor = true;
            // 
            // chkRenameFile
            // 
            this.chkRenameFile.Checked = true;
            this.chkRenameFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRenameFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRenameFile.Location = new System.Drawing.Point(37, 437);
            this.chkRenameFile.Name = "chkRenameFile";
            this.chkRenameFile.Size = new System.Drawing.Size(359, 32);
            this.chkRenameFile.TabIndex = 3;
            this.chkRenameFile.Text = "ReName File : 000001.jpg";
            this.chkRenameFile.UseVisualStyleBackColor = true;
            this.chkRenameFile.CheckedChanged += new System.EventHandler(this.chkRenameFile_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoWEBP);
            this.groupBox2.Controls.Add(this.rdoPng);
            this.groupBox2.Controls.Add(this.rdoJpg90);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox2.Location = new System.Drawing.Point(15, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 102);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Format";
            // 
            // rdoWEBP
            // 
            this.rdoWEBP.AutoSize = true;
            this.rdoWEBP.Enabled = false;
            this.rdoWEBP.Location = new System.Drawing.Point(22, 99);
            this.rdoWEBP.Name = "rdoWEBP";
            this.rdoWEBP.Size = new System.Drawing.Size(69, 25);
            this.rdoWEBP.TabIndex = 2;
            this.rdoWEBP.Text = "WEBP";
            this.rdoWEBP.UseVisualStyleBackColor = true;
            this.rdoWEBP.Visible = false;
            this.rdoWEBP.CheckedChanged += new System.EventHandler(this.rdoWEBP_CheckedChanged);
            // 
            // rdoPng
            // 
            this.rdoPng.AutoSize = true;
            this.rdoPng.Location = new System.Drawing.Point(22, 67);
            this.rdoPng.Name = "rdoPng";
            this.rdoPng.Size = new System.Drawing.Size(60, 25);
            this.rdoPng.TabIndex = 1;
            this.rdoPng.Text = "PNG";
            this.rdoPng.UseVisualStyleBackColor = true;
            this.rdoPng.CheckedChanged += new System.EventHandler(this.rdoPng_CheckedChanged);
            // 
            // rdoJpg90
            // 
            this.rdoJpg90.AutoSize = true;
            this.rdoJpg90.Checked = true;
            this.rdoJpg90.Location = new System.Drawing.Point(22, 35);
            this.rdoJpg90.Name = "rdoJpg90";
            this.rdoJpg90.Size = new System.Drawing.Size(148, 25);
            this.rdoJpg90.TabIndex = 0;
            this.rdoJpg90.TabStop = true;
            this.rdoJpg90.Text = "JPEG (Quality 90)";
            this.rdoJpg90.UseVisualStyleBackColor = true;
            this.rdoJpg90.CheckedChanged += new System.EventHandler(this.rdoJpg90_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPacageFolderName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPackageName_Version);
            this.groupBox1.Controls.Add(this.txtPackageName_model);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPackageName_type);
            this.groupBox1.Controls.Add(this.txtPackageName_Name);
            this.groupBox1.Controls.Add(this.txtPackageName_Head);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Package Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 21);
            this.label11.TabIndex = 36;
            this.label11.Text = "Package Folder Name";
            // 
            // txtPacageFolderName
            // 
            this.txtPacageFolderName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacageFolderName.Location = new System.Drawing.Point(9, 118);
            this.txtPacageFolderName.MaxLength = 10;
            this.txtPacageFolderName.Name = "txtPacageFolderName";
            this.txtPacageFolderName.ReadOnly = true;
            this.txtPacageFolderName.Size = new System.Drawing.Size(622, 29);
            this.txtPacageFolderName.TabIndex = 5;
            this.txtPacageFolderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(558, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "version";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(482, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 33;
            this.label6.Text = "model";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(406, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "type";
            // 
            // txtPackageName_Version
            // 
            this.txtPackageName_Version.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName_Version.Location = new System.Drawing.Point(561, 48);
            this.txtPackageName_Version.MaxLength = 10;
            this.txtPackageName_Version.Name = "txtPackageName_Version";
            this.txtPackageName_Version.Size = new System.Drawing.Size(70, 29);
            this.txtPackageName_Version.TabIndex = 4;
            this.txtPackageName_Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPackageName_Version.TextChanged += new System.EventHandler(this.txtPackageName_Version_TextChanged);
            // 
            // txtPackageName_model
            // 
            this.txtPackageName_model.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName_model.Location = new System.Drawing.Point(485, 48);
            this.txtPackageName_model.MaxLength = 10;
            this.txtPackageName_model.Name = "txtPackageName_model";
            this.txtPackageName_model.Size = new System.Drawing.Size(70, 29);
            this.txtPackageName_model.TabIndex = 3;
            this.txtPackageName_model.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPackageName_model.TextChanged += new System.EventHandler(this.txtPackageName_model_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "head";
            // 
            // txtPackageName_type
            // 
            this.txtPackageName_type.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName_type.Location = new System.Drawing.Point(409, 48);
            this.txtPackageName_type.MaxLength = 20;
            this.txtPackageName_type.Name = "txtPackageName_type";
            this.txtPackageName_type.Size = new System.Drawing.Size(70, 29);
            this.txtPackageName_type.TabIndex = 2;
            this.txtPackageName_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPackageName_type.TextChanged += new System.EventHandler(this.txtPackageName_type_TextChanged);
            // 
            // txtPackageName_Name
            // 
            this.txtPackageName_Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName_Name.Location = new System.Drawing.Point(48, 48);
            this.txtPackageName_Name.MaxLength = 200;
            this.txtPackageName_Name.Name = "txtPackageName_Name";
            this.txtPackageName_Name.Size = new System.Drawing.Size(355, 29);
            this.txtPackageName_Name.TabIndex = 1;
            this.txtPackageName_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPackageName_Name.TextChanged += new System.EventHandler(this.txtPackageName_Name_TextChanged);
            // 
            // txtPackageName_Head
            // 
            this.txtPackageName_Head.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName_Head.Location = new System.Drawing.Point(9, 48);
            this.txtPackageName_Head.MaxLength = 3;
            this.txtPackageName_Head.Name = "txtPackageName_Head";
            this.txtPackageName_Head.Size = new System.Drawing.Size(33, 29);
            this.txtPackageName_Head.TabIndex = 0;
            this.txtPackageName_Head.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPackageName_Head.TextChanged += new System.EventHandler(this.txtPackageName_Head_TextChanged);
            // 
            // grpSetSize
            // 
            this.grpSetSize.Controls.Add(this.label9);
            this.grpSetSize.Controls.Add(this.label10);
            this.grpSetSize.Controls.Add(this.label8);
            this.grpSetSize.Controls.Add(this.chkPortrait);
            this.grpSetSize.Controls.Add(this.label2);
            this.grpSetSize.Controls.Add(this.txtLandscapeCount);
            this.grpSetSize.Controls.Add(this.label1);
            this.grpSetSize.Controls.Add(this.chkSquare);
            this.grpSetSize.Controls.Add(this.txtSquareCount);
            this.grpSetSize.Controls.Add(this.chkLandscape);
            this.grpSetSize.Controls.Add(this.txtPortraitCount);
            this.grpSetSize.Controls.Add(this.txtPortraitWidth);
            this.grpSetSize.Controls.Add(this.txtSquareWidth);
            this.grpSetSize.Controls.Add(this.txtLandscapeWidth);
            this.grpSetSize.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grpSetSize.Location = new System.Drawing.Point(15, 180);
            this.grpSetSize.Name = "grpSetSize";
            this.grpSetSize.Size = new System.Drawing.Size(639, 134);
            this.grpSetSize.TabIndex = 1;
            this.grpSetSize.TabStop = false;
            this.grpSetSize.Text = "ReSize and Package";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Fluent Icons", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(37, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 24);
            this.label9.TabIndex = 26;
            this.label9.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe Fluent Icons", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 24);
            this.label10.TabIndex = 27;
            this.label10.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Fluent Icons", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 24);
            this.label8.TabIndex = 25;
            this.label8.Text = "";
            // 
            // chkPortrait
            // 
            this.chkPortrait.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPortrait.Location = new System.Drawing.Point(22, 28);
            this.chkPortrait.Name = "chkPortrait";
            this.chkPortrait.Size = new System.Drawing.Size(296, 32);
            this.chkPortrait.TabIndex = 0;
            this.chkPortrait.Text = "       [Potrait] Resize and Package :";
            this.chkPortrait.UseVisualStyleBackColor = true;
            this.chkPortrait.CheckedChanged += new System.EventHandler(this.chkPortrait_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(393, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "count";
            // 
            // txtLandscapeCount
            // 
            this.txtLandscapeCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLandscapeCount.Location = new System.Drawing.Point(387, 96);
            this.txtLandscapeCount.MaxLength = 5;
            this.txtLandscapeCount.Name = "txtLandscapeCount";
            this.txtLandscapeCount.ReadOnly = true;
            this.txtLandscapeCount.Size = new System.Drawing.Size(51, 29);
            this.txtLandscapeCount.TabIndex = 22;
            this.txtLandscapeCount.TabStop = false;
            this.txtLandscapeCount.Text = "0";
            this.txtLandscapeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "width px";
            // 
            // chkSquare
            // 
            this.chkSquare.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSquare.Location = new System.Drawing.Point(22, 60);
            this.chkSquare.Name = "chkSquare";
            this.chkSquare.Size = new System.Drawing.Size(294, 32);
            this.chkSquare.TabIndex = 2;
            this.chkSquare.Text = "       [Square] Resize and Package :";
            this.chkSquare.UseVisualStyleBackColor = true;
            this.chkSquare.CheckedChanged += new System.EventHandler(this.chkSquare_CheckedChanged);
            // 
            // txtSquareCount
            // 
            this.txtSquareCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSquareCount.Location = new System.Drawing.Point(387, 62);
            this.txtSquareCount.MaxLength = 5;
            this.txtSquareCount.Name = "txtSquareCount";
            this.txtSquareCount.ReadOnly = true;
            this.txtSquareCount.Size = new System.Drawing.Size(51, 29);
            this.txtSquareCount.TabIndex = 21;
            this.txtSquareCount.TabStop = false;
            this.txtSquareCount.Text = "0";
            this.txtSquareCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkLandscape
            // 
            this.chkLandscape.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLandscape.Location = new System.Drawing.Point(22, 92);
            this.chkLandscape.Name = "chkLandscape";
            this.chkLandscape.Size = new System.Drawing.Size(294, 36);
            this.chkLandscape.TabIndex = 4;
            this.chkLandscape.Text = "       [Landscape] Resize and Pacage  :";
            this.chkLandscape.UseVisualStyleBackColor = true;
            this.chkLandscape.CheckedChanged += new System.EventHandler(this.chkLandscape_CheckedChanged);
            // 
            // txtPortraitCount
            // 
            this.txtPortraitCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPortraitCount.Location = new System.Drawing.Point(387, 30);
            this.txtPortraitCount.MaxLength = 5;
            this.txtPortraitCount.Name = "txtPortraitCount";
            this.txtPortraitCount.ReadOnly = true;
            this.txtPortraitCount.Size = new System.Drawing.Size(51, 29);
            this.txtPortraitCount.TabIndex = 20;
            this.txtPortraitCount.TabStop = false;
            this.txtPortraitCount.Text = "0";
            this.txtPortraitCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPortraitWidth
            // 
            this.txtPortraitWidth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPortraitWidth.Location = new System.Drawing.Point(322, 30);
            this.txtPortraitWidth.MaxLength = 5;
            this.txtPortraitWidth.Name = "txtPortraitWidth";
            this.txtPortraitWidth.Size = new System.Drawing.Size(59, 29);
            this.txtPortraitWidth.TabIndex = 1;
            this.txtPortraitWidth.Text = "0";
            this.txtPortraitWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPortraitWidth.Validated += new System.EventHandler(this.txtPortraitWidth_Validated);
            // 
            // txtSquareWidth
            // 
            this.txtSquareWidth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSquareWidth.Location = new System.Drawing.Point(322, 62);
            this.txtSquareWidth.MaxLength = 5;
            this.txtSquareWidth.Name = "txtSquareWidth";
            this.txtSquareWidth.Size = new System.Drawing.Size(59, 29);
            this.txtSquareWidth.TabIndex = 3;
            this.txtSquareWidth.Text = "0";
            this.txtSquareWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSquareWidth.Validated += new System.EventHandler(this.txtSquareWidth_Validated);
            // 
            // txtLandscapeWidth
            // 
            this.txtLandscapeWidth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLandscapeWidth.Location = new System.Drawing.Point(322, 96);
            this.txtLandscapeWidth.MaxLength = 5;
            this.txtLandscapeWidth.Name = "txtLandscapeWidth";
            this.txtLandscapeWidth.Size = new System.Drawing.Size(59, 29);
            this.txtLandscapeWidth.TabIndex = 5;
            this.txtLandscapeWidth.Text = "0";
            this.txtLandscapeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLandscapeWidth.Validated += new System.EventHandler(this.txtLandscapeWidth_Validated);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Emoji", 45F);
            this.btnCancel.Location = new System.Drawing.Point(537, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 100);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "❌";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResizePack
            // 
            this.btnResizePack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResizePack.Font = new System.Drawing.Font("Segoe UI Emoji", 45F);
            this.btnResizePack.Location = new System.Drawing.Point(407, 407);
            this.btnResizePack.Name = "btnResizePack";
            this.btnResizePack.Size = new System.Drawing.Size(124, 100);
            this.btnResizePack.TabIndex = 5;
            this.btnResizePack.Text = "📦";
            this.btnResizePack.UseVisualStyleBackColor = true;
            this.btnResizePack.Click += new System.EventHandler(this.btnResizePack_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(11, 22);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(674, 23);
            this.progressBar.TabIndex = 11;
            this.progressBar.Visible = false;
            // 
            // lblFolder
            // 
            this.lblFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFolder.Font = new System.Drawing.Font("Segoe UI Emoji", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFolder.Location = new System.Drawing.Point(12, 216);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(673, 99);
            this.lblFolder.TabIndex = 12;
            this.lblFolder.Text = "📁";
            this.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFolder.Click += new System.EventHandler(this.lblFolder_Click);
            // 
            // lblpleaseDorpDown
            // 
            this.lblpleaseDorpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblpleaseDorpDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpleaseDorpDown.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblpleaseDorpDown.Location = new System.Drawing.Point(12, 216);
            this.lblpleaseDorpDown.Name = "lblpleaseDorpDown";
            this.lblpleaseDorpDown.Size = new System.Drawing.Size(673, 21);
            this.lblpleaseDorpDown.TabIndex = 13;
            this.lblpleaseDorpDown.Text = "Please Drop The Image Folder.";
            this.lblpleaseDorpDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlLogo.Location = new System.Drawing.Point(12, 368);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(674, 126);
            this.pnlLogo.TabIndex = 14;
            // 
            // lblShowInfo3
            // 
            this.lblShowInfo3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowInfo3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowInfo3.Location = new System.Drawing.Point(12, 644);
            this.lblShowInfo3.Name = "lblShowInfo3";
            this.lblShowInfo3.Size = new System.Drawing.Size(674, 19);
            this.lblShowInfo3.TabIndex = 15;
            this.lblShowInfo3.Text = "info:";
            this.lblShowInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblShowInfo3.Click += new System.EventHandler(this.lblShowInfo3_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 664);
            this.Controls.Add(this.lblShowInfo3);
            this.Controls.Add(this.lblpleaseDorpDown);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pnlResize);
            this.Controls.Add(this.btnRelord);
            this.Controls.Add(this.lblShowInfo2);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.lblShowInfo);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblFileIndex);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblImageWidth);
            this.Controls.Add(this.lblImageHeight);
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Please Drop the Image Folder.";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.pnlResize.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSetSize.ResumeLayout(false);
            this.grpSetSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblImageWidth;
        private System.Windows.Forms.Label lblImageHeight;
        private System.Windows.Forms.Label lblFileIndex;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblShowInfo;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Label lblShowInfo2;
        private System.Windows.Forms.Button btnRelord;
        private System.Windows.Forms.Panel pnlResize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnResizePack;
        private System.Windows.Forms.TextBox txtPortraitWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLandscape;
        private System.Windows.Forms.CheckBox chkSquare;
        private System.Windows.Forms.CheckBox chkPortrait;
        private System.Windows.Forms.TextBox txtLandscapeCount;
        private System.Windows.Forms.TextBox txtSquareCount;
        private System.Windows.Forms.TextBox txtPortraitCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLandscapeWidth;
        private System.Windows.Forms.TextBox txtSquareWidth;
        private System.Windows.Forms.GroupBox grpSetSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPackageName_Version;
        private System.Windows.Forms.TextBox txtPackageName_model;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPackageName_type;
        private System.Windows.Forms.TextBox txtPackageName_Name;
        private System.Windows.Forms.TextBox txtPackageName_Head;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPacageFolderName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoWEBP;
        private System.Windows.Forms.RadioButton rdoPng;
        private System.Windows.Forms.RadioButton rdoJpg90;
        private System.Windows.Forms.CheckBox chkRenameFile;
        private System.Windows.Forms.CheckBox chkAutoRelord;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblSystemInfo;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblpleaseDorpDown;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblShowInfo3;
    }
}

