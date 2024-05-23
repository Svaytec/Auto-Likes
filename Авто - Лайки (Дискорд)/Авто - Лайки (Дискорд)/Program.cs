using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Авто___Лайки__Дискорд_
{
    class Program
    {
        DiscordSocketClient client;
        private ulong userId;
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "MTI0MzIxMzE2Njk0MzY3MDI4Mg.GXZuM5.7Xhl3_M7bl8DITR-alL9lGLYNpr7Mz7tqJkGaE";
            userId = 486577953824702503;

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }

        private async Task CommandsHandler(SocketMessage message)
        {
            if (message.Author.IsBot) return;

             if (message.Author.Id == userId)
            {
                Emoji emoji = new Emoji("👽");
                await message.AddReactionAsync(emoji);
            }
        }
    }
}