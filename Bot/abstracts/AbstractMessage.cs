using JetBrains.Annotations;

namespace Bot.abstracts
{
    public abstract class AbstractMessage
    {
        protected AbstractMessage(string content)
        {
            Content = content;
        }
        public string Content;
    }
}