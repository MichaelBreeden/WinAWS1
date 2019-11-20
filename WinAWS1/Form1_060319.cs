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
//using System.Linq;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxMessages.Text = String.Empty;
        }
        private void buttonBuckets_BucketExists_Click(object sender, EventArgs e)
        {
            bool bExists = false;
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cS3BucketOperations = new c_S3BucketOperations(strBucketName);
            try
            {
                bExists = cS3BucketOperations.bDoesBucketExist();
            }
            catch (Exception ex1)
            {
                textBoxMessages.Text = textBoxMessages.Text + Environment.NewLine + ex1.Message;
            }
            if (bExists == true)
                textBoxMessages.Text = textBoxMessages.Text + Environment.NewLine + "Bucket " + cS3BucketOperations.strBucketName + " Exists...";
            else
                textBoxMessages.Text = textBoxMessages.Text + Environment.NewLine + "Bucket " + cS3BucketOperations.strBucketName + " does not Exist...";
        }

        private void buttonBuckets_CreateBucket_Click(object sender, EventArgs e)
        {
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cS3BucketOperations = new c_S3BucketOperations(strBucketName);
            string strResult = String.Empty;
            try
            {
                if(cS3BucketOperations.bDoesBucketExist() == true)
                {
                    MessageBox.Show("Bucket  " + strBucketName + " already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DialogResult.Yes != (MessageBox.Show("Are you sure you want to make Bucket " + strBucketName + "?", "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)))
                    return;

                cS3BucketOperations.CreateBucket(out strResult);
            }
            catch (Exception Exb1)
            {
                textBoxMessages.AppendText("\r\n" + Exb1.Message);
            }
            textBoxMessages.AppendText("\r\n" + strResult);
        }

        private void buttonBuckets_CreateFolder_Click(object sender, EventArgs e)
        {
            string strBucketName = textBoxBuckets_FolderName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Folder Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cS3BucketOperations = new c_S3BucketOperations(strBucketName);
            string strResult = String.Empty; 
        }

        private void buttonBuckets_DeleteBucket_Click(object sender, EventArgs e)
        {
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cS3BucketOperations = new c_S3BucketOperations(strBucketName);
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

                cS3BucketOperations.DeleteObjectNonVersionedBucket(out strError);
            }
            catch (Exception Exb1)
            {
                textBoxMessages.AppendText("\r\n" + Exb1.Message);
            }
            if(strError != "")
                textBoxMessages.AppendText(strError);
            else
                textBoxMessages.AppendText("\r\nBucket:" + strBucketName + " Deleted.");
        }

        private void buttonBuckets_UploadFiles_Click(object sender, EventArgs e)
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
                //textBoxMessages.AppendText(openFileDialog1.FileName);
                foreach (String file in openFileDialog1.FileNames)
                {
                    textBoxMessages.AppendText("\r\n" + file);
                    strFiles += "\r\n" + file;
                    lststrFiles.Add(file);
                }
            }
            if (DialogResult.Yes != (MessageBox.Show("Are you sure you want to upload these files to the " + strBucketName + " Bucket?" + strFiles, "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)))
                return;

            string strResult = String.Empty;
            StringBuilder sb = new StringBuilder();
            cS3BucketOperations = new c_S3BucketOperations(strBucketName);

            foreach (string strFileName in lststrFiles)
            {
                cS3BucketOperations.UploadFile(strFileName, out strResult);
                sb.Append("\r\n" + strResult);
            }
            textBoxMessages.AppendText(sb.ToString());
        }

        private void buttonBuckets_ListBuckets_Click(object sender, EventArgs e)
        {
            string strError = String.Empty;
            List<string> lststr_Buckets = new List<string>();
            cS3BucketOperations = new c_S3BucketOperations();
            try
            {
                cS3BucketOperations.getBuckets_AsStrings(lststr_Buckets, out strError);
                textBoxMessages.Lines = lststr_Buckets.ToArray();
            }
            catch(Exception Exb1)
            {
                textBoxMessages.AppendText(Exb1.Message);
            }
            DataSet ds = new DataSet();

            try { 
            cS3BucketOperations.getBuckets_AsTable(ds);
            }
            catch (Exception Exb1)
            {
                textBoxMessages.AppendText(Exb1.Message);
            }

            if (ds.Tables[0].Rows.Count > 0)
                dataGridViewBuckets1.DataSource = ds.Tables[0];
            else
                textBoxMessages.AppendText("No Buckets Found.");
        }


        // How to filter using Delimiter and Prefix
        // https://docs.aws.amazon.com/AmazonS3/latest/dev/ListingKeysHierarchy.html
        //https://edunyte.com/2015/03/aws-s3-get-list-of-all-s3-objects-in-bucket/
        private void buttonBuckets_ListObjects_Click(object sender, EventArgs e)
        {
            string strError = String.Empty;
            string strBucketName = textBoxBuckets_BucketName.Text.Trim();
            if (strBucketName == String.Empty)
            {
                MessageBox.Show("There needs to be Bucket Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<string> lststr_Buckets = new List<string>();
            cS3BucketOperations = new c_S3BucketOperations();
            cS3BucketOperations.strBucketName = strBucketName;

            DataSet ds = new DataSet();
            try
            {
                cS3BucketOperations.ListingObjects(ds, out strError);
                dataGridViewBuckets_Objects.DataSource = ds.Tables[0];
            }
            catch (Exception Exb1)
            {
                textBoxMessages.AppendText(Exb1.Message);
            }
        }

        private void dataGridViewBuckets1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strBucketName = dataGridViewBuckets1.Rows[e.RowIndex].Cells["BucketName"].Value.ToString();
            string strCreationDate = dataGridViewBuckets1.Rows[e.RowIndex].Cells["CreationDate"].Value.ToString();
            textBoxBuckets_BucketName.Text = strBucketName;
        }

        private void comboBoxBuckets_S3CannedACL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ; // setS3CannedACL(string strValue, out string strError)
        }

        private void dataGridViewBuckets_Objects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strBucketName = dataGridViewBuckets_Objects.Rows[e.RowIndex].Cells  ["Key"].Value.ToString();
            string strCreationDate = dataGridViewBuckets_Objects.Rows[e.RowIndex].Cells["Size"].Value.ToString();
            textBoxBuckets_ObjectName.Text = strBucketName;

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
                cS3BucketOperations.GeneratePreSignedUrl(out strResult, out strError);
                textBoxMessages.AppendText("\r\nPeSignedURL = " + strResult);
            }
            catch (Exception Exb1)
            {
                textBoxMessages.AppendText(Exb1.Message);
            }
            
        }


    } // End public partial class Form1 : Form

    public static class Extensions
    {
        public static bool IsSuccess(this System.Net.HttpStatusCode code)
        {
            return code == System.Net.HttpStatusCode.OK || code == System.Net.HttpStatusCode.Created;
        }
    }

    //public class c_Bucket // unused
    //{
    //    string strBucketName { get; set; }
    //}

#region region_c_S3BucketOperations
    public class c_S3BucketOperations : IDisposable
    {
        AmazonS3Client client;
        public string strBucketName { get; set; }
        public string strObjectName { get; set; }
        public S3CannedACL cS3CannedACL;
        public BasicAWSCredentials credentials =
              new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
        TransferUtility transferUtil;

        public c_S3BucketOperations()
        {
            strBucketName = "zagwap.com";
            strObjectName = "test.txt";
            client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1);
            transferUtil = new TransferUtility(client);
            cS3CannedACL = S3CannedACL.Private; // default
        }

        public c_S3BucketOperations(string pstrBucketName)
        {
            strBucketName = pstrBucketName;
            strObjectName = "test.txt";
            client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1);
            transferUtil = new TransferUtility(client);
            cS3CannedACL = S3CannedACL.Private; // default
        }

        public void setS3CannedACL(string strValue, out string strError)
        {
            strError = String.Empty;
            if(String.IsNullOrWhiteSpace(strValue) == true)
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
        public void getBuckets_AsStrings(List<string> lststr, out string strError)
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

        public void getBuckets_AsTable(DataSet ds)
        {
            try
            {
                ds.Tables.Add(new DataTable("Buckets"));
                DataTable dt = new DataTable();
                ds.Tables[0].Clear();
                ds.Tables[0].Columns.Add("BucketName", typeof(string));
                ds.Tables[0].Columns.Add("CreationDate", typeof(string));

                var credentials = new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
                using (AmazonS3Client client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1))
                {
                    int iCounter = 0;
                    foreach (var bucket in client.ListBuckets().Buckets)
                    {
                        iCounter++;
                        //lststr.Add(iCounter.ToString() + ". " + bucket.BucketName + "   " + bucket.CreationDate.ToShortDateString());
                        ds.Tables[0].Rows.Add(new object[] { bucket.BucketName, bucket.CreationDate.ToShortDateString() });
                    }
                }
            }
            catch (Exception Ebt)
            {
                throw new Exception("getBuckets_Table() " + Ebt.Message + "...");
            }
        }

        public bool bDoesBucketExist()
        {
            bool bReturn = false;
            try
            {
                if (AmazonS3Util.DoesS3BucketExist(client, this.strBucketName))
                {
                    bReturn = true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error bDoesBucketExist() " + ex.Message + "...");
            }
            return bReturn;
        }

        public void CreateBucket(out string strResult)
        {
            var bucket = new PutBucketRequest { BucketName = this.strBucketName, UseClientRegion = true };
            var bucketResponse = client.PutBucket(bucket);
            if (bucketResponse.HttpStatusCode.IsSuccess())
                strResult = "Bucket Created Successfully";
            else
                strResult = "Error: Bucket Creation Failed";
        }

        // private static async Task DeleteObjectNonVersionedBucketAsync(string bucketName, string keyName, AmazonS3Client client)
        public void DeleteObjectNonVersionedBucket(out string strError)//string bucketName, string keyName, AmazonS3Client client)
        {
            strError = String.Empty;
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = this.strBucketName, //bucketName,
                    Key = this.strBucketName // keyName
                };

                Console.WriteLine("Deleting an object");
                //await client.DeleteObjectAsync(deleteObjectRequest);
                client.DeleteObject(deleteObjectRequest);
            }
            catch (AmazonS3Exception e)
            {
                strError = "Error(1) deleting Bucket:" + this.strBucketName +  ". " + e.ErrorCode + ". " + e.Message + "...";
            }
            catch (Exception e)
            {
                strError = "Error(2) deleting Bucket:" + this.strBucketName + ". " + e.Message + "...";
            }
        }

        // You want to create a folder in S3? No problem, we use the FileKey with the character '/' at 
        // the end to show that you want to create a folder.
        // https://www.codeproject.com/Articles/186132/Beginning-with-Amazon-S3

        public void CreateNewFile(AmazonS3Client client)
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
        }

        public void CreateNewFolder(AmazonS3Client client)
        {
            String S3_KEY = "DemoCreateFolder/";
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = this.strBucketName,
                Key = S3_KEY,
                ContentBody = ""
                //--request.FilePath = "";
            };
            client.PutObject(request);
        }

        public void CreateNewFileInFolder(AmazonS3Client client)
        {
            String S3_KEY = "DemoCreateFolder/" + "Demo Create File.txt";
            PutObjectRequest request = new PutObjectRequest();
            request.BucketName = this.strBucketName;
            request.Key = S3_KEY;
            request.ContentBody = "This is body of S3 object.";
            //--request.FilePath = "";
            client.PutObject(request);
        }

        public void CreateFolderInBucket(out string strResult)
        {
            var bucket = new PutBucketRequest { BucketName = this.strBucketName, UseClientRegion = true };
            var bucketResponse = client.PutBucket(bucket);

            String S3_KEY = "Demo Create folder/";

            if (bucketResponse.HttpStatusCode.IsSuccess())
                strResult = "Bucket Created Successfully";
            else
                strResult = "Error: Bucket Creation Failed";
        }

        public void UploadFile(string strFileName, out string strResult)
        {
            //transfareUtil.UploadDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\files",bucketName);
            //transfareUtil.Upload(AppDomain.CurrentDomain.BaseDirectory + "\\test.txt",bucketName);

            // The previous code uploaded it as private... by default. This code makes it public read
            var fileTransferRequest = new TransferUtilityUploadRequest
            {
               //FilePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + strFileName, // test.txt",
                FilePath = strFileName, 
                // StorageClass. ...
                // Key. ...
                CannedACL = S3CannedACL.PublicRead,
                BucketName = strBucketName
            };
            transferUtil.Upload(fileTransferRequest);
            strResult = "File Uploaded Successfully.";
        }

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

        public void getBucket_Objects(DataSet ds)
        {
            try
            {
                ds.Tables.Add(new DataTable("Buckets"));
                DataTable dt = new DataTable();
                ds.Tables[0].Clear();
                ds.Tables[0].Columns.Add("BucketName", typeof(string));
                ds.Tables[0].Columns.Add("CreationDate", typeof(string));

                var credentials = new BasicAWSCredentials(ConfigurationManager.AppSettings["accessId"], ConfigurationManager.AppSettings["secretKey"]);
                using (AmazonS3Client client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.USEast1))
                {
                    int iCounter = 0;
                    foreach (var bucket in client.ListBuckets().Buckets)
                    {
                        iCounter++;
                        //lststr.Add(iCounter.ToString() + ". " + bucket.BucketName + "   " + bucket.CreationDate.ToShortDateString());
                        ds.Tables[0].Rows.Add(new object[] { bucket.BucketName, bucket.CreationDate.ToShortDateString() });
                    }
                }
            }
            catch (Exception Ebt)
            {
                throw new Exception("getBuckets_Table() " + Ebt.Message + "...");
            }
        }

        public void ListingObjects(DataSet ds, out string strError)
        {
            strError = String.Empty;
            try
            {
                ds.Tables.Add(new DataTable("Objects"));
                DataTable dt = new DataTable();
                ds.Tables[0].Clear();
                ds.Tables[0].Columns.Add("Key", typeof(string));
                ds.Tables[0].Columns.Add("Size", typeof(string));

                ListObjectsV2Request request = new ListObjectsV2Request
                {
                    BucketName = strBucketName,
                    MaxKeys = 10
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
            catch (AmazonS3Exception amazonS3Exception)
            {
                strError = "Error ListingObjects(1)-" + amazonS3Exception.ErrorCode + ". " + amazonS3Exception.ToString() + "...";
            }
            catch (Exception e)
            {
                strError = "Error ListingObjects(1)-" + e.ToString() + "...";
            }
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
        public void GeneratePreSignedUrl(out string strResult, out string strError)
        {
            strResult = String.Empty;
            strError = String.Empty;
            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest
            {
                BucketName = strBucketName,
                Key = "test.txt",
                Expires = DateTime.Now.AddHours(1)
            };
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
    } // End class c_S3BucketOperations

#endregion // region_c_S3BucketOperations
}
