using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Domain.Entities.Options
{
    public class AzureStorageOptions
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string QueueName { get; set; }
        public string ImageContainer { get; set; }
        public string ThumbnailContainer { get; set; }
        public int ImageMaxSize { get; set; }
    }
}
