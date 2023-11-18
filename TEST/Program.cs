using System;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{


    private static TelegramBotClient botClient;

    private static async Task SendTextMessage(long chatId, string text)
    {
        await botClient.SendTextMessageAsync(chatId, text);
    }


    static async Task Main()
    {
        // Замените "your_bot_token" на актуальный токен вашего бота
        botClient = new TelegramBotClient("6745272281:AAHaLwuZ5Ue0TvTK_7YGgFGii8K6dsLuNzk");

        var me = await botClient.GetMeAsync();
        Console.WriteLine($"Bot ID: {me.Id}, Bot Username: {me.Username}");

        botClient.OnCallbackQuery += Bot_OnCallbackQuery;
        botClient.OnMessage += Bot_OnMessage;
        botClient.StartReceiving();

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();

        botClient.StopReceiving();
    }


    private static async void Bot_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
    {
        string buttonText = e.CallbackQuery.Data;
        long? chatId = e.CallbackQuery.Message?.Chat?.Id;

        if (chatId.HasValue)
        {
            switch (buttonText)
            {
                case "VideoButton":
                    await SendVideo(chatId.Value);
                    break;

                case "Button1":
                    await SendTextMessage(chatId.Value, "Вы выбрали Кнопку 1");
                    break;

                case "Button2":
                    await SendTextMessage(chatId.Value, "Вы выбрали Кнопку 2");
                    break;

                case "Button3":
                    await SendTextMessage(chatId.Value, "Вы выбрали Кнопку 3");
                    break;

                case "Button4":
                    await SendTextMessage(chatId.Value, "Вы выбрали Кнопку 4");
                    break;

                case "Button5":
                    await SendTextMessage(chatId.Value, "Вы выбрали Кнопку 5");
                    break;

                case "Button6":
                    await SendTextMessage(chatId.Value, "Вы выбрали Кнопку 6");
                    break;

                case "Button7":
                    await SendTextMessage(chatId.Value, "Вы выбрали Кнопку 7");
                    break;

                case "Button8":
                    await SendTextMessage(chatId.Value, "Вы выбрали Кнопку 8");
                    break;

                case "OtherButton1":
                    await SendTextMessage(chatId.Value, "Вы выбрали Другую кнопку 1");
                    break;

                case "OtherButton2":
                    await SendTextMessage(chatId.Value, "Вы выбрали Другую кнопку 2");
                    break;

                case "OtherButton3":
                    await SendTextMessage(chatId.Value, "Вы выбрали Другую кнопку 3");
                    break;

                case "OtherButton4":
                    await SendTextMessage(chatId.Value, "Вы выбрали Другую кнопку 4");
                    break;

                default:
                    await HandleOtherButtonPress(chatId.Value, buttonText);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Ошибка: Не удалось определить chatId");
        }
    }




    private static async Task HandleOtherButtonPress(long chatId, string buttonText)
    {
        await botClient.SendTextMessageAsync(chatId, $"Вы нажали {buttonText}");
    }

    private static async void Bot_OnMessage(object sender, MessageEventArgs e)
    {
        Console.WriteLine($"Received message from user {e.Message.From.Id} ({e.Message.From.Username}) in chat {e.Message.Chat.Id}: {e.Message.Text}");
        if (e.Message.Text == "/start")
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Кнопка 1", "Button1"),
                    InlineKeyboardButton.WithCallbackData("Кнопка 2", "Button2")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Кнопка 3", "Button3"),
                    InlineKeyboardButton.WithCallbackData("Кнопка 4", "Button4")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Кнопка 5", "Button5"),
                    InlineKeyboardButton.WithCallbackData("Кнопка 6", "Button6")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Кнопка 7", "Button7"),
                    InlineKeyboardButton.WithCallbackData("Кнопка 8", "Button8")
                }
            });

            var videoButton = InlineKeyboardButton.WithCallbackData("Видео", "VideoButton");

            var otherInlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Другая кнопка 1", "OtherButton1"),
                    InlineKeyboardButton.WithCallbackData("Другая кнопка 2", "OtherButton2")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Другая кнопка 3", "OtherButton3"),
                    InlineKeyboardButton.WithCallbackData("Другая кнопка 4", "OtherButton4")
                },
                new[]
                {
                    videoButton
                }
            });

            await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat.Id,
                text: "Привет! Выберите действие:",
                replyMarkup: inlineKeyboard
            );

            await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat.Id,
                text: "Другая команда! Выберите действие:",
                replyMarkup: otherInlineKeyboard
            );
        }
        // Добавьте обработку других команд, если необходимо
    }




    private static async Task SendVideo(long chatId)
    {
        try
        {
            var videoPath = "C:\\Users\\artem\\Downloads\\3333444.mp4"; // Укажите полный путь к вашему видеофайлу

            using (var videoStream = new FileStream(videoPath, FileMode.Open))
            {
                await botClient.SendVideoAsync(chatId, new InputOnlineFile(videoStream), caption: "Описание видео");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при отправке видео: {ex.Message}");
        }
    }

}