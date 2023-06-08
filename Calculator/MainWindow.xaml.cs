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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private double _result;
        private string _operation;

        private string _resultSTR;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _resultSTR = "";
            _operation = "";
            _result = 0;
            Result.Content = "0";
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                _resultSTR += button.Content;
                Result.Content = _resultSTR;
            }
        }

        private void DoubleOperation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _result = double.Parse(_resultSTR);

                if (sender is Button button)
                {
                    _operation = button.Content.ToString();
                    _resultSTR+= " " + button.Content.ToString();
                }
                Result.Content = _resultSTR;
                _resultSTR = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double number2 = double.Parse(_resultSTR);

                //  Operations
                if (_operation == "+")
                {
                    _result += number2;
                }
                else if (_operation == "-")
                {
                    _result -= number2;
                }
                else if (_operation == "*")
                {
                    _result *= number2;
                }
                else if (_operation == "-")
                {
                    _result /= number2;
                }

                _resultSTR = _result.ToString();
                Result.Content = _resultSTR;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (_resultSTR != "")
            {
                _resultSTR = _resultSTR.Remove(_resultSTR.Length - 1);
                if (_resultSTR == "")
                {
                    Result.Content = "0";
                }
                else
                {
                   Result.Content = _resultSTR;
                }
            }
        }
    }
}
