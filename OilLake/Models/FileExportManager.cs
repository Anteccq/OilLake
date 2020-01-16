using OilLake.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using MDToPPTX;
using MDToPPTX.PPTX;
using Markdig;

namespace OilLake.Models
{
    public class FileExportManager : IFileExportService
    {

        public async Task ExportAsync(string path, object fileData, FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Pdf:
                    break;
                case FileType.Html:
                    var htmlData = (string) fileData;
                    await using (var stream = new StreamWriter(path, false, Encoding.UTF8))
                    {
                        await stream.WriteAsync(htmlData);
                    }
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
