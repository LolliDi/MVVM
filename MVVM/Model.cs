using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public static class Model
    {
        public static List<string> listOperations = new List<string>() { "Сложение", "Вычитание", "Умножение", "Деление" };
        public static int selectedOperation = 0;
        public static string answer;
    }
}
