using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private double LastNumber;
        private double Result;
        private SelectedOperator _SelectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            //ResultLabel.Content = "1234";
            AcButton.Click += AcButton_Click;
            NegativeButton.Click += NegativeButton_Click;
            PercentageButton.Click += PercentageButton_Click;
            EqualButton.Click += EqualButton_Click;
            PointButton.Click += PointButton_Click;
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {


            if (ResultLabel.Content.ToString().Contains("."))
            {
                return;
            }

            ResultLabel.Content = $"{ResultLabel.Content}.";

        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch (_SelectedOperator)
                {
                    case SelectedOperator.Addition:
                        Result = SimpleMath.Add(LastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        Result = SimpleMath.Substract(LastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        Result = SimpleMath.Multiply(LastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        Result = SimpleMath.Divide(LastNumber, newNumber);
                        break;
                    default:
                        break;
                }

                ResultLabel.Content = Result.ToString();
            }

        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                newNumber = newNumber / 100;
                if (LastNumber != 0)
                {
                    newNumber *= LastNumber;
                }
                ResultLabel.Content = newNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out LastNumber))
            {
                LastNumber = LastNumber * -1;
                ResultLabel.Content = LastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
            Result = 0;
            LastNumber = 0;
        }

        private void SevenButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = "7";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}7";
            }
        }

        private void OperationButton_OnClick(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(ResultLabel.Content.ToString(), out LastNumber))
            {
                ResultLabel.Content = "0";
            }

            if (Equals(sender, DivisionButton))
            {
                _SelectedOperator = SelectedOperator.Division;
            }
            else if (Equals(sender, MultiplicationButton))
            {
                _SelectedOperator = SelectedOperator.Multiplication;
            }
            else if (Equals(sender, AdditionButton))
            {
                _SelectedOperator = SelectedOperator.Addition;
            }
            else if (Equals(sender, MinusButton))
            {
                _SelectedOperator = SelectedOperator.Substraction;
            }

        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            //int selectedValue = 0;

            //if (Equals(sender, ZeroButton))
            //    selectedValue = 0;
            //if (Equals(sender, OneButton))
            //    selectedValue = 1;
            //if (Equals(sender, TwoButton))
            //    selectedValue = 2;
            //if (Equals(sender, ThreeButton))
            //    selectedValue = 3;
            //if (Equals(sender, FourButton))
            //    selectedValue = 4;
            //if (Equals(sender, FiveButton))
            //    selectedValue = 5;
            //if (Equals(sender, SixButton))
            //    selectedValue = 6;
            //if (Equals(sender, SevenButton))
            //    selectedValue = 7;
            //if (Equals(sender, EightButton))
            //    selectedValue = 8;
            //if (Equals(sender, NineButton))
            //    selectedValue = 9;


            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = $"{selectedValue}";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double value1, double value2)
        {
            return value1 + value2;
        }
        public static double Substract(double value1, double value2)
        {
            return value1 - value2;
        }
        public static double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }
        public static double Divide(double value1, double value2)
        {
            if (value2 == 0)
            {
                MessageBox.Show("Division by zero is not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return value1 / value2;
        }
    }
}
