namespace WebApi_HomeWork_5.Services.Abstract
{
    public interface IFileService
    {
        Task<string> ReadFileTextAsync(string path);
        Task WriteFileTextAsync(string path, string data);
    }
}
