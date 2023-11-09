using Microsoft.AspNetCore.Http;

namespace BeautyScheduler.Service.DTOs.FileUpload
{
    public class FileUploadCreationDto
    {
        public string FolderPath { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
