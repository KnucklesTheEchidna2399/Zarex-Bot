using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using System.Xml;
using Discord;

namespace Zarex_Bot
{
    class Program
    {
        public static string token;

        static void Main(string[] args)
        {
            var Reader = XmlReader.Create("Appplication.xml");
            while (Reader.Read()) {
                switch (Reader.NodeType) {
                    case XmlNodeType.Text:
                        token = Reader.Value;
                        break;
                }
            }
            Console.WriteLine(token);
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync() {
            var Client = new DiscordSocketClient();
            Client.Log += Log;
            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();
        }


        private Task Log(LogMessage msg) {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
