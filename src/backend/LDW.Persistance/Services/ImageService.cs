using LDW.Application.Interfaces.Services;
using LDW.Domain.Common;
using LDW.Domain.Entities.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LDW.Persistence.Services
{
    public class ImageService : ServiceBase, IImageService
    {
        public async Task<OperationResult<string>> UploadFileToStorage(Stream fileStream, string fileName, AzureStorageOptions storageConfig, bool isCompressed)
        {
            var blobClient = GetBlobClient(storageConfig);
            var container = blobClient.GetContainerReference(isCompressed ? storageConfig.ThumbnailContainer : storageConfig.ImageContainer);
            var blockBlob = container.GetBlockBlobReference(fileName);
            try
            {
                await blockBlob.UploadFromStreamAsync(fileStream);
            }
            catch (Exception ex)
            {
                return new OperationResult<string>(ex);
            }

            return new OperationResult<string>(blockBlob.Uri.ToString());
        }

        private CloudBlobClient GetBlobClient(AzureStorageOptions _storageConfig)
        {
            var storageCredentials = new StorageCredentials(_storageConfig.AccountName, _storageConfig.AccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            return storageAccount.CreateCloudBlobClient();
        }
    }
}
