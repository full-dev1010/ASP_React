using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace ForSureLife.repo.Carrier_Access
{
    public class AmAmBlobClient : IAmAmBlobClient
    {
        public IConfiguration Configuration { get; }
        public string StorageConnectionString { get { return this.Configuration.GetValue<string>("BlobSettings:ConnectionString"); } }
        public string StorageContainerName { get { return this.Configuration.GetValue<string>("BlobSettings:ContainerName"); } }
        public AmAmBlobClient(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private BlobContainerClient GetPdfContainer()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(StorageConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(StorageContainerName);
            return containerClient;
        }
        public async Task UploadApplicationFile(string localPath, string ServerFileName)
        {
            BlobContainerClient containerClient = GetPdfContainer();
            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(ServerFileName);
            // Open the file and upload its data
            using FileStream uploadFileStream = File.OpenRead(localPath);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();

        }
    }
}