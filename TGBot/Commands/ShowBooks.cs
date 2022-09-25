using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Linq;
using LibraryBot.LibraryClient;

namespace LibraryBot.TGBot.Commands
{
    public class ShowBooks : Command
    {
        public override string Name => "Show all books";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            var text = await apiClient.GetBooks();



            foreach (var books in text.ListBooks) {
                string book = $"Title: {books.Title}\nPublisher: {books.Publisher}\nGenre: {books.Genre}\nAuthor: {books.Author}\nStatus {books.Status}";
            await client.SendTextMessageAsync(chatId, book);
            }

        }
    }
}

