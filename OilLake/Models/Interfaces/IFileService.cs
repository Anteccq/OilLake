using System.Threading.Tasks;

namespace OilLake.Models.Interfaces
{
    public interface IFileService
    {
        Task SaveDataAsync(FileData fileData);

        Task<FileData> LoadDataAsync(string path);
    }
}
