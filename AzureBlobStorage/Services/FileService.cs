using Azure.Storage.Blobs;
using AzureBlobStorage.Models;
using System.IO;

namespace AzureBlobStorage.Services
{
	public class FileService : IFileService
	{
		private readonly BlobServiceClient _blobServiceClient;

        public FileService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient=blobServiceClient;
        }

        public async Task Upload(FileModel fileModel)
        {
            //create container instance
            var containerInstance = _blobServiceClient.GetBlobContainerClient("products");

            //create blob instance
            var blobInstance = containerInstance.GetBlobClient(fileModel.ImageFile.FileName);

            //file save in storage
            await blobInstance.UploadAsync(fileModel.ImageFile.OpenReadStream());

        }

        public async Task<Stream> Get(String name)
        {
			//create container instance
			var containerInstance = _blobServiceClient.GetBlobContainerClient("products");

			//create blob instance
			var blobInstance = containerInstance.GetBlobClient(name);

            var downloadContent = await blobInstance.DownloadAsync();

            return downloadContent.Value.Content;

		}

		public async Task Delete(String name)
        {
			//create container instance
			var containerInstance = _blobServiceClient.GetBlobContainerClient("products");

            //create blob instance
            var blobInstance = containerInstance.GetBlobClient(name);

            await blobInstance.DeleteAsync();


		}


	}

}
