using BeautyScheduler.Service.DTOs.FileUpload;
using BeautyScheduler.Service.Helpers;
using BeautyScheduler.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Services
{
    public class FileUploadService : IFileUploadService
    {
        public async Task<bool> FileDeleteAsync(string filePath)
        {
            var result = Path.Combine(WebEnvironmentHost.WebRootPath, filePath);
            if (File.Exists(result))
            {
                File.Delete(result);
                return true;
            }
            return false;
        }
        public async Task<FileUploadResultDto> FileUploadAsync(FileUploadCreationDto dto)
        {
            var wwwRootPath = Path.Combine(WebEnvironmentHost.WebRootPath, "Assets", dto.FolderPath);
            var assetsFolderPath = Path.Combine(WebEnvironmentHost.WebRootPath, "Assets");
            var assetPath = Path.Combine(assetsFolderPath, dto.FolderPath);

            if (!Directory.Exists(assetsFolderPath))
            {
                Directory.CreateDirectory(assetsFolderPath);
            }
            if (!Directory.Exists(assetPath))
            {
                Directory.CreateDirectory(assetPath);
            }

            var FileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.FormFile.FileName);
            var FullPath = Path.Combine(wwwRootPath, FileName);
            using (var streamFile = File.OpenWrite(FullPath))
            {
                await dto.FormFile.CopyToAsync(streamFile);
            };

            var result = new FileUploadResultDto()
            {
                AssetPath = Path.Combine("Assets", dto.FolderPath, FileName),
            };
            return result;

        }
    }
}
