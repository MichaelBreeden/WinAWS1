namespace WinAWS1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxMessages = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.textBoxAbout_About = new System.Windows.Forms.TextBox();
            this.tabPageBuckets = new System.Windows.Forms.TabPage();
            this.textBoxBuckets_Location = new System.Windows.Forms.TextBox();
            this.Buckets_dataGridView_Objects = new System.Windows.Forms.DataGridView();
            this.textBoxBuckets_ObjectName = new System.Windows.Forms.TextBox();
            this.labelBuckets_ObjectName = new System.Windows.Forms.Label();
            this.textBoxBuckets_FolderName = new System.Windows.Forms.TextBox();
            this.labelBuckets_FolderName = new System.Windows.Forms.Label();
            this.Buckets_dataGridView_Buckets = new System.Windows.Forms.DataGridView();
            this.textBoxBuckets_BucketName = new System.Windows.Forms.TextBox();
            this.labelBuckets_BucketName = new System.Windows.Forms.Label();
            this.panelBucketsButtons = new System.Windows.Forms.Panel();
            this.comboBoxBuckets_BucketOperations = new System.Windows.Forms.ComboBox();
            this.buttonBuckets_PreSignedURL = new System.Windows.Forms.Button();
            this.comboBoxBuckets_S3Regions = new System.Windows.Forms.ComboBox();
            this.labelBucketsRegion = new System.Windows.Forms.Label();
            this.labelBuckets_SetACL = new System.Windows.Forms.Label();
            this.comboBoxBuckets_S3CannedACL = new System.Windows.Forms.ComboBox();
            this.checkBoxBuckets_async = new System.Windows.Forms.CheckBox();
            this.tabPageGlacier = new System.Windows.Forms.TabPage();
            this.tabPageCloudFront = new System.Windows.Forms.TabPage();
            this.tabPageDynamoDb = new System.Windows.Forms.TabPage();
            this.tabPageSNS = new System.Windows.Forms.TabPage();
            this.tabPageSQS = new System.Windows.Forms.TabPage();
            this.buttonClear = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.tabPageBuckets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Buckets_dataGridView_Objects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Buckets_dataGridView_Buckets)).BeginInit();
            this.panelBucketsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(829, 8);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(108, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxMessages
            // 
            this.textBoxMessages.Location = new System.Drawing.Point(8, 8);
            this.textBoxMessages.Multiline = true;
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessages.Size = new System.Drawing.Size(562, 97);
            this.textBoxMessages.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAbout);
            this.tabControl1.Controls.Add(this.tabPageBuckets);
            this.tabControl1.Controls.Add(this.tabPageGlacier);
            this.tabControl1.Controls.Add(this.tabPageCloudFront);
            this.tabControl1.Controls.Add(this.tabPageDynamoDb);
            this.tabControl1.Controls.Add(this.tabPageSNS);
            this.tabControl1.Controls.Add(this.tabPageSQS);
            this.tabControl1.Location = new System.Drawing.Point(8, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 482);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.textBoxAbout_About);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(925, 456);
            this.tabPageAbout.TabIndex = 1;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // textBoxAbout_About
            // 
            this.textBoxAbout_About.Location = new System.Drawing.Point(6, 6);
            this.textBoxAbout_About.Multiline = true;
            this.textBoxAbout_About.Name = "textBoxAbout_About";
            this.textBoxAbout_About.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAbout_About.Size = new System.Drawing.Size(852, 372);
            this.textBoxAbout_About.TabIndex = 2;
            this.textBoxAbout_About.Text = resources.GetString("textBoxAbout_About.Text");
            // 
            // tabPageBuckets
            // 
            this.tabPageBuckets.Controls.Add(this.textBoxBuckets_Location);
            this.tabPageBuckets.Controls.Add(this.Buckets_dataGridView_Objects);
            this.tabPageBuckets.Controls.Add(this.textBoxBuckets_ObjectName);
            this.tabPageBuckets.Controls.Add(this.labelBuckets_ObjectName);
            this.tabPageBuckets.Controls.Add(this.textBoxBuckets_FolderName);
            this.tabPageBuckets.Controls.Add(this.labelBuckets_FolderName);
            this.tabPageBuckets.Controls.Add(this.Buckets_dataGridView_Buckets);
            this.tabPageBuckets.Controls.Add(this.textBoxBuckets_BucketName);
            this.tabPageBuckets.Controls.Add(this.labelBuckets_BucketName);
            this.tabPageBuckets.Controls.Add(this.panelBucketsButtons);
            this.tabPageBuckets.Location = new System.Drawing.Point(4, 22);
            this.tabPageBuckets.Name = "tabPageBuckets";
            this.tabPageBuckets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBuckets.Size = new System.Drawing.Size(925, 456);
            this.tabPageBuckets.TabIndex = 0;
            this.tabPageBuckets.Text = "Buckets";
            this.tabPageBuckets.UseVisualStyleBackColor = true;
            // 
            // textBoxBuckets_Location
            // 
            this.textBoxBuckets_Location.Location = new System.Drawing.Point(299, 6);
            this.textBoxBuckets_Location.Name = "textBoxBuckets_Location";
            this.textBoxBuckets_Location.ReadOnly = true;
            this.textBoxBuckets_Location.Size = new System.Drawing.Size(443, 20);
            this.textBoxBuckets_Location.TabIndex = 9;
            // 
            // Buckets_dataGridView_Objects
            // 
            this.Buckets_dataGridView_Objects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Buckets_dataGridView_Objects.Location = new System.Drawing.Point(253, 93);
            this.Buckets_dataGridView_Objects.MultiSelect = false;
            this.Buckets_dataGridView_Objects.Name = "Buckets_dataGridView_Objects";
            this.Buckets_dataGridView_Objects.Size = new System.Drawing.Size(362, 357);
            this.Buckets_dataGridView_Objects.TabIndex = 8;
            this.Buckets_dataGridView_Objects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Buckets_dataGridView_Objects_CellContentClick);
            // 
            // textBoxBuckets_ObjectName
            // 
            this.textBoxBuckets_ObjectName.Location = new System.Drawing.Point(96, 57);
            this.textBoxBuckets_ObjectName.Name = "textBoxBuckets_ObjectName";
            this.textBoxBuckets_ObjectName.Size = new System.Drawing.Size(180, 20);
            this.textBoxBuckets_ObjectName.TabIndex = 7;
            // 
            // labelBuckets_ObjectName
            // 
            this.labelBuckets_ObjectName.AutoSize = true;
            this.labelBuckets_ObjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuckets_ObjectName.Location = new System.Drawing.Point(6, 60);
            this.labelBuckets_ObjectName.Name = "labelBuckets_ObjectName";
            this.labelBuckets_ObjectName.Size = new System.Drawing.Size(84, 13);
            this.labelBuckets_ObjectName.TabIndex = 6;
            this.labelBuckets_ObjectName.Text = "Object Name:";
            // 
            // textBoxBuckets_FolderName
            // 
            this.textBoxBuckets_FolderName.Location = new System.Drawing.Point(96, 31);
            this.textBoxBuckets_FolderName.Name = "textBoxBuckets_FolderName";
            this.textBoxBuckets_FolderName.ReadOnly = true;
            this.textBoxBuckets_FolderName.Size = new System.Drawing.Size(180, 20);
            this.textBoxBuckets_FolderName.TabIndex = 5;
            // 
            // labelBuckets_FolderName
            // 
            this.labelBuckets_FolderName.AutoSize = true;
            this.labelBuckets_FolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuckets_FolderName.Location = new System.Drawing.Point(11, 34);
            this.labelBuckets_FolderName.Name = "labelBuckets_FolderName";
            this.labelBuckets_FolderName.Size = new System.Drawing.Size(82, 13);
            this.labelBuckets_FolderName.TabIndex = 4;
            this.labelBuckets_FolderName.Text = "Folder Name:";
            // 
            // Buckets_dataGridView_Buckets
            // 
            this.Buckets_dataGridView_Buckets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Buckets_dataGridView_Buckets.Location = new System.Drawing.Point(9, 93);
            this.Buckets_dataGridView_Buckets.MultiSelect = false;
            this.Buckets_dataGridView_Buckets.Name = "Buckets_dataGridView_Buckets";
            this.Buckets_dataGridView_Buckets.Size = new System.Drawing.Size(224, 357);
            this.Buckets_dataGridView_Buckets.TabIndex = 3;
            this.Buckets_dataGridView_Buckets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Buckets_dataGridView_Buckets_CellContentClick);
            // 
            // textBoxBuckets_BucketName
            // 
            this.textBoxBuckets_BucketName.Location = new System.Drawing.Point(96, 6);
            this.textBoxBuckets_BucketName.Name = "textBoxBuckets_BucketName";
            this.textBoxBuckets_BucketName.ReadOnly = true;
            this.textBoxBuckets_BucketName.Size = new System.Drawing.Size(180, 20);
            this.textBoxBuckets_BucketName.TabIndex = 2;
            // 
            // labelBuckets_BucketName
            // 
            this.labelBuckets_BucketName.AutoSize = true;
            this.labelBuckets_BucketName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuckets_BucketName.Location = new System.Drawing.Point(30, 9);
            this.labelBuckets_BucketName.Name = "labelBuckets_BucketName";
            this.labelBuckets_BucketName.Size = new System.Drawing.Size(60, 13);
            this.labelBuckets_BucketName.TabIndex = 1;
            this.labelBuckets_BucketName.Text = "Location:";
            // 
            // panelBucketsButtons
            // 
            this.panelBucketsButtons.Controls.Add(this.comboBoxBuckets_BucketOperations);
            this.panelBucketsButtons.Controls.Add(this.buttonBuckets_PreSignedURL);
            this.panelBucketsButtons.Controls.Add(this.comboBoxBuckets_S3Regions);
            this.panelBucketsButtons.Controls.Add(this.labelBucketsRegion);
            this.panelBucketsButtons.Controls.Add(this.labelBuckets_SetACL);
            this.panelBucketsButtons.Controls.Add(this.comboBoxBuckets_S3CannedACL);
            this.panelBucketsButtons.Controls.Add(this.checkBoxBuckets_async);
            this.panelBucketsButtons.Location = new System.Drawing.Point(764, 0);
            this.panelBucketsButtons.Name = "panelBucketsButtons";
            this.panelBucketsButtons.Size = new System.Drawing.Size(158, 376);
            this.panelBucketsButtons.TabIndex = 0;
            // 
            // comboBoxBuckets_BucketOperations
            // 
            this.comboBoxBuckets_BucketOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBuckets_BucketOperations.FormattingEnabled = true;
            this.comboBoxBuckets_BucketOperations.Items.AddRange(new object[] {
            "List Buckets",
            "Create Folder",
            "Upload",
            "Create Bucket",
            "Delete Bucket",
            "Does Bucket Exist"});
            this.comboBoxBuckets_BucketOperations.Location = new System.Drawing.Point(3, 6);
            this.comboBoxBuckets_BucketOperations.Name = "comboBoxBuckets_BucketOperations";
            this.comboBoxBuckets_BucketOperations.Size = new System.Drawing.Size(133, 21);
            this.comboBoxBuckets_BucketOperations.TabIndex = 14;
            this.comboBoxBuckets_BucketOperations.Text = "Bucket Operations";
            this.comboBoxBuckets_BucketOperations.SelectedIndexChanged += new System.EventHandler(this.comboBoxBuckets_BucketOperations_SelectedIndexChanged);
            // 
            // buttonBuckets_PreSignedURL
            // 
            this.buttonBuckets_PreSignedURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuckets_PreSignedURL.Location = new System.Drawing.Point(3, 33);
            this.buttonBuckets_PreSignedURL.Name = "buttonBuckets_PreSignedURL";
            this.buttonBuckets_PreSignedURL.Size = new System.Drawing.Size(133, 23);
            this.buttonBuckets_PreSignedURL.TabIndex = 12;
            this.buttonBuckets_PreSignedURL.Text = "PreSigned URL";
            this.buttonBuckets_PreSignedURL.UseVisualStyleBackColor = true;
            this.buttonBuckets_PreSignedURL.Click += new System.EventHandler(this.buttonBuckets_PreSignedURL_Click);
            // 
            // comboBoxBuckets_S3Regions
            // 
            this.comboBoxBuckets_S3Regions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBuckets_S3Regions.FormattingEnabled = true;
            this.comboBoxBuckets_S3Regions.Items.AddRange(new object[] {
            "US East 1"});
            this.comboBoxBuckets_S3Regions.Location = new System.Drawing.Point(3, 289);
            this.comboBoxBuckets_S3Regions.Name = "comboBoxBuckets_S3Regions";
            this.comboBoxBuckets_S3Regions.Size = new System.Drawing.Size(136, 21);
            this.comboBoxBuckets_S3Regions.TabIndex = 10;
            this.comboBoxBuckets_S3Regions.Text = "US East1";
            // 
            // labelBucketsRegion
            // 
            this.labelBucketsRegion.AutoSize = true;
            this.labelBucketsRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBucketsRegion.Location = new System.Drawing.Point(3, 273);
            this.labelBucketsRegion.Name = "labelBucketsRegion";
            this.labelBucketsRegion.Size = new System.Drawing.Size(51, 13);
            this.labelBucketsRegion.TabIndex = 9;
            this.labelBucketsRegion.Text = "Region:";
            // 
            // labelBuckets_SetACL
            // 
            this.labelBuckets_SetACL.AutoSize = true;
            this.labelBuckets_SetACL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuckets_SetACL.Location = new System.Drawing.Point(3, 313);
            this.labelBuckets_SetACL.Name = "labelBuckets_SetACL";
            this.labelBuckets_SetACL.Size = new System.Drawing.Size(57, 13);
            this.labelBuckets_SetACL.TabIndex = 8;
            this.labelBuckets_SetACL.Text = "Set ACL:";
            // 
            // comboBoxBuckets_S3CannedACL
            // 
            this.comboBoxBuckets_S3CannedACL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBuckets_S3CannedACL.FormattingEnabled = true;
            this.comboBoxBuckets_S3CannedACL.Items.AddRange(new object[] {
            "AuthenticatedRead",
            "AWSExecRead",
            "BucketOwnerFullControl",
            "BucketOwnerRead",
            "NoACL",
            "Private",
            "PublicRead",
            "PublicReadWrite"});
            this.comboBoxBuckets_S3CannedACL.Location = new System.Drawing.Point(3, 329);
            this.comboBoxBuckets_S3CannedACL.Name = "comboBoxBuckets_S3CannedACL";
            this.comboBoxBuckets_S3CannedACL.Size = new System.Drawing.Size(136, 21);
            this.comboBoxBuckets_S3CannedACL.TabIndex = 7;
            this.comboBoxBuckets_S3CannedACL.Text = "Private";
            this.comboBoxBuckets_S3CannedACL.SelectedIndexChanged += new System.EventHandler(this.comboBoxBuckets_S3CannedACL_SelectedIndexChanged);
            // 
            // checkBoxBuckets_async
            // 
            this.checkBoxBuckets_async.AutoSize = true;
            this.checkBoxBuckets_async.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBuckets_async.Location = new System.Drawing.Point(3, 356);
            this.checkBoxBuckets_async.Name = "checkBoxBuckets_async";
            this.checkBoxBuckets_async.Size = new System.Drawing.Size(60, 17);
            this.checkBoxBuckets_async.TabIndex = 6;
            this.checkBoxBuckets_async.Text = "Async";
            this.checkBoxBuckets_async.UseVisualStyleBackColor = true;
            // 
            // tabPageGlacier
            // 
            this.tabPageGlacier.Location = new System.Drawing.Point(4, 22);
            this.tabPageGlacier.Name = "tabPageGlacier";
            this.tabPageGlacier.Size = new System.Drawing.Size(925, 456);
            this.tabPageGlacier.TabIndex = 2;
            this.tabPageGlacier.Text = "Glacier";
            this.tabPageGlacier.UseVisualStyleBackColor = true;
            // 
            // tabPageCloudFront
            // 
            this.tabPageCloudFront.Location = new System.Drawing.Point(4, 22);
            this.tabPageCloudFront.Name = "tabPageCloudFront";
            this.tabPageCloudFront.Size = new System.Drawing.Size(925, 456);
            this.tabPageCloudFront.TabIndex = 3;
            this.tabPageCloudFront.Text = "CloudFront";
            this.tabPageCloudFront.UseVisualStyleBackColor = true;
            // 
            // tabPageDynamoDb
            // 
            this.tabPageDynamoDb.Location = new System.Drawing.Point(4, 22);
            this.tabPageDynamoDb.Name = "tabPageDynamoDb";
            this.tabPageDynamoDb.Size = new System.Drawing.Size(925, 456);
            this.tabPageDynamoDb.TabIndex = 4;
            this.tabPageDynamoDb.Text = "DynamoDb";
            this.tabPageDynamoDb.UseVisualStyleBackColor = true;
            // 
            // tabPageSNS
            // 
            this.tabPageSNS.Location = new System.Drawing.Point(4, 22);
            this.tabPageSNS.Name = "tabPageSNS";
            this.tabPageSNS.Size = new System.Drawing.Size(925, 456);
            this.tabPageSNS.TabIndex = 5;
            this.tabPageSNS.Text = "SNS";
            this.tabPageSNS.UseVisualStyleBackColor = true;
            // 
            // tabPageSQS
            // 
            this.tabPageSQS.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQS.Name = "tabPageSQS";
            this.tabPageSQS.Size = new System.Drawing.Size(925, 456);
            this.tabPageSQS.TabIndex = 6;
            this.tabPageSQS.Text = "SQS";
            this.tabPageSQS.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(580, 8);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBoxMessages);
            this.Controls.Add(this.buttonClose);
            this.Name = "Form1";
            this.Text = "Windows AWS Console";
            this.tabControl1.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            this.tabPageBuckets.ResumeLayout(false);
            this.tabPageBuckets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Buckets_dataGridView_Objects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Buckets_dataGridView_Buckets)).EndInit();
            this.panelBucketsButtons.ResumeLayout(false);
            this.panelBucketsButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxMessages;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBuckets;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.Panel panelBucketsButtons;
        private System.Windows.Forms.DataGridView Buckets_dataGridView_Buckets;
        private System.Windows.Forms.TextBox textBoxBuckets_BucketName;
        private System.Windows.Forms.Label labelBuckets_BucketName;
        private System.Windows.Forms.TextBox textBoxAbout_About;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxBuckets_FolderName;
        private System.Windows.Forms.Label labelBuckets_FolderName;
        private System.Windows.Forms.ComboBox comboBoxBuckets_S3CannedACL;
        private System.Windows.Forms.CheckBox checkBoxBuckets_async;
        private System.Windows.Forms.ComboBox comboBoxBuckets_S3Regions;
        private System.Windows.Forms.Label labelBucketsRegion;
        private System.Windows.Forms.Label labelBuckets_SetACL;
        private System.Windows.Forms.TabPage tabPageGlacier;
        private System.Windows.Forms.TabPage tabPageCloudFront;
        private System.Windows.Forms.TabPage tabPageDynamoDb;
        private System.Windows.Forms.TabPage tabPageSNS;
        private System.Windows.Forms.TabPage tabPageSQS;
        private System.Windows.Forms.TextBox textBoxBuckets_ObjectName;
        private System.Windows.Forms.Label labelBuckets_ObjectName;
        private System.Windows.Forms.DataGridView Buckets_dataGridView_Objects;
        private System.Windows.Forms.Button buttonBuckets_PreSignedURL;
        private System.Windows.Forms.TextBox textBoxBuckets_Location;
        private System.Windows.Forms.ComboBox comboBoxBuckets_BucketOperations;
    }
}

