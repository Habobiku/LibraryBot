using System;
using LibraryBot.LibraryClient;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LibraryBot.TGBot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public ApiClient apiClient = new ApiClient();
        public abstract void Execute(Message message, TelegramBotClient client);
        public bool Contains(string? command)
        {
            return command.Contains(this.Name);
        }
    }
}

