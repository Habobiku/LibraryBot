using System;
using LibraryBot.LibraryClient;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot;
using LibraryBot.TGBot;
using  static LibraryBot.ExecuteBot.Execute;
using static LibraryBot.ExecuteBot.PostBook;


namespace LibraryBot.Controllers
{
    [Route(@"api/message/update")]
    [ApiController]

    public class MessageController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly ILogger<MessageController> _logger;
        public MessageController(ILogger<MessageController> logger, ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }


        [HttpPost]

        public async Task<OkResult> Update([FromBody] Update update )
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = Bot.Get();

            if (message.ReplyToMessage != null)
            {
                await SendExecute(update.Message, _apiClient,client);
                //return Ok();

              await PostAsync(update.Message, _apiClient, client);
                return Ok();
                
            }

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                command.Execute(message,client);


            }
             

            return Ok();
        }
                    
    }
}

