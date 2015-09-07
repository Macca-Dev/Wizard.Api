using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Wizard.Api.Adapters
{
    public interface IStorageAdapter
    {
        void UploadText(string fileName, string valueToUpload, string containerName);
        string DownloadText(string fileName, string containerName);
    }

    public class AzureStorageAdapter : IStorageAdapter
    {
        public void UploadText(string fileName, string valueToUpload, string containerName)
        {
            var blob = GetBlockBlob(fileName, containerName);

            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(valueToUpload)))
            {
                stream.Position = 0;
                blob.UploadFromStream(stream);
            }
        }

        public string DownloadText(string fileName, string containerName)
        {
            var blob = GetBlockBlob(fileName, containerName);

            using (var stream = new MemoryStream())
            {
                if (blob.Exists())
                {
                    blob.DownloadToStream(stream);
                    stream.Position = 0;
                    using (var streamReader = new StreamReader(stream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }

            return null;
        }

        private static ICloudBlob GetBlockBlob(string fileName, string containerName)
        {
            var container = GetContainer(containerName);
            return container.GetBlockBlobReference(fileName);
        }
        private static CloudBlobContainer GetContainer(string containerName)
        {
            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(Codes.Azure.ConnectionStrings.ConnectionStringName));
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            container.CreateIfNotExists();
            return container;
        }
    }
}