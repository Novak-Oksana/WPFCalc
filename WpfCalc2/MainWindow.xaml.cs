using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalc2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool last_number = false;
        private Calculator calc;

        public MainWindow()
        {
            InitializeComponent();
            calc = new Calculator();
        }

        public class Calculator
        {
            private int result = 0;
            private char last_operator = '+';

            public static int funct_calc(int a, int b, char op)
            {
                switch (op)
                {
                    case '+':
                        return a + b;
                    case '-':
                        return a - b;
                    case '/':
                        return a / b;
                    case '*':
                        return a * b;
                }
                throw new ArgumentException("Illegal operator");
            }

            public void set_last_operator(char op)
            {
                last_operator = op;
            }

            public void calculate(int num)
            {
                result = funct_calc(result, num, last_operator);
            }

            public int get_result()
            {
                return result;
            }

        }
        private void btnNumClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (last_number)
                txtres.Text = txtres.Text + button.Content;
            else
                txtres.Text = "" + button.Content;

            last_number = true;
        }

        private void opClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            char op = System.Convert.ToChar(button.Content);
            calc.calculate(Convert.ToInt32(txtres.Text));
            calc.set_last_operator(op);
            last_number = false;
        }

        private void btnEqual(object sender, RoutedEventArgs e)
        {
            calc.calculate(Convert.ToInt32(txtres.Text));
            txtres.Text = "" + calc.get_result();
            last_number = false;
        }

        
    }
}
