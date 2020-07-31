using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceData
{
    public class BlobHelper
    {
        public static CloudBlobContainer container;

       /* public BlobHelper()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("ProjekatBlob");
            container.CreateIfNotExists();

            BlobContainerPermissions permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);
        }

        public static void InitBlobs()
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                container = blobClient.GetContainerReference("ProjekatBlob");
                container.CreateIfNotExists();

                BlobContainerPermissions permissions = container.GetPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(permissions);
            }
            catch (WebException e)
            {
                Trace.TraceError($"ERROR: {e.Message}");
            }
        }*/

        public CloudBlockBlob UploadToBlob(string uniqueBlobName, string content)
        {
            CloudBlockBlob blockBlob = null;

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("projekatblob");
            container.CreateIfNotExists();

            BlobContainerPermissions permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);

            using (MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(content)))
            {

               blockBlob = container.GetBlockBlobReference(uniqueBlobName);

                if (!blockBlob.Exists())
                    return null;

               blockBlob.UploadFromStream(stream);              

            }

            return blockBlob;
        }

        public string DownloadFromBlob(string uniqueBlobName)
        {
            string content = "";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("projekatblob");
            container.CreateIfNotExists();

            BlobContainerPermissions permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);

            using (MemoryStream stream = new MemoryStream())
            {

                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(uniqueBlobName);

                    if (!blockBlob.Exists())
                        return null;

                    blockBlob.DownloadToStream(stream);
                    content = Encoding.Default.GetString(stream.ToArray());

            }

            return content;
        }
    }
}
