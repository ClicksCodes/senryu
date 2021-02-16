using System;
using System.Threading.Tasks;
using Bot.bridges.Discord;
using Discord;
using Discord.WebSocket;
using JetBrains.Annotations;

namespace Bot
{
    [PublicAPI]
    public class Bot
    {
        private readonly string _token;
        private readonly DiscordSocketClient _socketClient;
        public readonly CommandHandler CommandHandler;
        private bool _logoutRequested;
        public Bot(string token, string prefix, bool caseInsensitive = true)
        {
            this._token = token;
            CommandHandler = new CommandHandler(prefix, caseInsensitive);
            _socketClient = new DiscordSocketClient();
            _socketClient.MessageReceived += MessageReceivedAsync;
            _socketClient.Ready += ReadyAsync;
        }
        public void Run()
        {
            _logoutRequested = false;
            var task = Task.Run(async () => { await RunAsync(); });
            task.Wait();
        }
        public async Task RunAsync()
        {
            await _socketClient.LoginAsync(TokenType.Bot, _token);
            await _socketClient.StartAsync(); 
            await Wait();
        }

        private async Task Wait()
        {
            while (!_logoutRequested)
            {
                await Task.Delay(0);
            }
        }
        public bool Logout()
        {
            Boolean previous = _logoutRequested;
            _logoutRequested = true;
            return !previous;
        }
        private Task ReadyAsync()
        {
            Console.WriteLine($"{_socketClient.CurrentUser} is connected!");
            return Task.CompletedTask;
        }
        private async Task MessageReceivedAsync(SocketMessage message)
        {
            // The bot should never respond to itself.
            if (message.Author.Id == _socketClient.CurrentUser.Id) 
                return;

            Console.WriteLine($"Processing commands for {message.Content}");
            var m = DiscordMessage.From(message);
            var context = new DiscordContext() {Message = m, Bot = this};
            await CommandHandler.ProcessCommands(context);
            Console.WriteLine($"Processing completed for message {message}");
        }
    }
}