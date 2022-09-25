using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LibraryBot.TGBot.Commands
{
    public class PostBook:Command
    {
        

        public override string Name => "Post";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Enter the data for book\n1)Title:", replyMarkup: new ForceReplyMarkup { Selective = true });
        }
    }
}

