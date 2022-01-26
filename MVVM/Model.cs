using System.Collections.Generic;

namespace MVVM
{
    public static class Model
    {
        public static List<string> listOperations = new List<string>() { "Сложение", "Вычитание", "Умножение", "Деление" }; //данные для комбо бокса
        public static int selectedOperation = 0; //выбранный индекс
        public static string num1 = ""; //первое число
        public static string num2 = ""; //второе число
        public static string answer; //строка с ответом
    }
}
