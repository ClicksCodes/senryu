using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Bot.abstracts;
using Discord;
using JetBrains.Annotations;

namespace Bot.bridges.Discord
{
    [PublicAPI]
    public class DiscordContext : abstracts.AbstractContext
    {
        public override bool Public
        {
            get
            {
                DiscordMessage message = Message as DiscordMessage ?? throw new InvalidOperationException(); 
                return message.Channel is not IPrivateChannel;
            }
        }

        public override async Task<AbstractMessage> Send(string content)
        {
            Console.WriteLine("Trying to send to discord");
            DiscordMessage message = Message as DiscordMessage ?? throw new InvalidOperationException();
            var discordMessage = await message.Channel.SendMessageAsync(content);
            var newMessage = DiscordMessage.From(discordMessage);
            return newMessage;
        }
    }
}