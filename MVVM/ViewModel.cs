using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MVVM
{
    public class ViewModel : INotifyPropertyChanged
    {

        public List<string> CBData
        {
            get => Model.listOperations;
        }
        public int SelectIndexCB
        {
            set
            {
                Model.selectedOperation = value;
                onPropChan("SelectedOperation");
            }
        }
        public string SelectedOperation
        {
            get
            {
                switch (Model.selectedOperation)
                {
                    case 0:
                        return "+";
                    case 1:
                        return "-";
                    case 2:
                        return "х";
                    default:
                        return "/";
                }
            }
        }

        public string Answer
        {
            get => Model.answer;
            set
            {
                Model.answer = value;
                onPropChan("Answer");
            }
        }
        public string TB1
        {
            get => Model.num1;
            set => Model.num1 = value;
        }

        public string TB2
        {
            get => Model.num2;
            set => Model.num2 = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropChan([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public RoutedCommand BtnCommand { get; set; } = new RoutedCommand();
        public CommandBinding CBinding1;
        public void CommandAnswer(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                double firstNum = Convert.ToDouble(Model.num1);
                double secondNum = Convert.ToDouble(Model.num2);
                if (Double.IsNaN(firstNum) || Double.IsNaN(secondNum))
                {
                    throw new Exception("Введите цифры для выполнения операций!");
                }
                switch (Model.selectedOperation)
                {
                    case 0:
                        Answer = "" + (firstNum + secondNum);
                        break;
                    case 1:
                        Answer = "" + (firstNum - secondNum);
                        break;
                    case 2:
                        Answer = "" + (firstNum * secondNum);
                        break;
                    case 3:
                        Answer = "" + (firstNum / secondNum);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public ViewModel()
        {
            CBinding1 = new CommandBinding(BtnCommand);
            CBinding1.Executed += CommandAnswer;
        }

    }
}
