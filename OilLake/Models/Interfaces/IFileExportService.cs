using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OilLake.Models.Interfaces
{
    public interface IFileExportService
    {
        Task ExportAsync(string path, object fileData, FileType fileType);
    }
}
