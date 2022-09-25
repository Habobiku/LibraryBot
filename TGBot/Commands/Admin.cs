using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace LibraryBot.TGBot.Commands
{
    public class Admin : Command
    {
        public override string Name => "Admin";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            ReplyKeyboardMarkup keyBoard =
                new(new[]
                {

                    new[]
                    {
                        new KeyboardButton("Post")
                    },
                   

                });

            await client.SendTextMessageAsync(chatId, "Admin",
                parseMode: ParseMode.Markdown, replyMarkup: keyBoard);
        }
    }
}

