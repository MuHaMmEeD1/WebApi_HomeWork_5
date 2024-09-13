using WebApi_HomeWork_5.Services.Abstract;

namespace WebApi_HomeWork_5.Services.Cocrete
{
    public class FileService : IFileService
    {
     

        public async Task<string> ReadFileTextAsync(string path)
        {
            return await Task.Run(() => File.ReadAllText(path));
        }

        public async Task WriteFileTextAsync(string path, string data)
        {
            await Task.Run(() => File.WriteAllText(path, data));
        }
    }
}
