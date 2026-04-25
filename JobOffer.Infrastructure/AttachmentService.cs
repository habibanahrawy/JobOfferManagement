
using Microsoft.Extensions.Hosting;


namespace JobOffer.Infrastructure
{
    public class AttachmentService : IAttachmentService
    {
        private readonly string[] allowedExtensions = { ".pdf", ".doc", ".docx" };
        private readonly long maxFileSize = 2 * 1024 * 1024;
        private readonly IHostEnvironment _webHost;

        public AttachmentService(IHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        public string? Upload(string folderName, IFormFile file)
        { 

            try
            {
                if (folderName is null || file is null || file.Length == 0) return null;

                if (file.Length > maxFileSize) return null;

                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(extension)) return null;

                var folderPath = Path.Combine(_webHost.ContentRootPath, folderName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = Guid.NewGuid().ToString() + extension;

                var filePath = Path.Combine(folderPath, fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);

                return fileName;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed To Upload File To Folder {folderName} : {ex}");
                return null;
            }

        }
        public bool Delete(string folderName, string fileName)
        {

            try
            {
                if(string.IsNullOrEmpty(folderName) || string.IsNullOrEmpty(fileName)) return false;

                var fullPath = Path.Combine(_webHost.ContentRootPath , folderName , fileName);
                if(File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed To Delete File {fileName} : {ex}");
                return false;
            }

        }
    }
}

