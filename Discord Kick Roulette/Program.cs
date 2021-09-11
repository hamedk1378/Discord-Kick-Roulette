using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Discord_Kick_Roulette
{
    class Program
    {
      public static async Task Main(string[] args) => await StartUp.RunAsync(args);
    }
}
