using System.Windows.Input;

namespace APP_DD
{
    public class CustomCommands
    {
        public static readonly RoutedUICommand LogIntoProgram = new("Вход в программу", "LogIntoProgram", typeof(CustomCommands));
        public static readonly RoutedUICommand RegistrationRedirect = new("Переход на страницу регистрации", "RegistrationRedirect", typeof(CustomCommands));
        public static readonly RoutedUICommand RegisterNewUser = new("Регистрация нового пользователя", "RegisterNewUser", typeof(CustomCommands));
        public static readonly RoutedUICommand LogInRedirect = new("Возврат на страницу входа", "LogInRedirect", typeof(CustomCommands));
        public static readonly RoutedUICommand ShowAllCars = new("Вывод всех предложений по аренде", "ShowAllCars", typeof(CustomCommands));
        public static readonly RoutedUICommand Paste = new("Вставка изображения", "Paste", typeof(CustomCommands));
    }
}
