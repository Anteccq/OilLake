using OilLake.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MDToPPTX;
using MDToPPTX.PPTX;

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
                case FileType.Pdf:
                    break;
                case FileType.Html:
                    break;
                case FileType.PowerPoint:
                    var file = (PptxFileData) fileData;
                    await Task.Run(() => MD2PPTX.RunFromMDText(file.FileData.Content, path, new PPTXSetting()
                    {
                        SlideSize = EPPTXSlideSizeValues.Screen16x9,
                        Title = file.Title,
                        SubTitle = file.SubTitle
                    }));
                    break;
            }
        }
    }
}
