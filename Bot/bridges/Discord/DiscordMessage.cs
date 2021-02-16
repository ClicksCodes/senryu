using System;
using Discord;
using JetBrains.Annotations;

namespace Bot.bridges.Discord
{
    [PublicAPI]
    public class DiscordMessage: abstracts.AbstractMessage
    {
        private DiscordMessage(IMessageChannel channel, string content) : base(content)
        {
            Channel = channel;
        }
        public static DiscordMessage From(IMessage discordMessage)
        {
            var message = new DiscordMessage(discordMessage.Channel, discordMessage.Content);
            return message;
        }
        public IMessageChannel Channel;
    }
}