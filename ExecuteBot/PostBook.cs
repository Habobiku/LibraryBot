using System;
using LibraryBot.LibraryClient;
using LibraryBot.Responce;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace LibraryBot.ExecuteBot
{
    public static class PostBook
    {
        public static PostResponce postBook=new PostResponce();
        public static string text="";
        public static async Task PostAsync(Message message, ApiClient apiClient, TelegramBotClient client)
        {
            text = message.Text;

            switch (message.ReplyToMessage.Text)
            {
                case "Enter the data for book\n1)Title:":

                    postBook.Title = message.Text;        
                        await client.SendTextMessageAsync(message.Chat.Id, "2)Author:", replyMarkup: new ForceReplyMarkup { Selective = true });

                    break;
                case "2)Author:":
                    postBook.Author = message.Text;
                    await client.SendTextMessageAsync(message.Chat.Id, "3)Publisher:", replyMarkup: new ForceReplyMarkup { Selective = true });

                    break;
                case "3)Publisher:":
                    postBook.Publisher = message.Text;
                    await client.SendTextMessageAsync(message.Chat.Id, "4)Status:", replyMarkup: new ForceReplyMarkup { Selective = true });

                    break;
                case "4)Status:":
                    postBook.Status = message.Text;
                    await client.SendTextMessageAsync(message.Chat.Id, "5)Isbn:", replyMarkup: new ForceReplyMarkup { Selective = true });

                    break;
                case "5)Isbn:":
                    postBook.Isbn = message.Text;
                    await client.SendTextMessageAsync(message.Chat.Id, "6)Genre:", replyMarkup: new ForceReplyMarkup { Selective = true });

                    break;
                case "6)Genre:":
                    postBook.Genre = message.Text;
                    await client.SendTextMessageAsync(message.Chat.Id, "7)Date:", replyMarkup: new ForceReplyMarkup { Selective = true });

                    break;
                case "7)Date:":
                    postBook.Date = message.Text;
                    if (await apiClient.PostBook(postBook))
                        await client.SendTextMessageAsync(message.Chat.Id, "Successfully added");
                    else
                        await client.SendTextMessageAsync(message.Chat.Id, "Cannot be added");

                    break;
            }

        }
        
    }
}

