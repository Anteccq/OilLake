using OilLake.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OilLake.Models
{
    public class FileExportManager : IFileExportService
    {
        public async Task ExportAsync(string path, object fileData, FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Image:
                    break;
                case FileType.PDF:
                    break;
                case FileType.PowerPoint:
                    break;
            }
        }
    }
}
