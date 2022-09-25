using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBot.LibraryClient;
using LibraryBot.Models;
using LibraryBot.TGBot;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace LibraryBot.Controllers
{
    [Route(@"start")]
    [ApiController]

    public class Start : Controller
    {
        private readonly ILogger<MessageController> _logger;
        public Start(ILogger<MessageController> logger)
        {
            _logger = logger;
          
        }


        [HttpGet]

        public async Task<IActionResult> StartBot()
        {
            var client = Bot.Get();
            await client.SetWebhookAsync(Config.Hook);

            return Ok("Bot have been started Successfully");
        }

    }
}
