using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bot.abstracts;
using JetBrains.Annotations;

namespace Bot
{
    [PublicAPI]
    public class CommandHandler
    {
        public bool CaseInsensitive;
        public Func<AbstractContext, List<string>> Prefixes;
        
        private Dictionary<List<string>, Delegate> _commands = new();

        public CommandHandler(string prefix, bool caseInsensitive = true)
        {
            CaseInsensitive = caseInsensitive;
            Prefixes = (ctx) => new List<string> { prefix };
        }

        public (string?, string?) GetPrefix(AbstractContext ctx)
        {
            foreach (var prefix in Prefixes(ctx).Where(prefix => ctx.Content.StartsWith(prefix)))
            {
                Console.WriteLine(prefix);
                return (prefix, ctx.Content.Substring(prefix.Length));
            }

            return (null, null);
        }
        
        public void RegisterCommand(List<string> aliases, Func<dynamic, dynamic[], Task<dynamic>> callback)
        {
            foreach (var commandAlias in _commands.Keys.SelectMany(commandAliases => commandAliases.Where(aliases.Contains)))
            {
                throw new Exception($"The command {commandAlias} was registered twice. Consider using cog prefixes or move one of the commands to a different name");
            }

            _commands[aliases] = callback;
        }

        public Task<object?> ProcessCommands(AbstractContext ctx)
        {
            var prefix = ctx.Prefix;
            var message = ctx.PrefixStrippedContent;
            
            if (prefix == null && ctx.Public) 
                return (Task<object?>) Task.Run(() => null);
            if (message == "")
                return (Task<object?>) Task.Run(() => null);

            foreach (var cmd in from cmd in _commands from commandAlias in cmd.Key where commandAlias == message select cmd)
            {
                return (Task<object?>) cmd.Value.DynamicInvoke();
            }
            Console.WriteLine($"command '{message}' was not found");
            return (Task<object?>) Task.Run(() => null);
        }
    }
}