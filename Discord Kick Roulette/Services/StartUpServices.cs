using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using System.Threading.Tasks;
using System.Reflection;

namespace Discord_Kick_Roulette.Services
{
    public class StartUpServices
    {
        public static IServiceProvider _provider;
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _services;
        private readonly IConfigurationRoot _config;

        public StartUpServices(IServiceProvider provider, DiscordSocketClient discord , CommandService services,IConfigurationRoot config)
        {
            _provider = provider;
            _discord = discord;
            _services = services;
            _config = config;
        }

        public async Task StartAsync()
        {
            string token = _config["token:discord"];
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("Pls Provide Discord Token");
                return;
            }

            await _discord.LoginAsync(TokenType.Bot, token);
            await _discord.StartAsync();

            await _services.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
        }
    }
}
