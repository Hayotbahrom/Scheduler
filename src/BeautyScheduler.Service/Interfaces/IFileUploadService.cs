using BeautyScheduler.Service.DTOs.FileUpload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Interfaces;

public interface IFileUploadService
{
     Task<FileUploadResultDto> FileUploadAsync(FileUploadCreationDto dto);
     Task<bool> FileDeleteAsync(string filePath);
}
