using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Kick_Roulette.Services
{
    public class CommandHandler
    {
        public static IServiceProvider _provider;
        public static DiscordSocketClient _discord;
        public static CommandService _services;
        public static IConfigurationRoot _config;

        public CommandHandler(IServiceProvider provider, DiscordSocketClient discord, CommandService services, IConfigurationRoot config)
        {
            _provider = provider;
            _discord = discord;
            _services = services;
            _config = config;

            _discord.Ready += onReady;
            _discord.MessageReceived += onMessage;
            
        }

        private async Task onMessage(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            if (msg == null) return;
            if (msg.Author.IsBot)
            {
                return;
            }

            var Context = new SocketCommandContext(_discord, msg);

            int pos = 0;
            if (msg.HasStringPrefix(_config["prefix"], ref pos))
            {
                var resault = await _services.ExecuteAsync(Context, pos, _provider);

                if (!resault.IsSuccess)
                {
                    Console.WriteLine(resault.Error);
                    Console.WriteLine(resault.ErrorReason);
                }
            }
        }

        private Task onReady()
        {
            Console.WriteLine($"bot {_discord.CurrentUser.Username}#{_discord.CurrentUser.Discriminator} is ready");
            return Task.CompletedTask;
        }
    }
}
