using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LibraryBot.TGBot.Commands
{
    public class BorrowBook : Command
    {
        public override string Name => "Borrow";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Enter the title of book to borrow", replyMarkup: new ForceReplyMarkup { Selective = true });

        }
    }
}

