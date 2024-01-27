using AzureBlobStorage.Models;

namespace AzureBlobStorage.Services
{
	public interface IFileService
	{
		Task Upload(FileModel fileModel);
		Task<Stream> Get(String name);
	}
}
