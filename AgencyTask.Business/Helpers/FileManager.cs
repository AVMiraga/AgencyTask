using Microsoft.AspNetCore.Http;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace AgencyTask.Business.Helpers
{
    public static class FileManager
    {
        public static bool CheckType(this IFormFile file) 
        {
            return file.ContentType.Contains("image/");
        }

        public static bool CheckSize(this IFormFile file, int size)
        {
            return file.Length / 1024 / 1024 < size;
        }

        public static async Task<string> UploadFile(this IFormFile file, string web, string path)
        {
            var ImagesPath = Path.Combine(web, path);

            if (!Directory.Exists(ImagesPath))
            {
                Directory.CreateDirectory(ImagesPath);
            }

            string fileName = Guid.NewGuid().ToString() + file.Name;

            using (var stream = new FileStream(Path.Combine(ImagesPath, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
