using System;
using System.Linq;
using LibraryBot.LibraryClient;
using LibraryBot.Models;
using LibraryBot.Responce;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LibraryBot.ExecuteBot
{
    public static class Execute
    {
        public static PostResponce postBook;

        public static string id = "";
        public static string name = "";
        public static string text = "";
        public static string book1="";
        public static async Task SendExecute(Message message, ApiClient apiClient, TelegramBotClient client)
        {
           
            text = message.Text;
            text = text[0].ToString().ToUpper() + text.Substring(1);
           
            switch (message.ReplyToMessage.Text)
            {

                case "Enter the title of book to reserve":
                    if (await apiClient.ReserveBook(text))
                        await client.SendTextMessageAsync(message.Chat.Id, "Successfully reserved");
                    else
                        await client.SendTextMessageAsync(message.Chat.Id, "Cannot be reserved");

                    break;
                case "Enter the title of book to return":
                    if (await apiClient.ReturnBook(text))
                        await client.SendTextMessageAsync(message.Chat.Id, "Successfully returned");
                    else
                        await client.SendTextMessageAsync(message.Chat.Id, "Cannot be returned");
    
                    break;

                case "Enter the title of book to borrow":
                    if (await apiClient.BorrowBook(text))
                        await client.SendTextMessageAsync(message.Chat.Id, "Successfully borrowed");
                    else
                        await client.SendTextMessageAsync(message.Chat.Id, "Cannot be borrowed");

                    break;
                case "Enter the key for find":
                    id = message.Text;
                    id = id[0].ToString().ToUpper() + id.Substring(1);
                    await client.SendTextMessageAsync(message.Chat.Id, "Enter the name", replyMarkup: new ForceReplyMarkup { Selective = true });
      
                    break;
                case "Enter the name":
                    name = message.Text;
                    name = name[0].ToString().ToUpper() + name.Substring(1);
                    var book = await apiClient.GetBook(id, name);

                    if (book != null)
                    {
                        book1 = $"Title: {book.Title}\nPublisher: {book.Publisher}\nGenre: {book.Genre}\nAuthor: {book.Author}\nStatus {book.Status}";
                        await client.SendTextMessageAsync(message.Chat.Id, book1);

                    }
                    else
                        await client.SendTextMessageAsync(message.Chat.Id, "Cannot be found");

                    break;


              
            }
        }
    }
}

