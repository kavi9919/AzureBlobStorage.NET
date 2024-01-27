using AzureBlobStorage.Models;
using AzureBlobStorage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureBlobStorage.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileController : ControllerBase
	{
		private readonly IFileService _fileService;

		public FileController(IFileService fileService)
		{
			_fileService = fileService;
		}

		[HttpPost]
		[Route("upload")]
		public async Task<IActionResult> Upload([FromForm] FileModel fileModel)
		{
			await _fileService.Upload(fileModel);
			return Ok(fileModel);

		}

		[HttpGet]
		[Route("get")]
		public async Task<IActionResult> Get(String name)
		{
			var imageFileStream= await _fileService.Get(name);
			string fileType ="jpeg";

			if (name.Contains("png"))
			{
				fileType = "png";
			}

			return File(imageFileStream, $"image/{fileType}");
		}

		[HttpGet]
		[Route("download")]
		public async Task<IActionResult> Download(String name)
		{
			var imageFileStream = await _fileService.Get(name);
			string fileType = "jpeg";

			if (name.Contains("png"))
			{
				fileType = "png";
			}

			return File(imageFileStream, $"image/{fileType}", $"blobfile.{fileType}");
		}


	}
}
