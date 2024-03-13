using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Contracts.Infrastructure.Helper
{
    public interface IImageHelper
    {
        public string GetImageUrl(IFormFile imageFile, string subFolder, string id);
        public Task<string?> UploadImage(IFormFile? imageFile, string subFolder, string id);
        public Task DeleteImage(string imageUrl);
        public Task<string?> UpdateImage(string? oldimageUrl, IFormFile? imageFile, string subFolder, string id);
    }
}
