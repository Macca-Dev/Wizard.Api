using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Wizard.Api.Adapters
{
    public interface IStorageAdapter
    {
        Task<string> DownloadTextAsync(string fileName, string containerName);
        Task UploadTextAsync(string fileName, string valueToUpload, string containerName);
    }

    public class AzureStorageAdapter : IStorageAdapter
    {
        public async Task<string> DownloadTextAsync(string fileName, string containerName)
        {
            var blob = await GetBlockBlob(fileName, containerName);
            
            using (Stream stream = new MemoryStream())
            {
                blob.DownloadToStream(stream);

                stream.Position = 0;

                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public async Task UploadTextAsync(string fileName, string valueToUpload, string containerName)
        {
            var blob = await GetBlockBlob(fileName, containerName);
            
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(valueToUpload)))
            {
                stream.Position = 0;
                await blob.UploadFromStreamAsync(stream);
            }
        }

        private static async Task<ICloudBlob> GetBlockBlob(string fileName, string containerName)
         {
             var container = await GetContainer(containerName);
             return container.GetBlockBlobReference(fileName);
         }

        private static async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(Codes.Azure.ConnectionStrings.ConnectionStringName));
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            container.CreateIfNotExists();
            return container;
        }
    }
}