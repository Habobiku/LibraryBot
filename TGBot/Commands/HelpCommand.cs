using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace LibraryBot.TGBot.Commands
{
    public class HelpCommand : Command
    {
        public override string Name => "/Help";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            ReplyKeyboardMarkup keyBoard =
                new(new[]
                {

                    new[]
                    {
                        new KeyboardButton("Admin")
                    },
                    new[]
                    {
                        new KeyboardButton("Reserve")
                    },
                    new []
                    {
                        new KeyboardButton("Show all books")
                    },
                    new []
                    {
                        new KeyboardButton("Return")
                    },
                    new []
                    {
                        new KeyboardButton("Borrow")
                    },
                    new []
                    {
                        new KeyboardButton("Find")
                    },

                });
            
            await client.SendTextMessageAsync(chatId, "\U0001F4D6 Help",
                parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}

