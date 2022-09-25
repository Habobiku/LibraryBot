using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace LibraryBot.TGBot.Commands
{
    public class ReserveBook:Command
    {
       

        public override string Name => "Reserve";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Enter the title of book to reserve", replyMarkup: new ForceReplyMarkup { Selective = true });

        }
        
        
    }
}

