using Core.Interfaces;

namespace YouTube.Services
{
    public class FilesService : IFilesService
    {
        const string imageFolder = "images";
        const string videoFolder = "videos";
        private readonly IWebHostEnvironment environment;

        public FilesService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        public Task DeleteImageOrVideo(string path)
        {
            string root = environment.WebRootPath;
            string fullPath = root + path;

            if (File.Exists(fullPath))
                return Task.Run(() => File.Delete(fullPath));

            return Task.CompletedTask;
        }

        public async Task<string> EditImageOrVideo(string oldPath, IFormFile newFile, bool IsImage)
        {
            await DeleteImageOrVideo(oldPath);
            return await SaveImageOrVideo(newFile, IsImage);
        }

        public async Task<string> SaveImageOrVideo(IFormFile file, bool IsImage)
        {
            // get image destination path
            string root = environment.WebRootPath;      // wwwroot
            string name = Guid.NewGuid().ToString();    // random name
            string extension = Path.GetExtension(file.FileName); // get original extension
            string fullName = name + extension;         // full name: name.ext
            string imagePath;
            // create destination image file path
            if (IsImage)
            {
                imagePath = Path.Combine(imageFolder, fullName);
            }
            else
            {
                imagePath = Path.Combine(videoFolder, fullName);

            }
            string imageFullPath = Path.Combine(root, imagePath);

            // save image on the folder
            using (FileStream fs = new FileStream(imageFullPath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            // return image file path
            return Path.DirectorySeparatorChar + imagePath;
        }
    }
}
