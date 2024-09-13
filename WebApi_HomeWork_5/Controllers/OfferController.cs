using Microsoft.AspNetCore.Mvc;
using WebApi_HomeWork_5.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_HomeWork_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        // GET: api/<OfferController>

        private readonly IFileService _fileService;
        private readonly string _filePath = "dataFile.txt";


        public OfferController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await _fileService.ReadFileTextAsync(_filePath);
        }

        [HttpGet("Increase")]
        public async void Increase(string data)
        {
            double result = double.Parse(await _fileService.ReadFileTextAsync(_filePath)) +double.Parse( data);
            await _fileService.WriteFileTextAsync(_filePath,result.ToString());
        }

    }
}
