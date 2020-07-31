using Contract;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using ServiceData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace WebRole
{
    public class Service : IQueueRequest_WebRole
    {
        public static int brojac = 0;
       // NetTcpBinding binding = new NetTcpBinding();

        //private string inputRequest = "InputRequest_WebRole";

       // CloudQueue queue = QueueHelper.GetQueueReference("ProjekatQueue");

        public void QueueMessage(string message)
        {
            try
            {             
                var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString"));
                CloudBlobClient blobStorage = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobStorage.GetContainerReference("projekatblob");

             //   CloudBlockBlob blob_provera = container.GetBlockBlobReference(string.Format("poruka_{0}_{1}", DateTime.Now.ToShortDateString(), 1));

                string uniqueBlobName = string.Format("poruka_{0}_{1}", DateTime.Now.ToShortDateString(), ++brojac);
                CloudBlockBlob blob = container.GetBlockBlobReference(uniqueBlobName);
                blob.UploadFromStream(new MemoryStream(Encoding.Default.GetBytes(message)));               
            }
            catch (WebException e)
            {
                Trace.TraceInformation(e.Message);
            }
        }
    }
}