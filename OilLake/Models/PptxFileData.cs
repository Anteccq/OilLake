using System;
using System.Collections.Generic;
using System.Text;

namespace OilLake.Models
{
    public class PptxFileData
    {
        public FileData FileData { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public PptxFileData(FileData fileData, string title, string subTitle)
        {
            FileData = fileData;
            Title = title;
            SubTitle = subTitle;
        }
    }
}
