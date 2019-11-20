using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

//using SharedCode;

namespace WinAWS1
{
    public partial class Form1 : Form
    {
        public c_S3BucketOperations cS3BucketOperations;

        public static string strInputLabelText;
        public static string strInputText;

        // Amazon.S3.Util.
        // AmazonS3Util - This has a number of interesting features.

        public Form1()
        {
            InitializeComponent();
            cS3BucketOperations = new c_S3BucketOperations();
            strInputLabelText = String.Empty;
            strInputText = String.Empty;
            hideInputPanel();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxMessages.Text = String.Empty;
        }

        private void showInputPanel()
        {
            strInputLabelText = "Zippy";
            //Input_panel.Visible = true;
            //Input_panel.Height = 72;
            //Input_panel.Width = 200;
        }

        private void hideInputPanel()
        {
            //Input_panel.Visible = false;
            //Input_panel.Height = 72;
            //Input_panel.Width = 200;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        private void comboBoxBuckets_BucketOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strBucketOperations = "Bucket Operations";
            if (comboBoxBuckets_BucketOperations.Text == "List Buckets")
            {   buttonBuckets_ListBuckets();
                comboBoxBuckets_BucketOperations.Text = strBucketOperations;
            }
            else if (comboBoxBuckets_BucketOperations.Text == "Create Folder")
            {
                strInputLabelText = "Folder Name:";
                FormInput form2 = new FormInput();
                form2.StartPosition = FormStartPosition.Manual;
                form2.Left = 500;
                form2.Top = 200;
                form2.ShowDialog(); // Form1);
                if (strInputText.Trim() == String.Empty)
                    return;
                textBoxMessages.AppendText("\r\n" + strInputText);
                textBoxBuckets_FolderName.Text = strInputText;
                buttonBuckets_CreateFolder();
                comboBoxBuckets_BucketOperations.Text = strBucketOperations;
            }
            else if (comboBoxBuckets_BucketOperations.Text == "Upload")
            {   buttonBuckets_UploadFiles();
                comboBoxBuckets_BucketOperations.Text = strBucketOperations;
            }
            else if (comboBoxBuckets_BucketOperations.Text == "Create Bucket")
            {
                strInputLabelText = "Bucket Name:";
                FormInput form2 = new FormInput();
                form2.StartPosition = FormStartPosition.Manual;
                form2.Left = 500;
                form2.Top = 200;
                form2.ShowDialog(); // Form1);
                if (strInputText.Trim() == String.Empty)
                    return; textBoxMessages.AppendText("\r\n" + strInputText);
                textBoxBuckets_BucketName.Text = strInputText;
                buttonBuckets_CreateBucket();
                comboBoxBuckets_BucketOperations.Text = strBucketOperations;
            }
            else if (comboBoxBuckets_BucketOperations.Text == "Delete Bucket")
            {   buttonBuckets_DeleteBucket();
                comboBoxBuckets_BucketOperations.Text = strBucketOperations;
            }
            else if (comboBoxBuckets_BucketOperations.Text == "Does Bucket Exist")
            {   buttonBuckets_BucketExists();
                comboBoxBuckets_BucketOperations.Text = strBucketOperations;
            }
            //else if (comboBoxBuckets_BucketOperations.Text == "List Objects") // This should not exist.
            //{   buttonBuckets_ListObjects();
            //    comboBoxBuckets_BucketOperations.Text = strBucketOperations;
            //}
        }

        private void buttonBuckets_BucketExists()
        {
            bool bExists = false;
            string strError = String.Empty;
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cS3BucketOperations.strBucketName = strBucketName;
            try
            {
                bExists = cS3BucketOperations.bDoesBucketExist();
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(1) BucketExists:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(2) BucketExists:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if (strError != String.Empty)
                textBoxMessages.AppendText("\r\n" + strError);
            else
                textBoxMessages.AppendText("\r\nBucketExists: " + strBucketName + " = " + bExists.ToString() + ".");
        }

        private void buttonBuckets_CreateBucket()
        {
            string strMethod = "CreateBucket";
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DialogResult.Yes != (MessageBox.Show("Are you sure you want to make Bucket " + strBucketName + "?", "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)))
                return;

            cS3BucketOperations.strBucketName = strBucketName;
            bool bExists = false;
            string strError = String.Empty;
            try
            {
                bExists = cS3BucketOperations.bDoesBucketExist();
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(1) " + strMethod + ":" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(2) " + strMethod + ":" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if (strError != String.Empty)
            {
                textBoxMessages.AppendText("\r\n" + strError);
                return;
            }

            if (bExists == true)
            {
                MessageBox.Show("Bucket  " + strBucketName + " already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cS3BucketOperations.CreateBucket(out strError);
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(1) " + strMethod + ":" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(2) " + strMethod + ":" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if (strError != String.Empty)
            {
                textBoxMessages.AppendText("\r\n" + strError);
                return;
            }
            else
            {
                textBoxMessages.AppendText("\r\nBucket" + cS3BucketOperations.strBucketName + " was created.");
                Buckets_dataGridView_Buckets.DataSource = cS3BucketOperations.dsBuckets;
            }
        }

        private void buttonBuckets_CreateFolder()
        {
            string strFolderName = textBoxBuckets_FolderName.Text.Trim();
            if (strFolderName == String.Empty)
            {
                MessageBox.Show("There needs to be Folder Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Need to see if folder already exists
            //cS3BucketOperations = new c_S3BucketOperations(strFolderName);
            cS3BucketOperations.strBucketName = strFolderName;
            try
            {
                if (cS3BucketOperations.bDoesFolderExist("") == true)
                {
                    MessageBox.Show("Bucket  " + strFolderName + " already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ### Make sure Folder doesn't exist.

                if (DialogResult.Yes != (MessageBox.Show("Are you sure you want to make Bucket " + strFolderName + "?", "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)))
                    return;

                //cS3BucketOperations.CreateNewFolder(strFolderName);
            }
            catch (Exception Exb1)
            {
                textBoxMessages.AppendText("\r\n" + Exb1.Message);
            }

            //textBoxMessages.AppendText("\r\n" + strResult);

            //CreateNewFolder(AmazonS3Client client)

            //using (IAmazonS3 s3Client = GetAmazonS3Client())
            //{
            //    try
            //    {
            //        PutObjectRequest folderRequest = new PutObjectRequest();
            //        String delimiter = "/";
            //        folderRequest.BucketName = "a-second-bucket-test";
            //        String folderKey = string.Concat("this-is-a-subfolder", delimiter);
            //        folderRequest.Key = folderKey;
            //        folderRequest.InputStream = new MemoryStream(new byte[0]);
            //       // PutObjectResponse folderResponse = s3Client.PutObject(folderRequest);
            //        PutObjectResponse folderResponse = cS3BucketOperations.c.PutObject(folderRequest);
            //}
        }

        /*private void bDoesFolderExist(string strFolderName)
        {
            ListObjectsRequest request = new ListObjectsRequest
            {
                BucketName = "MyBucketName",
                Prefix = "temp/"
            };
        }*/

        private void buttonBuckets_DeleteBucket()
        {
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cS3BucketOperations.strBucketName = strBucketName;
            string strError = String.Empty;
            try
            {
                if (cS3BucketOperations.bDoesBucketExist() == false)
                {
                    MessageBox.Show("Bucket  " + strBucketName + " was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DialogResult.Yes != (MessageBox.Show("Are you sure you want to delete the Bucket " + strBucketName + "?", "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)))
                    return;

                cS3BucketOperations.DeleteObjectNonVersionedBucket();
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(1) deleting Bucket:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(2) deleting Bucket:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if(strError != String.Empty)
                textBoxMessages.AppendText("\r\n" + strError);
            else
                textBoxMessages.AppendText("\r\nBucket:" + strBucketName + " Deleted.");
        }

        private void buttonBuckets_UploadFiles()
        {
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Temp\AWS_Test_Files\",
                Title = "Select Files To Upload",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true, 
                //DefaultExt = "txt",
                //Filter = "txt files (*.txt)|*.txt",
                //FilterIndex = 2,
                RestoreDirectory = true// , // restores the current directory before closing.
                //ReadOnlyChecked = true,
                //ShowReadOnly = true
            };

            string strFiles = String.Empty;
            List<string> lststrFiles = new List<string>();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    textBoxMessages.AppendText("\r\n" + file);
                    strFiles += "\r\n" + file;
                    lststrFiles.Add(file);
                }
            }
            if (DialogResult.Yes != (MessageBox.Show("Are you sure you want to upload these files to the " + strBucketName + " Bucket?" + strFiles, "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)))
                return;

            string strError = String.Empty;
            string strResult = String.Empty;
            StringBuilder sb = new StringBuilder();

            cS3BucketOperations.strBucketName = strBucketName;

            DateTime dt = DateTime.Now;
            foreach (string strFileName in lststrFiles)
            {
                try
                {
                    cS3BucketOperations.UploadFile(strFileName);
                    //strResult = cS3BucketOperations.UploadFileAsync(strFileName).Wait();
                    //cS3BucketOperations.UploadFileAsync(strFileName).Wait();
                    //strResult = await cS3BucketOperations.UploadFileAsync(strFileName);
                }
                catch (AmazonS3Exception e3)
                {
                    strError = "Error(1) Uploading file:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
                }
                catch (Exception ea)
                {
                    strError = "Error(2) Uploading file:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
                }
                if (strError != String.Empty)
                    sb.Append("\r\n" + strError);
                else
                    sb.Append("\r\nFile:" + strBucketName + " Uploaded.");
                DateTime dt1 = DateTime.Now;
                TimeSpan ts = new TimeSpan(dt1.Ticks - dt.Ticks);
                FileInfo fi = new FileInfo(strFileName);
                string str = "\r\nFile:" + strFileName + " " + fi.Length.ToString() + " Bytes Uploaded in:" + ts.TotalSeconds.ToString() + " Seconds";
                textBoxMessages.AppendText(str);
            }
            textBoxMessages.AppendText(sb.ToString());
        }

        private void buttonBuckets_ListBuckets()
        {
            string strError = String.Empty;
            //cS3BucketOperations = new c_S3BucketOperations();
            try
            {
                cS3BucketOperations.getBuckets_AsStrings( out strError);
                textBoxMessages.Lines = cS3BucketOperations.lststrBuckets.ToArray();
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(1) Listing Buckets:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(2) Listing Buckets:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if (strError != String.Empty)
                textBoxMessages.AppendText("\r\n" + strError);

            try { 
            cS3BucketOperations.getBuckets_AsTable();
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(3) Listing Buckets:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(4) Listing Buckets:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if (strError != String.Empty)
            {
                textBoxMessages.AppendText("\r\n" + strError);
                return;
            }

            if (cS3BucketOperations.dsBuckets.Tables[0].Rows.Count > 0)
                Buckets_dataGridView_Buckets.DataSource = cS3BucketOperations.dsBuckets.Tables[0];
            else
                textBoxMessages.AppendText("No Buckets Found.");
        }

        // How to filter using Delimiter and Prefix
        // https://docs.aws.amazon.com/AmazonS3/latest/dev/ListingKeysHierarchy.html
        //https://edunyte.com/2015/03/aws-s3-get-list-of-all-s3-objects-in-bucket/
        /* private void buttonBuckets_ListObjects() // This should not exist in menu
        {
            string strError = String.Empty;
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> lststr_Buckets = new List<string>();

            DataSet ds = new DataSet();
            try
            {
                cS3BucketOperations.ListingObjects();
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(1) Listing Objects:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(2) Listing Objects:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if (strError != String.Empty)
            {
                textBoxMessages.AppendText("\r\n" + strError);
                return;
            }            
            if (cS3BucketOperations.dsBuckets.Tables[0].Rows.Count > 0)
                Buckets_dataGridView_Objects.DataSource = cS3BucketOperations.dsBuckets.Tables[0];
            else
                textBoxMessages.AppendText("No Objects Found.");
        } */

        /// <summary>
        /// This is going to show the contents of a selected bucket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buckets_dataGridView_Buckets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do something on double click, except when on the header.
            if (e.RowIndex == -1)
            {
                return;
            }

            string strError = String.Empty;
            string strBucketName = Buckets_dataGridView_Buckets.Rows[e.RowIndex].Cells["BucketName"].Value.ToString();
            string strCreationDate = Buckets_dataGridView_Buckets.Rows[e.RowIndex].Cells["CreationDate"].Value.ToString();
            textBoxBuckets_BucketName.Text = strBucketName;
            //textBoxBuckets_Location.Text = "/";
            cS3BucketOperations.strBucketName = strBucketName;

            try
            {
                cS3BucketOperations.ListObjectsInRoot(textBoxBuckets_Location.Text);
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(1) Listing Objects:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(2) Listing Objects:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if (strError != String.Empty)
            {
                textBoxMessages.AppendText("\r\n" + strError);
                return;
            }
            if (cS3BucketOperations.dsBuckets.Tables[0].Rows.Count > 0)
                Buckets_dataGridView_Objects.DataSource = cS3BucketOperations.dsObjectForGrid.Tables[0];
            else
                textBoxMessages.AppendText("No Objects Found.");
        }

        private void comboBoxBuckets_S3CannedACL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ; // setS3CannedACL(string strValue, out string strError)
            /*
Again, we can see a Request and a corresponding Response object to create a bucket. We only 
specify a name which means that we go with the default values for e.g. permissions, they are 
usually fine. PutBucketRequest provides some properties to indicate values not adhering to 
the default ones. E.g. here’s how to give Everyone the permission to view the bucket:

S3Grant grant = new S3Grant();
S3Permission permission = new S3Permission("List");
S3Grantee grantee = new S3Grantee();
grantee.CanonicalUser = "Everyone";
grant.Grantee = grantee;
grant.Permission = permission;
List<S3Grant> grants = new List<S3Grant>() { grant };
putBucketRequest.Grants = grants;
            */
        }
        /// <summary>
        /// This could be a folder or an object (file)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buckets_dataGridView_Objects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Do something on double click, except when on the header.
            if (e.RowIndex == -1)
            {
                return;
            }

            string strError = String.Empty;
            //textBoxBuckets_BucketName.Text = strBucketName;
            //textBoxBuckets_Location.Text = "/";
            //cS3BucketOperations.strBucketName = strBucketName;

            string strObjectName = Buckets_dataGridView_Objects.Rows[e.RowIndex].Cells["Key"].Value.ToString();
            string strSize = Buckets_dataGridView_Objects.Rows[e.RowIndex].Cells["Size"].Value.ToString();
            if (strSize.Trim() == "Folder") // && endswith "/"
            {
                textBoxBuckets_Location.Text += strObjectName;
                try // get folder contents
                {
                    cS3BucketOperations.ListObjectsInRoot(textBoxBuckets_Location.Text);
                }
                catch (AmazonS3Exception e3)
                {
                    strError = "Error(1c) Listing Objects:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
                }
                catch (Exception ea)
                {
                    strError = "Error(2c) Listing Objects:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
                }
                if (strError != String.Empty)
                {
                    textBoxMessages.AppendText("\r\n" + strError);
                    return;
                }
                if (cS3BucketOperations.dsBuckets.Tables[0].Rows.Count > 0)
                    Buckets_dataGridView_Objects.DataSource = cS3BucketOperations.dsObjectForGrid.Tables[0];
                else
                    textBoxMessages.AppendText("No Objects Found.");
            } 
            else
            {
                // Get object information
                textBoxBuckets_ObjectName.Text = strObjectName;
            }
        }

        private void buttonBuckets_PreSignedURL_Click(object sender, EventArgs e)
        {
            string strResult = String.Empty;
            string strError = String.Empty;
            cS3BucketOperations = new c_S3BucketOperations();
            try
            {
                cS3BucketOperations.strBucketName = textBoxBuckets_BucketName.Text.Trim();
                cS3BucketOperations.strObjectName = textBoxBuckets_ObjectName.Text.Trim();
                cS3BucketOperations.GeneratePreSignedUrl(out strResult);
            }
            catch (AmazonS3Exception e3)
            {
                strError = "Error(1) Presigned URL:" + cS3BucketOperations.strBucketName + ". " + e3.ErrorCode + ". " + e3.Message + "...";
            }
            catch (Exception ea)
            {
                strError = "Error(2) Presigned URL:" + cS3BucketOperations.strBucketName + ". " + ea.Message + "...";
            }
            if (strError != String.Empty)
                textBoxMessages.AppendText("\r\n" + strError);
            else
               textBoxMessages.AppendText("\r\nPeSignedURL = " + strResult);
        }

    } // End public partial class Form1 : Form

    public static class Extensions
    {
        public static bool IsSuccess(this System.Net.HttpStatusCode code)
        {
            return code == System.Net.HttpStatusCode.OK || code == System.Net.HttpStatusCode.Created;
        }
    }

    public class c_BucketObjects
    {
        public c_BucketObjects()
        {
            lstc_BucketObject = new List<c_BucketObject>();
            lststr_Buckets = new List<string>();
            ds = new DataSet();
            iMaxKeys = 10;
            strPrefix = String.Empty;
        }
        //public string strBucketObject { get; set; }
        public List<c_BucketObject> lstc_BucketObject;
        public List<string> lststr_Buckets;
        public int iMaxKeys { get; set; }
        public string strPrefix { get; set; }
        public DataSet ds;

        public void Clear()
        {
            lstc_BucketObject.Clear();
        }
    }
    public class c_BucketObject
    {
        public c_BucketObject(string sKey, long lSize)
        {
            strKey = sKey; this.lSize = lSize;
        }
        public string strBucketObject { get; set; }
        public string strKey { get; set; }
        public long lSize { get; set; }
    }

 #region region_c_S3BucketOperations
    public class c_S3BucketOperations : IDisposable
    {
#region region_Declarations
        AmazonS3Client client;
        public c_BucketObjects cBucketAllObjects;

        /// <summary>
        /// For Folder Objects - Size = 0
        /// </summary>
        public c_BucketObjects cBucketObject_Folders;

        /// <summary>
        ///  For Files (Objects size > 0)
        /// </summary>
        public c_BucketObjects cBucketObject_Objects;

        internal List<string> lststrNamesObjectFolders = null;
        internal List<string> lststrNamesObject_Objects = null;

        /// <summary>
        /// only changes when bucket list is refreshed
        /// </summary>
        internal DataSet dsBuckets = null;
        internal DataSet dsObjectFolders = null;
        internal DataSet dsObjectObjects = null;
        internal DataSet dsObjectForGrid = null;

        public string strCurrentLocationInBucket { get; set; }
        public string strBucketName { get; set; }
        public string strObjectName { get; set; }
        public string strPrefix { get; set; }
        public string strDelimiter { get; set; }
        public int iLevel { get; set; }
        public string strErrorCode { get; set; }
        public string strErrorMessage { get; set; }
        public S3CannedACL cS3CannedACL;
        public BasicAWSCredentials credentials =
              new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
        TransferUtility transferUtil;

        const int const_buckets_0 = 0;

        /// <summary>
        /// To keep a list of buckets for validation of data.
        /// </summary>
        internal List<string> lststrBuckets = null;
#endregion // region_Declarations
        public c_S3BucketOperations()
        {
            cBucketAllObjects = new c_BucketObjects();
            cBucketObject_Folders = new c_BucketObjects();
            cBucketObject_Objects = new c_BucketObjects();
            lststrNamesObjectFolders = new List<string>();
            lststrNamesObject_Objects = new List<string>();
            dsObjectForGrid = new DataSet();
            dsBuckets = new DataSet();
            dsObjectFolders = new DataSet();
            dsObjectObjects = new DataSet();
            strBucketName = String.Empty;
            strObjectName = String.Empty;
            client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1);
            transferUtil = new TransferUtility(client);
            cS3CannedACL = S3CannedACL.Private; // default
            lststrBuckets = new List<string>();
            strDelimiter = "/";
        }

        /*public c_S3BucketOperations(string pstrBucketName)
        {
            strBucketName = pstrBucketName;
            strObjectName = "test.txt";
            client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1);
            transferUtil = new TransferUtility(client);
            cS3CannedACL = S3CannedACL.Private; // default
        }*/

        public void clearThis_ObjectsAndTables()
        {
            cBucketObject_Folders.Clear();
            cBucketObject_Objects.Clear();
            lststrNamesObjectFolders.Clear();
            lststrNamesObject_Objects.Clear();

            if (this.dsObjectFolders.Tables.Count == 0)
            {
                this.dsObjectFolders.Tables.Add(new DataTable("Folders"));
                this.dsObjectFolders.Tables[0].Columns.Add("Key", typeof(string));
                this.dsObjectFolders.Tables[0].Columns.Add("Size", typeof(string));
            }
            else
                dsObjectFolders.Clear();

            if (this.dsObjectObjects.Tables.Count == 0)
            {
                this.dsObjectObjects.Tables.Add(new DataTable("Objects"));
                this.dsObjectObjects.Tables[0].Columns.Add("Key", typeof(string));
                this.dsObjectObjects.Tables[0].Columns.Add("Size", typeof(string));
            }
            else
                dsObjectObjects.Clear();

            if (this.dsObjectForGrid.Tables.Count == 0)
            {
                this.dsObjectForGrid.Tables.Add(new DataTable("Objects"));
                this.dsObjectForGrid.Tables[0].Columns.Add("Key", typeof(string));
                this.dsObjectForGrid.Tables[0].Columns.Add("Size", typeof(string));
            }
            else
                dsObjectForGrid.Clear();
        }

        public int iGetDelimiterCount(string strLocation)
        {
            return strLocation.Count(x => x == this.strDelimiter[0]);
        }

        public void setS3CannedACL(string strValue, out string strError)
        {   // There is a comment above about how to grant permissions...
            strError = String.Empty;
            if (String.IsNullOrWhiteSpace(strValue) == true)
            {
                strError = "Invalid ACL value...";
                return;
            }
            switch (strValue)
            {
                case "AuthenticatedRead":
                    this.cS3CannedACL = S3CannedACL.AuthenticatedRead;
                    return;
                case "AWSExecRead":
                    this.cS3CannedACL = S3CannedACL.AWSExecRead;
                    return;
                case "BucketOwnerFullControl":
                    this.cS3CannedACL = S3CannedACL.BucketOwnerFullControl;
                    return;
                case "BucketOwnerRead":
                    this.cS3CannedACL = S3CannedACL.BucketOwnerRead;
                    return;
                case "NoACL":
                    this.cS3CannedACL = S3CannedACL.NoACL;
                    return;
                case "Private":
                    this.cS3CannedACL = S3CannedACL.Private;
                    return;
                case "PublicRead":
                    this.cS3CannedACL = S3CannedACL.PublicRead;

                    return;
                case "PublicReadWrite":
                    this.cS3CannedACL = S3CannedACL.PublicReadWrite;
                    return;
                default:
                    strError = "Unrecognized ACL value:" + strValue + "...";
                    return;
            }
        }
        public void getBuckets_AsStrings(out string strError) // Really this goes to messages, but is unused otherwise
        {
            strError = String.Empty;
            var credentials = new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
            using (AmazonS3Client client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1))
            {
                int iCounter = 0;
                lststrBuckets.Clear();
                foreach (var bucket in client.ListBuckets().Buckets)
                {
                    iCounter++;
                    lststrBuckets.Add(iCounter.ToString() + ". " + bucket.BucketName + "   " + bucket.CreationDate.ToShortDateString());
                }
            }
        }

        public void getBuckets_AsTable()
        {
            dsBuckets.Clear();
            if (dsBuckets.Tables.Count > 0)
                dsBuckets.Tables.RemoveAt(0);
            dsBuckets.Tables.Add(new DataTable("Buckets"));
            dsBuckets.Tables[0].Columns.Add("BucketName", typeof(string));
            //dsBuckets.Tables[0].Columns.Add("Region", typeof(string));
            dsBuckets.Tables[0].Columns.Add("CreationDate", typeof(string));
            List<string> lststr = new List<string>();

            //List<Pair<string, string>> strBuckets = new List<Pair<string, string>>();
            var credentials = new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
            using (AmazonS3Client client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1))
            {
                int iCounter = 0;
                foreach (var bucket in client.ListBuckets().Buckets)
                {
                    iCounter++;
                    lststr.Add(bucket.BucketName + "|" + bucket.CreationDate.ToShortDateString());
                    //dsBuckets.Tables[0].Rows.Add(new object[] { bucket.BucketName, bucket.CreationDate.ToShortDateString() });
                }
            }
            lststr.Sort();

            foreach (var str in lststr)
            {
                string[] strarr = str.Split('|');
                dsBuckets.Tables[0].Rows.Add(new object[] { strarr[0], strarr[1] });
            }
        }

        public bool bDoesBucketExist()
        {
            if (AmazonS3Util.DoesS3BucketExist(client, this.strBucketName))
                return true;
            return false;
        }

        public void CreateBucket(out string strResult)
        {
            strResult = "Error: Bucket Creation Failed";
            var bucket = new PutBucketRequest { BucketName = this.strBucketName, UseClientRegion = true };
            var bucketResponse = client.PutBucket(bucket);
            if (bucketResponse.HttpStatusCode.IsSuccess())
                strResult = String.Empty;
            getBuckets_AsTable();
        }

        // private static async Task DeleteObjectNonVersionedBucketAsync(string bucketName, string keyName, AmazonS3Client client)
        public void DeleteObjectNonVersionedBucket()//string bucketName, string keyName, AmazonS3Client client)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = this.strBucketName, //bucketName,
                Key = this.strBucketName // keyName
            };

            //await client.DeleteObjectAsync(deleteObjectRequest);
            client.DeleteObject(deleteObjectRequest);
        }

        // You want to create a folder in S3? No problem, we use the FileKey with the character '/' at 
        // the end to show that you want to create a folder.
        // https://www.codeproject.com/Articles/186132/Beginning-with-Amazon-S3

        /*public void CreateNewFile(AmazonS3Client client)
        {
            String S3_KEY = "Demo Create File.txt";
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = this.strBucketName,
                Key = S3_KEY,
                ContentBody = "This is body of S3 object."
                //--request.FilePath = "";
            };
            client.PutObject(request);
        }*/

        /*public void CreateNewFolder(string strKey) //AmazonS3Client client)
        {
            String S3_KEY = "DemoCreateFolder/";
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = this.strBucketName,
                Key = strKey + "/", // S3_KEY,
                ContentBody = ""
                //--request.FilePath = "";
            };
            client.PutObject(request);
        }*/

        /*public void CreateNewFileInFolder(AmazonS3Client client)
        {
            String S3_KEY = "DemoCreateFolder/" + "Demo Create File.txt";
            PutObjectRequest request = new PutObjectRequest();
            request.BucketName = this.strBucketName;
            request.Key = S3_KEY;
            request.ContentBody = "This is body of S3 object.";
            //--request.FilePath = "";
            client.PutObject(request);
        }*/

        public void UploadFile(string strFileName)
        {
            //transfareUtil.UploadDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\files",bucketName);
            //transfareUtil.Upload(AppDomain.CurrentDomain.BaseDirectory + "\\test.txt",bucketName);

            // The previous code uploaded it as private... by default. This code makes it public read

            string strParts = ConfigurationManager.AppSettings["Behaviors"];
                var fileTransferRequestM = new TransferUtilityUploadRequest
                {
                    //FilePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + strFileName, // test.txt",
                    FilePath = strFileName,
                    // StorageClass. ...
                    PartSize = 6291456, // 6 MB.
                                        // Key. ...
                    CannedACL = S3CannedACL.Private, // .PublicRead,
                    BucketName = strBucketName
                };
                var fileTransferRequestS = new TransferUtilityUploadRequest
                {
                    //FilePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + strFileName, // test.txt",
                    FilePath = strFileName,
                    // StorageClass. ...
                    //PartSize = 6291456, // 6 MB.
                                        // Key. ...
                    CannedACL = S3CannedACL.Private, // .PublicRead,
                    BucketName = strBucketName
                };

            if (strParts == "multipart")
                transferUtil.Upload(fileTransferRequestM);
            else
                transferUtil.Upload(fileTransferRequestS);
        }

        //public async Task UploadFileAsync(string strFileName)
        public async Task<string> UploadFileAsync(string strFileName)
        {
            string strResult = String.Empty;
            try
            {
                var credentials = new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
                using (AmazonS3Client client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1))
                {
                    var fileTransferUtility = new TransferUtility(client); //// s3Client);

                    //// Option 1. Upload a file. The file name is used as the object key name.
                    //await fileTransferUtility.UploadAsync(filePath, bucketName);
                    //Console.WriteLine("Upload 1 completed");

                    //// Option 2. Specify object key name explicitly.
                    //await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
                    //Console.WriteLine("Upload 2 completed");

                    //// Option 3. Upload data from a type of System.IO.Stream.
                    //using (var fileToUpload =
                    //    new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    //{
                    //    await fileTransferUtility.UploadAsync(fileToUpload,
                    //                               bucketName, keyName);
                    //}
                    //Console.WriteLine("Upload 3 completed");

                    string strKey = Path.GetFileName(strFileName);
                    DateTime dt = DateTime.Now;
                    // Option 4. Specify advanced settings.
                    var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = strBucketName, //bucketName,
                        FilePath = strFileName, //filePath,
                        // StorageClass = S3StorageClass.StandardInfrequentAccess,
                        PartSize = 6291456, // 6 MB.
                        // Key = keyName,
                        Key = strKey,
                        CannedACL = S3CannedACL.PublicRead // async return string
                    };
                    //fileTransferUtilityRequest.Metadata.Add("param1", "Value1");
                    //fileTransferUtilityRequest.Metadata.Add("param2", "Value2");

                    await fileTransferUtility.UploadAsync(fileTransferUtilityRequest);
                    Console.WriteLine("Upload 4 completed");
                    DateTime dt1 = DateTime.Now;
                    TimeSpan ts = new TimeSpan(dt1.Ticks - dt.Ticks);
                    FileInfo fi = new FileInfo(strFileName);
                    string str = "File:" + strFileName + " " + fi.Length.ToString() + " Bytes Uploaded in:" + ts.TotalSeconds.ToString() + " Seconds";
                    strResult = str;
                    MessageBox.Show(str, "Goo");
                }
            }
            catch (AmazonS3Exception e)
            {
                strResult = "Error encountered on server when writing an object:" + e.Message + "...";
            }
            catch (Exception e)
            {
                strResult = "Unknown Error encountered on server when writing an object:" + e.Message + "...";
            }
            Console.WriteLine(strResult);
            return strResult;
        }
        ////}

        public void BucketContents_List(List<string> lststr, out string strError)
        {
            strError = String.Empty;
            var credentials = new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
            using (AmazonS3Client client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1))
            {

                int iCounter = 0;
                foreach (var bucket in client.ListBuckets().Buckets)
                {
                    iCounter++;
                    lststr.Add(iCounter.ToString() + ". " + bucket.BucketName + "   " + bucket.CreationDate.ToShortDateString());
                }
            }
        }

        public bool bDoesFolderExist(string strPrefix)
        {
            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = strBucketName,
                Prefix = strPrefix,
                MaxKeys = 10
            };
            ListObjectsV2Response response;
            response = client.ListObjectsV2(request);
            if (response.S3Objects.Count > 0)
                return true;

            return false;
        }

        // This is interesting, but it doesn't seem to work as it is...
        public bool bDoesFolderExist(string strPrefix, int iThrowaway)
        {
            ListObjectsRequest findFolderRequest = new ListObjectsRequest();
            findFolderRequest.BucketName = strBucketName; //  "a-second-bucket-test";
            findFolderRequest.Delimiter = strDelimiter;       // "/";
            findFolderRequest.Prefix = strObjectName; // "this-is-a-subfolder";
            ListObjectsResponse findFolderResponse = client.ListObjects(findFolderRequest);
            List<String> commonPrefixes = findFolderResponse.CommonPrefixes;
            //Boolean folderExists = commonPrefixes.Any(); // Doesn't know what "Any" is

            if (commonPrefixes.Count > 0)
                return true;

            return false;
        }

        // In S3 folders don't exist, per se. s3 objects are key/value pairs. the key is the "filename" which 
        // represents a full path containing "/" characters. the value for a key is the actual file content. 

        // Filter is like "*.PRF"

        // S3 has always supported a prefix, which filters the list.
        // Only keys with a matching prefix are displayed:

        // Later, S3 added a delimiter, which tells S3 to behave as though it has subdirectories.

        // So the Prefix gives the location relative to the root

        // So if you got everything in root Delimiter="" and Prefix=""
        //   everything unique with a "/", would be the folder list
        //   everything without a "/" would be an object (file)

        // So if you got everything in root Delimiter="/" and Prefix="Folder1"
        // If a Bucket is selected, you can just get the objects or everything and extract the folders.
        public void ListObjectsInRoot(string strLocation) // This can be used
        {
            this.clearThis_ObjectsAndTables();

            int iDelimiterCount = this.iGetDelimiterCount(strLocation);

            // This returns just files (objects) in root
            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = strBucketName,
                MaxKeys = this.cBucketObject_Folders.iMaxKeys,
                // nothing -  Folders, objects, Folders/Objects
                // Delimiter = "/" // All objects (files) in root V
                // Delimiter = ""  // Everything in bucket
                // Prefix = ""     // Everything in bucket
                // Prefix = "/"    // Nothing
                // Delimiter = "/", Prefix = ""  // objects, no folders V
                // Delimiter = "",  Prefix = "/"   // nothing V
                // Delimiter = "/", Prefix = "/"   // nothing V
                // Delimiter = "",  Prefix = "Folder1/"  // listed everything that started with Folder1 - ?filter out folders and objects
                // Delimiter = "",  Prefix = "Folder1"   // returned itself and all objects and folders with that prefix
                // Delimiter = "/", Prefix = "Folder1"  // listed nothing V
                // Delimiter = "/", Prefix = "Folder1/" // returned itself and all files with that prefix, so no folders - neatish
                Delimiter = "/", Prefix = strLocation
                // Delimiter = "/", Prefix = "Folder1/Folder1Fold1" // nothing
                // Delimiter = "/", Prefix = "Folder1/Folder1Fold1/" // Itself and all objects in it.
            };
            ListObjectsV2Response response;
            do
            {
                //response = await client.ListObjectsV2Async(request);
                response = client.ListObjectsV2(request);
                
                foreach (S3Object entry in response.S3Objects) // Process the response.
                {
                    if(entry.Size > 0)
                       cBucketObject_Objects.lstc_BucketObject.Add(new c_BucketObject(entry.Key, entry.Size));
                }
                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);

            // Now get the folders
            //ListObjectsV2Request request = new ListObjectsV2Request
            request = new ListObjectsV2Request
            {
                BucketName = strBucketName,
                MaxKeys = this.cBucketObject_Folders.iMaxKeys
            };
            //ListObjectsV2Response response;
            do
            {
                //response = await client.ListObjectsV2Async(request);
                response = client.ListObjectsV2(request);

                // Process the response.
                // Filter through the response to find keys that:
                // - end with the delimiter character '/' 
                // - are empty. 
                //IEnumerable<S3Object> folders = response.S3Objects.Where(x =>
                //    x.Key.EndsWith(@"/") && x.Size == 0);

                // Do something with your output keys.  For this example, we write to the console.
                //folders.ToList().ForEach(x => System.Console.WriteLine(x.Key));

                foreach (S3Object entry in response.S3Objects)
                    if ((entry.Size == 0) && (entry.Key != strLocation)
                        && ((iDelimiterCount + 1) == iGetDelimiterCount(entry.Key))
                       )
                        cBucketObject_Folders.lstc_BucketObject.Add(new c_BucketObject(entry.Key, entry.Size));
                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);

            // Now sort them by name.
            cBucketObject_Folders.lstc_BucketObject.Sort(delegate (c_BucketObject c1, c_BucketObject c2) { return c1.strKey.CompareTo(c2.strKey); });
            foreach (c_BucketObject cBucketObject in cBucketObject_Folders.lstc_BucketObject)
            {
                // if(delimiter count ...
                dsObjectForGrid.Tables[0].Rows.Add(cBucketObject.strKey, "Folder");
                this.lststrNamesObjectFolders.Add(cBucketObject.strKey);
            }

            cBucketObject_Objects.lstc_BucketObject.Sort(delegate (c_BucketObject c1, c_BucketObject c2) { return c1.strKey.CompareTo(c2.strKey); });
            foreach (c_BucketObject cBucketObject in cBucketObject_Objects.lstc_BucketObject)
            {
                int iPad = 24 - (cBucketObject.lSize.ToString().Length * 2); // lame formatting of file size
                dsObjectForGrid.Tables[0].Rows.Add(cBucketObject.strKey, cBucketObject.lSize.ToString().PadLeft(iPad));
                //dsObjectForGrid.Tables[0].Rows.Add(cBucketObject.strKey, cBucketObject.lSize.ToString());
                this.lststrNamesObject_Objects.Add(cBucketObject.strKey);
            }
        }

        public void ListingObjectsFolders() // This can be used
        {
            this.clearThis_ObjectsAndTables();

            // This returns just files (objects) in root
            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = strBucketName,
                MaxKeys = this.cBucketObject_Folders.iMaxKeys
            };
            ListObjectsV2Response response;
            do
            {
                //response = await client.ListObjectsV2Async(request);
                response = client.ListObjectsV2(request);

                // Process the response.
                // Filter through the response to find keys that:
                // - end with the delimiter character '/' 
                // - are empty. 
                //IEnumerable<S3Object> folders = response.S3Objects.Where(x =>
                //    x.Key.EndsWith(@"/") && x.Size == 0);

                // Do something with your output keys.  For this example, we write to the console.
                //folders.ToList().ForEach(x => System.Console.WriteLine(x.Key));

                foreach (S3Object entry in response.S3Objects)                    
                    if ((entry.Size == 0))
                        cBucketObject_Folders.lstc_BucketObject.Add(new c_BucketObject(entry.Key, entry.Size));
                    request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);

            // Now sort them by name.
            cBucketObject_Folders.lstc_BucketObject.Sort(delegate (c_BucketObject c1, c_BucketObject c2) { return c1.strKey.CompareTo(c2.strKey); });
            //cBucketObject_Objects.lstc_BucketObject.Sort(delegate (c_BucketObject c1, c_BucketObject c2) { return c1.strKey.CompareTo(c2.strKey); });

            foreach (c_BucketObject cBucketObject in cBucketObject_Folders.lstc_BucketObject)
            {
                dsObjectForGrid.Tables[0].Rows.Add(cBucketObject.strKey, "Folder");
                this.lststrNamesObjectFolders.Add(cBucketObject.strKey);
            }

            ////foreach (c_BucketObject cBucketObject in cBucketObject_Objects.lstc_BucketObject)
            ////{
            ////    int iPad = 24 - (cBucketObject.lSize.ToString().Length * 2); // lame formatting of file size
            ////    dsObjectForGrid.Tables[0].Rows.Add(cBucketObject.strKey, cBucketObject.lSize.ToString().PadLeft(iPad));
            ////    this.lststrNamesObjectObjects.Add(cBucketObject.strKey); // probably not used
            ////}
        }

        // Not used... yet.
        public void ListingObjects(DataSet ds, c_BucketObjects cBucketObjects)
        {
            ds.Tables.Add(new DataTable("Objects"));
            DataTable dt = new DataTable();
            ds.Tables[0].Clear();
            ds.Tables[0].Columns.Add("Key", typeof(string));
            ds.Tables[0].Columns.Add("Size", typeof(string));

            ListObjectsV2Request request = new ListObjectsV2Request
            {
                BucketName = strBucketName,
                Prefix = cBucketObjects.strPrefix,
                MaxKeys = cBucketObjects.iMaxKeys
            };
            ListObjectsV2Response response;
            do
            {
                //response = await client.ListObjectsV2Async(request);
                response = client.ListObjectsV2(request);

                // Process the response.
                foreach (S3Object entry in response.S3Objects)
                {
                    ds.Tables[0].Rows.Add(entry.Key, entry.Size.ToString());
                }
                //Console.WriteLine("Next Continuation Token: {0}", response.NextContinuationToken);
                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);
        }

        static async Task ListingObjectsAsync(string strBucketName, AmazonS3Client client)
        {
            string strError = String.Empty;
            try
            {
                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = strBucketName,
                    MaxKeys = 10
                };
                ListObjectsV2Response response;
                do
                {
                    response = await client.ListObjectsV2Async(request);

                    // Process the response.
                    foreach (S3Object entry in response.S3Objects)
                    {
                        Console.WriteLine("key = {0} size = {1}",
                            entry.Key, entry.Size);
                    }
                    Console.WriteLine("Next Continuation Token: {0}", response.NextContinuationToken);
                    request.ContinuationToken = response.NextContinuationToken;
                } while (response.IsTruncated);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                Console.WriteLine("S3 error occurred. Exception: " + amazonS3Exception.ToString());
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                Console.ReadKey();
            }
        }

        public async Task DownloadFileAsync()
        {
            string content = string.Empty;
            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = strBucketName,
                Key = "test.txt"
            };
            using (GetObjectResponse response = await client.GetObjectAsync(request))
            {
                using (Stream responseStream = response.ResponseStream)
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        string contenType = response.Headers["Content-Type"];
                        content = reader.ReadToEnd();
                        Console.WriteLine("File Content:");
                        Console.WriteLine(content);
                        Console.WriteLine("File Content Type: " + contenType);
                    }
                }
            }
            Console.WriteLine("File Download Successfully");
        }
        public void GeneratePreSignedUrl(out string strResult)
        {
            strResult = String.Empty;
            int iAddedMonths = 3;
            //You can use Signature Version 2 by setting AWSConfigsS3.UseSignatureVersion4 = false;
            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
            {
                BucketName = strBucketName,
                Key = strObjectName, // "test.txt",
                //Expires = DateTime.Now.AddHours(1)
                Expires = DateTime.Now.AddMonths(iAddedMonths)
            };
            // client.Config.SignatureVersion = Si
            var url = client.GetPreSignedURL(request);
            strResult = url;
        }
        public void GetObjectTagging()
        {
            GetObjectTaggingRequest tagRequest = new GetObjectTaggingRequest
            {

                BucketName = strBucketName,
                Key = strObjectName
            };
            GetObjectTaggingResponse objectTags = client.GetObjectTagging(tagRequest);
            if (objectTags.Tagging.Count == 0)
            {
                Console.WriteLine("No Tags Found");
            }
            foreach (var tag in objectTags.Tagging)
            {
                Console.WriteLine($"Key: {tag.Key}, Value: {tag.Value}");
            }
        }
        public void UpdateObjectTagging()
        {
            GetObjectTagging();
            Tagging tags = new Tagging();
            tags.TagSet = new List<Tag>
            {
                new Tag{Key="Key1",Value="Val1"},
                new Tag{Key="Key2",Value="Val2"}
            };
            PutObjectTaggingRequest request = new PutObjectTaggingRequest
            {
                BucketName = strBucketName,
                Key = strObjectName,
                Tagging = tags
            };
            PutObjectTaggingResponse response = client.PutObjectTagging(request);
            if (response.HttpStatusCode.IsSuccess())
            {
                Console.WriteLine("Object Tags updated successfully");
            }
            GetObjectTagging();
        }
        public void UpdateObjectACL()
        {
            PutACLRequest request = new PutACLRequest { BucketName = strBucketName, Key = strObjectName, CannedACL = S3CannedACL.PublicRead };
            var response = client.PutACL(request);
            if (response.HttpStatusCode.IsSuccess())
            {
                Console.WriteLine("Object ACL Updated Successfully");
            }
        }

        public void BucketVersioning() // Enable versioning
        {
            PutBucketVersioningRequest request = new PutBucketVersioningRequest
            {
                BucketName = strBucketName,
                VersioningConfig = new S3BucketVersioningConfig { EnableMfaDelete = false, Status = VersionStatus.Enabled }
            };
            var response = client.PutBucketVersioning(request);
            if (response.HttpStatusCode.IsSuccess())
            {
                Console.WriteLine("Bucket Versioning successful");
            }
        }

        // There is a new utility called Amazon S3 Transfer Acceleration - Speed Comparison
        // That can show how much this helps... or slows things down... It can do either.
        public void BucketAccelerate() // New feature uses CloudFront. So you can pick...
        {
            PutBucketAccelerateConfigurationRequest request = new PutBucketAccelerateConfigurationRequest
            {
                BucketName = strBucketName, // only one thing
                AccelerateConfiguration = new AccelerateConfiguration
                {
                    Status = BucketAccelerateStatus.Enabled
                }
            };
            var respone = client.PutBucketAccelerateConfiguration(request);
            if (respone.HttpStatusCode.IsSuccess())
            {
                Console.WriteLine("Bucket Accelerate successful");
            }
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose");
            client.Dispose();
        }

        // UNUSED
        public static DataTable resort(DataTable dt, string colName, string direction)
        {
            dt.DefaultView.Sort = colName + " " + direction;
            dt = dt.DefaultView.ToTable();
            return dt;
        }
    } // End class c_S3BucketOperations

#endregion // region_c_S3BucketOperations
}
