using System;
using System.Collections.Generic;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using OfficeOpenXml;
using System;
using System.IO;


namespace Telegram_Bot
{
    

    class Program
    {
        private static TelegramBotClient botClient;
        private static string Token { get; set; } = "6745272281:AAHaLwuZ5Ue0TvTK_7YGgFGii8K6dsLuNzk";
        private static TelegramBotClient client;



        static void Main(string[] args)
        {
            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }
        







        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            

            var msg = e.Message;
            var message = e.Message;
            

                if (msg.Text != null)
            {
                var chatId = message.Chat.Id;
                var userId = message.From.Id;
                var username = message.From.Username;
                var firstName = message.From.FirstName;
                var lastName = message.From.LastName;
                Console.WriteLine($"Новое сообщение в чате {chatId} от пользователя {userId} ({username}): {message.Text}");
                switch (msg.Text)
                {


                    case "Картинка":
                        await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "https://ideogram.ai/api/images/direct/R0BrO-cXQeyjwuNPLV4TNg.jpg",
                            replyMarkup: GetButtons());
                        break;
                    case "/sart":
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, "Добро пожаловать в бота помощника, выберите нужный пункт");
                            break;
                        }
                    case "понедельник":
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, "понедельник (ОП 2): \n 1) Разговоры о важном 10:50-11:35 \n 2) физика 204 11:55-12:30 \n 3) Индивидульный проект 202 13:00-13:45 \n 4) Физика 204 14:05-14:50 \n 5) Физика 202 15:00-15:45 \n 6) Английский язык 217 15:55-16:40 \n 7) Английский язык 217 16:50-17:35 ");
                            break;
                        }
                    case "вторник":
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, "вторник (ОП 2): \n 1) Математика 215 9:00-9:45 \n 2) Математика 215 9:55-10:40 \n 3) Физкультура 106 10:50-11:35 \n 4) Физика 204 11:55-12:40 \n 5) История 114 13:00-13:45 \n 6) История 114 14:05-14:50 \n 7) ОБЖ 114 15:00-15:45");
                            break;
                        }
                    case "среда":
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, "Среда (ОП 2): \n 1) Химия 301 9:00-9:45 \n 2) Математика 203 9:55-10:40 \n 3) Математика 203 10:50-11:35 \n 4) Химия 301 11:55-12:40 \n 5) Информатика 218 13:00-13:45 \n 6) Информатика 218 14:05-14:50");
                            break;
                        }


                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Выберите команду: ", replyMarkup: GetButtons());
                        break;
                }

            }
        }





        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Картинка"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "понедельник"}, new KeyboardButton { Text = "вторник"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "среда"}, new KeyboardButton { Text = "564ghhg"}
                    }
                }
            };
        }

        



        }
    }
