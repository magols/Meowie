using Meowie.Lib.Data;
using Microsoft.AspNetCore.SignalR;

namespace Meowie.API.Hubs;

public class SensorHub : Hub
{
    public async Task ReceiveSensorData(SensorData data)
    {
        Console.WriteLine(data.ToString());
        await Clients.All.SendAsync("SensorData", data);
    }
}
