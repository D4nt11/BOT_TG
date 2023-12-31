﻿using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
namespace Telegram
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("6745272281:AAHaLwuZ5Ue0TvTK_7YGgFGii8K6dsLuNzk");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Привет, я бот, который показывает рассписание, напиши день недели, например понедельник");
                    return;
                }
            }
            var message1 = update.Message;
            switch (message1.Text.ToLower())
            {
                case "понедельник":
                    {
                        await botClient.SendTextMessageAsync(message1.Chat, "Понедельник (ОП 2): \n 1) Разговоры о важном 10:50-11:35 \n 2) физика 204 11:55-12:30 \n 3) Индивидульный проект 202 13:00-13:45 \n 4) Физика 204 14:05-14:50 \n 5) Физика 202 15:00-15:45 \n 6) Английский язык 217 15:55-16:40 \n 7) Английский язык 217 16:50-17:35 ");
                    }
                    break;
                    
                case "вторник": 
                    {
                        await botClient.SendTextMessageAsync(message1.Chat, "Вторник (ОП 2): \n 1) Математика 9:00-9:45 2) Математика 9:55-10:40 3) Физкультура  106-10:50 11:35 4) Физика 204 11:55-12:40 5) История 114 13:00-13:45 6) История 114 14:05-14:50 7) ОБЖ 114 15:00-15:45");
                    }
                    break;
                case "среда":
                    {
                        await botClient.SendTextMessageAsync(message1.Chat, "Среда (ОП 2)");
                        

                    }
                    break;
            }



        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }

}

