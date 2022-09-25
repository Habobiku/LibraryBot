using System;
using LibraryBot.TGBot.Commands;
using LibraryBot.Models;
using Telegram.Bot;

namespace LibraryBot.TGBot
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static TelegramBotClient Get()
        {

            if (client != null)
            {
                return client;
            }
            commandsList = new List<Command>()
            {
                new HelpCommand(),
                new ShowBooks(),
                new ReturnBook(),
                new ReserveBook(),
                new BorrowBook(),
                new PostBook(),
                new Admin(),
                new FindBook(),
                
            };

            client = new TelegramBotClient(Config.TokenTG);

            return client;
        }
    }
}

