using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    private static TelegramBotClient botClient;

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

        // Обработка нажатия кнопок с помощью switch
        switch (buttonText)
        {
            case "Button1":
                await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Вы нажали кнопку 1");
                break;

            case "Button2":
                await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Вы нажали кнопку 2");
                break;

            case "Button3":
                await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Вы нажали кнопку 3");
                break;

            case "Button4":
                await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Вы нажали кнопку 4");
                break;

            case "Button5":
                await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Вы нажали кнопку 5");
                break;

            case "Button6":
                await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Вы нажали кнопку 6");
                break;

            case "Button7":
                await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Вы нажали кнопку 7");
                break;

            case "Button8":
                await botClient.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Вы нажали кнопку 8");
                break;

            case "OtherButton1":
                await HandleOtherButtonPress(e.CallbackQuery.Message.Chat.Id, "Другая кнопка 1");
                break;

            case "OtherButton2":
                await HandleOtherButtonPress(e.CallbackQuery.Message.Chat.Id, "Другая кнопка 2");
                break;

            case "OtherButton3":
                await HandleOtherButtonPress(e.CallbackQuery.Message.Chat.Id, "Другая кнопка 3");
                break;

            case "OtherButton4":
                await HandleOtherButtonPress(e.CallbackQuery.Message.Chat.Id, "Другая кнопка 4");
                break;

            case "VideoButton":
                // Замените "your_video_url" на актуальную ссылку на видео
                await botClient.SendVideoAsync(e.CallbackQuery.Message.Chat.Id, "https://cdn.discordapp.com/attachments/1051084606964760577/1174784479697575946/123.mp4?ex=6568da4e&is=6556654e&hm=2bf77acae06fafd39d802607410fc9d643f5194243fc60eae92b2be3f17f71c8&");
                break;

            // Добавьте дополнительные кейсы для других кнопок

            default:
                // Обработка неизвестных кнопок
                break;
        }
    }

    private static async Task HandleOtherButtonPress(long chatId, string buttonText)
    {
        await botClient.SendTextMessageAsync(chatId, $"Вы нажали {buttonText}");
    }

    private static async void Bot_OnMessage(object sender, MessageEventArgs e)
    {
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
}