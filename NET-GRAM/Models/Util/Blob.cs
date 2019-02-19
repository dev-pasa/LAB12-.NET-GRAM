using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_GRAM.Models.Util
{
    public class Blob
    {
        public IConfiguration Configuration { get; }
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            Configuration = configuration;
            CloudStorageAccount = CloudStorageAccount.Parse(Configuration["ConnectionStrings:BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        //Get Container
        /// <summary>
        /// Create connection to blob storage container in Azure Blob 
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return cbc;
        }

        //Get Blob
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            //var container = CloudBlobClient.GetContainerReference(containerName);
            //CloudBlobContainer container = await GetContainer(containerName);
            var container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);
            return blob;
        }

        public void UploadFile(CloudBlobContainer cloudBlobContainer, string fileName, string filePath)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            blobFile.UploadFromFileAsync(filePath);
        }

    }
}
