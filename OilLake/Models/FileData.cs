using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace OilLake.Models
{
    public class FileData : BindableBase
    {
        private string _path;

        public string Path
        {
            get => _path;
            set => SetProperty(ref _path, value);
        }

        private string _content;

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public FileData(string path, string content)
        {
            Path = path;
            Content = content;
        }

        public static FileData DefaultData => new FileData(null, "");
    }
}
