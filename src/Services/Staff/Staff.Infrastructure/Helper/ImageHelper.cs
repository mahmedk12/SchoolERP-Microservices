using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Staff.Application.Contracts.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Helper
{
    public class ImageHelper : IImageHelper
    {
        private readonly IHostEnvironment _environment;
        private string rootFolder;

        public ImageHelper(IHostEnvironment environment)
        {
            _environment = environment;
            rootFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "Images");
        }

        public async Task DeleteImage(string imageUrl)
        {
            var imagePath = rootFolder + imageUrl.Replace("/", "\\");
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        public async Task<string> UploadImage(IFormFile imageFile, string subFolder, string id)
        {
            var uploadFolder = Path.Join(rootFolder, subFolder);
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var uniqueFileName = id + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return $"/{subFolder}/{uniqueFileName}";
        }

        public async Task<string?> UpdateImage(string? oldimageUrl, IFormFile? imageFile, string subFolder, string id)
        {
            if (imageFile != null)
            {
                if(oldimageUrl != null)
                {
                    await DeleteImage(oldimageUrl);
                    return await UploadImage(imageFile,subFolder,id);              
                }
                else
                {
                    return await UploadImage(imageFile, subFolder, id);
                }              
            }
            return oldimageUrl;
        }
        public string GetImageUrl(IFormFile imageFile, string subFolder, string id)
        {
            var uploadfolder = Path.Join(rootFolder, subFolder);
            var uniqueFileName = id + "_" + imageFile.FileName;
            return $"/{subFolder}/{uniqueFileName}";
        }
    }
}
