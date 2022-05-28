using Meowie.API.Hubs;
using Meowie.Lib.Data;
using Meowie.Lib.Services;
using Microsoft.AspNetCore.SignalR;

public class Chatter : TimedHostedService
{
    private readonly IHubContext<ChatHub> _hub;
    private ILogger<TimedHostedService> _logger;
    private CatFactsClient _catFactsClient;

    private CatFacts? _facts;

    public Chatter(ILogger<TimedHostedService> logger, IHubContext<ChatHub> hub, CatFactsClient catFactsClient) : base(logger)
    {
        _catFactsClient = catFactsClient;
        _hub = hub;
        _logger = logger;
        Interval = 15000;
    }

    protected override async Task RunJobAsync(CancellationToken stoppingToken)
    {
        if (_facts == null)
        {
            _facts = await _catFactsClient.GetFactsAsync(150, 25);
        }

        await _hub.Clients.All.SendAsync("ReceiveChat", new ChatModel()
        {
            TimeStamp = DateTime.Now,
            Image = @"https://cdn.pixabay.com/photo/2021/01/16/01/51/cat-5920953_960_720.png",
            Name = "Cat bot",
            Message = _facts.Data[Random.Shared.Next(_facts.Data.Count)].Fact
        });
    }
}