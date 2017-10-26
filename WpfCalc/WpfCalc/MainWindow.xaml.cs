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

namespace WpfCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int res = 0;
            int a = Convert.ToInt32(atxt.Text);
            int b = Convert.ToInt32(btxt.Text);
            char op = Convert.ToChar(optxt.Text);
            res = funct_calc(a, b, op);
            restxt.Text= Convert.ToString(res);
        }
    }
}
