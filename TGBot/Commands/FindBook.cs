using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LibraryBot.TGBot.Commands
{
    public class FindBook:Command
    {
    
        public override string Name => "Find";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Enter the key for find", replyMarkup: new ForceReplyMarkup { Selective = true });
        }
    }
}

