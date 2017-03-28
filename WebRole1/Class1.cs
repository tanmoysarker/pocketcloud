using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pocketCloud
{
    public class FileStorageServices
    {
        public CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse; { RoleEnvironment.GetConfigerationSettingValue("PocketFileManagerConn"); };
            CloudBlobClient blobclient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobclient.GetContainerReference("MyFiles");
            if (blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob});
            }
            return blobContainer;
        }

    } }