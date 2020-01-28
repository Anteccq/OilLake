using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OilLake.Models.Interfaces;

namespace OilLake.Models
{
    public class FileManager : IFileService
    {
        public async Task SaveDataAsync(FileData fileData)
        {
            await using var stream = new StreamWriter(fileData.Path, false, Encoding.UTF8);
            await stream.WriteAsync(fileData.Content);
        }

        public async Task<FileData> LoadDataAsync(string path)
        {
            using var stream = new StreamReader(path);
            return new FileData(path, await stream.ReadToEndAsync());
        }
    }
}
