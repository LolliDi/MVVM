using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM
{
    public class ViewModel:INotifyPropertyChanged
    {
        public TextBox TBoxNum1;
        public TextBox TBoxNum2;

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropChan([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
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
                double firstNum = Convert.ToDouble(TBoxNum1.Text);
                double secondNum = Convert.ToDouble(TBoxNum2.Text);
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
