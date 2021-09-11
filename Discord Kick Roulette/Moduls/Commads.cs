using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord_Kick_Roulette.Moduls
{
    public class Commads : ModuleBase
    {
        [Command("Test")]
        public async Task Test()
        {
            await ReplyAsync("it works");
        }

        [Command("Info")]
        public async Task Info(SocketGuildUser usr = null)
        {
            if (usr == null)
            {
                var embedBuilder = new EmbedBuilder()
                    .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                    .WithDescription("some info this message gonna show :")
                    .AddField("Username : ", Context.User.Username)
                    .AddField("user id is :", Context.User.Id)
                    .AddField("account creation date : ", Context.User.CreatedAt.ToString("dd/MM/yyyy"))
                    .AddField("channel name :", Context.Channel.Name)
                    ;
                var msg = embedBuilder.Build();
                await Context.Channel.SendMessageAsync(null, false, msg);
            }
            else
            {
                var embedBuilder = new EmbedBuilder()
                    .WithThumbnailUrl(usr.GetAvatarUrl() ?? usr.GetDefaultAvatarUrl())
                    .WithDescription("some info this message gonna show :")
                    .AddField("Username : ", usr.Username)
                    .AddField("user id is :", usr.Id)
                    .AddField("account creation date : ", usr.CreatedAt.ToString("dd/MM/yyyy"))
                    .AddField("channel name :", Context.Channel.Name)
                    ;
                var msg = embedBuilder.Build();
                await Context.Channel.SendMessageAsync(null, false, msg);
            }
        }
        [Command("Gamble")]
        public async Task Gamble()
        {
           
            Random rnd = new Random();
            int a = rnd.Next(1, 7);
            string msg =$"You get SHOT!!!";
            if (a == 1)
            {
                await Context.Channel.SendMessageAsync(msg);
                await Task.Delay(3000);
                await Context.Guild.AddBanAsync(Context.User,0,null);
                
            }
            else
            {
                await Context.Channel.SendMessageAsync("you lived");
            }
        }

    }
}
