namespace SignalR_Example.Hub;

public class MessageHub : Microsoft.AspNetCore.SignalR.Hub
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Message sending: " + message);
        Thread.Sleep(500);
        this.Clients.All.SendCoreAsync("onMessage", new object?[]{"This message from server"});
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine(this.Context.ConnectionId);
        await base.OnConnectedAsync();
    }
}