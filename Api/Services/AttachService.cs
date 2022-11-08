using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services
{
    public class AttachService
    {
        [HttpPost]
        public async Task<List<MetadataModel>> UploadFiles([FromForm] List<IFormFile> files)
        {
            var res = new List<MetadataModel>();
            foreach (var file in files)
            {
                res.Add(await UploadFile(file));
            }
            return res;
        }
        private async Task<MetadataModel> UploadFile(IFormFile file)
        {
            var tempPath = Path.GetTempPath();
            var meta = new MetadataModel
            {
                TempId = Guid.NewGuid(),
                Name = file.FileName,
                MimeType = file.ContentType,
                Size = file.Length,
            };
            var newPath = Path.Combine(tempPath, meta.TempId.ToString());
            var fileInfo = new FileInfo(newPath);
            if (fileInfo.Exists)
            {
                throw new Exception("file exists");
            }
            else
            {
                if (fileInfo.Directory == null)
                {
                    throw new Exception("temp is null");
                }
                else
                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory?.Create();
                }
                using (var stream = System.IO.File.Create(newPath))
                {
                    await file.CopyToAsync(stream);
                }
                return meta;
            }
        }
    }
}
