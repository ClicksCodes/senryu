using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Bot.abstracts
{
    [PublicAPI]
    public abstract class AbstractContext
    {
        public string? Content => Message?.Content;
        public virtual bool Public { get; }

        private string _prefix = "net.";
        public string? Prefix => Bot.CommandHandler.GetPrefix(this).Item1;
        public string? PrefixStrippedContent => Bot.CommandHandler.GetPrefix(this).Item2 ?? Content;

        public AbstractMessage? Message;
        public Bot? Bot;
        public virtual Task<AbstractMessage>? Send(string content)
        {
            Console.WriteLine(content);
            return null;
        }
    }
}