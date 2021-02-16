using System;
using System.Collections.Generic;
using Bot.abstracts;
using JetBrains.Annotations;

namespace ExampleBot
{
    [UsedImplicitly]
    internal class Program
    {
        public static void Main(string[] args)
        {
            var bot = new Bot.Bot(token: Environment.GetEnvironmentVariable("DISCORD_TOKEN") ?? throw new InvalidOperationException(), "net.");
            bot.CommandHandler.RegisterCommand(new List<string> {"help"}, async ctx =>
            {
                Console.WriteLine(ctx.Content);
                return null;
            });
            bot.CommandHandler.RegisterCommand(new List<string> {"hello"}, async ctx => await ctx.Send("world")!);
            bot.Run();
        }
    }
}