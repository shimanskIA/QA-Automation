using System;
using System.Collections.Generic;
using System.Text;

namespace Task13
{
    class ServiceNotificationsForTest
    {
        public static string LoginFailureText { get; set; } = "Не удалось найти аккаунт Google.";

        public static string PasswordFailureText { get; set; } = "Неверный пароль. Повторите попытку или нажмите на ссылку \"Забыли пароль?\", чтобы сбросить его.";

        public static string UnreadMessageTitle { get; set; } = "Пометить прочитанным";

        public static string ReadMessageTitle { get; set; } = "Пометить непрочитанным";
    }
}
