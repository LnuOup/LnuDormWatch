using LDW.Domain.Common;
using LDW.Domain.Entities.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LDW.Application.Interfaces.Services
{
    public interface IImageService
    {
        Task<OperationResult<string>> UploadFileToStorage(Stream fileStream, string fileName, AzureStorageOptions storageConfig, bool isCompressed);
    }
}
