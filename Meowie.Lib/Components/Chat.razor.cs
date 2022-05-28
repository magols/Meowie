using Meowie.Lib.Data;
using Meowie.Lib.Services;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace Meowie.Lib.Components
{
    public partial class Chat
    {
        private ChatModel _chatModel = new ChatModel() { Image = PlaceKittenImage.GetRandomUrl(200, 50) };

        private HubConnection? hubConnection;
        private List<ChatModel> messages = new();

        private bool FilterBot;

        private bool PassedFilter(ChatModel chatModel)
        {
            if (FilterBot && chatModel.Name == "Cat bot")
            {
                return false;
            }

            return true;
        }

        protected override async Task OnInitializedAsync()
        {
            string host;

            hubConnection = new HubConnectionBuilder()
                .WithUrl(BackeEndUrlProvider.GetBackEndUrl() + "/chathub")
                .ConfigureLogging(builder => { })
                .Build();

            hubConnection.Reconnecting += OnReconnecting;
            hubConnection.Reconnected += OnReconnected;

            hubConnection.On<ChatModel>("ReceiveChat", (chatMessage) =>
            {
                var encodedMsg = $"{chatMessage.Name}: {chatMessage.Message} : {chatMessage.Image}";
                messages.Add(chatMessage);
                StateHasChanged();
            });


            await hubConnection.StartAsync();
            NotificationService.Notify(summary: "Connected");
        }

        private Task OnReconnected(string? arg)
        {
            NotificationService.Notify(summary: "Reconnected");
            return Task.CompletedTask;
        }

        private Task OnReconnecting(Exception? arg)
        {
            NotificationService.Notify(summary: "Reconnecting");
            return Task.CompletedTask;
        }
 
        private async Task SendChat()
        {
            if (hubConnection is not null)
            {
                await hubConnection.SendAsync("SendChat", _chatModel);
            }
        }

        public bool IsConnected =>
            hubConnection?.State == HubConnectionState.Connected;

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }

        private async Task HandleValidSubmit()
        {
            Logger.LogInformation("HandleValidSubmit called");
            await SendChat();
            _chatModel.Message = "";
        }

        private void ChangeImage()
        {
            _chatModel.Image = PlaceKittenImage.GetRandomUrl(250, 60);
        }
    }
}
