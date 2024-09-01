using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFilesService
    {
        Task<string> SaveImageOrVideo(IFormFile file, bool IsImage);
        Task DeleteImageOrVideo(string path);
        Task<string> EditImageOrVideo(string oldPath, IFormFile newFile, bool IsImage);
    }
}
