using Microsoft.AspNetCore.SignalR;
using WebApi_HomeWork_5.Services.Abstract;

namespace WebApi_HomeWork_5.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IFileService _fileService;
        private readonly string _filePath = "dataFile.txt";

        public MessageHub(IFileService fileService)
        {
            _fileService = fileService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ConnectMethod","əs sələmu aleykum");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("DisConnectMethod","əs sələmu aleykum");
        }


        public async Task OnDataReadAsync()
        {
            await Clients.All.SendAsync("ReadDataMethod",await _fileService.ReadFileTextAsync(_filePath));
        }

        public async Task OnDataReadUserAsync(string userName)
        {

            var resuld = double.Parse(await _fileService.ReadFileTextAsync(_filePath));

            await _fileService.WriteFileTextAsync(_filePath, (resuld + 100).ToString());

            await Clients.All.SendAsync(
                "ReadDataUserMethod", 
                await Task.Run(async ()=> userName + " " + await _fileService.ReadFileTextAsync(_filePath)));
        }





        public async Task CountDownStarted()
        {
            await Clients.Others.SendAsync("StartCountDown");
        }

        public async Task FinishOffer(string massage)
        {
            await Clients.All.SendAsync("Finish",massage + await _fileService.ReadFileTextAsync(_filePath));

        }







    }
}
