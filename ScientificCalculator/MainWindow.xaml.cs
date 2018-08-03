using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;

namespace ScientificCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        private string number = "";
        private double previousNumber = 0;
        private double nextNumber = 0;
        private bool havePreviousNumber = false;
        private bool haveNextNumber = false;
        private string operation = "";
        private bool togglePlusMinusSign = true;
        private double memory = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Digit0Button_Click(object sender, RoutedEventArgs e)
        {
            number += "0";
            DisplayTextEdit.Text = number;
        }

        private void Digit1Button_Click(object sender, RoutedEventArgs e)
        {
            number += "1";
            DisplayTextEdit.Text = number;
        }

        private void Digit2Button_Click(object sender, RoutedEventArgs e)
        {
            number += "2";
            DisplayTextEdit.Text = number;
        }

        private void Digit3Button_Click(object sender, RoutedEventArgs e)
        {
            number += "3";
            DisplayTextEdit.Text = number;
        }

        private void Digit4Button_Click(object sender, RoutedEventArgs e)
        {
            number += "4";
            DisplayTextEdit.Text = number;
        }

        private void Digit5Button_Click(object sender, RoutedEventArgs e)
        {
            number += "5";
            DisplayTextEdit.Text = number;
        }

        private void Digit6Button_Click(object sender, RoutedEventArgs e)
        {
            number += "6";
            DisplayTextEdit.Text = number;
        }

        private void Digit7Button_Click(object sender, RoutedEventArgs e)
        {
            number += "7";
            DisplayTextEdit.Text = number;
        }

        private void Digit8Button_Click(object sender, RoutedEventArgs e)
        {
            number += "8";
            DisplayTextEdit.Text = number;
        }

        private void Digit9Button_Click(object sender, RoutedEventArgs e)
        {
            number += "9";
            DisplayTextEdit.Text = number;
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!number.Contains("."))
            {
                number += ".";
                DisplayTextEdit.Text = number;
            }
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            togglePlusMinusSign = true;
            if (number != "" && number != "." && !havePreviousNumber)
            {
                previousNumber = Double.Parse(number);
                havePreviousNumber = true;
                number = "";
            }
            else if (number != "" && number != "." && havePreviousNumber)
            {
                nextNumber = Double.Parse(number);
                haveNextNumber = true;
                number = "";
            }


            if (operation != "" && number != "." && haveNextNumber)
            {
                DoOperation(operation);
                number = "";
                haveNextNumber = false;
            }
            operation = "/";
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            togglePlusMinusSign = true;
            if (number != "" && number != "." && !havePreviousNumber)
            {
                previousNumber = Double.Parse(number);
                havePreviousNumber = true;
                number = "";
            }
            else if (number != "" && number != "." && havePreviousNumber)
            {
                nextNumber = Double.Parse(number);
                haveNextNumber = true;
                number = "";
            }

            if (operation != "" && number != "." && haveNextNumber)
            {
                DoOperation(operation);
                number = "";
                haveNextNumber = false;
            }
            operation = "*";
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            togglePlusMinusSign = true;
            if (number != "" && number != "." && !havePreviousNumber)
            {
                previousNumber = Double.Parse(number);
                havePreviousNumber = true;
                number = "";
            }
            else if (number != "" && number != "." && havePreviousNumber)
            {
                nextNumber = Double.Parse(number);
                haveNextNumber = true;
                number = "";
            }


            if (operation != "" && number != "." && haveNextNumber)
            {
                DoOperation(operation);
                number = "";
                haveNextNumber = false;
            }
            operation = "-";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            togglePlusMinusSign = true;
            if (number != "" && number != "." && !havePreviousNumber)
            {
                previousNumber = Double.Parse(number);
                havePreviousNumber = true;
                number = "";
            }
            else if (number != "" && number != "." && havePreviousNumber)
            {
                nextNumber = Double.Parse(number);
                haveNextNumber = true;
                number = "";
            }


            if (operation != "" && number != "." && haveNextNumber)
            {
                DoOperation(operation);
                number = "";
                haveNextNumber = false;
            }
            operation = "+";
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            togglePlusMinusSign = true;
            if (number != "" && operation != "" && number != "." && havePreviousNumber)
            {
                nextNumber = Double.Parse(number);
                DoOperation(operation);
                number = "";
                haveNextNumber = false;
            }
        }

        public void DoOperation(string op)
        {
            switch (op)
            {
                case "/":
                {
                    previousNumber /= nextNumber;
                    DisplayTextEdit.Text = previousNumber.ToString();
                    haveNextNumber = false;
                    break;
                }
                case "*":
                {
                    previousNumber *= nextNumber;
                    DisplayTextEdit.Text = previousNumber.ToString();
                    haveNextNumber = false;
                    break;
                }
                case "-":
                {
                    previousNumber -= nextNumber;
                    DisplayTextEdit.Text = previousNumber.ToString();
                    haveNextNumber = false;
                    break;
                }
                case "+":
                {
                    previousNumber += nextNumber;
                    DisplayTextEdit.Text = previousNumber.ToString();
                    haveNextNumber = false;
                    break;
                }
                case "=":
                {

                    DisplayTextEdit.Text = previousNumber.ToString();
                    haveNextNumber = false;
                    break;
                }
                default:
                {

                    break;
                }
            }
        }

        private void ClearAllButton_Click(object sender, RoutedEventArgs e)
        {
            number = "";
            previousNumber = 0;
            nextNumber = 0;
            havePreviousNumber = false;
            haveNextNumber = false;
            operation = "";
            togglePlusMinusSign = true;
            //memory = 0;
            DisplayTextEdit.Clear();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (number.Length > 1)
                number = number.Substring(0, number.Length - 1);
            else if (number.Length == 1)
            {
                number = "0";
            }
            DisplayTextEdit.Text = number;
        }

        private void DXWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D0 || e.Key == Key.NumPad0)
                Digit0Button_Click(Digit0Button, new RoutedEventArgs());
            else if (e.Key == Key.D1 || e.Key == Key.NumPad1)
                Digit1Button_Click(Digit1Button, new RoutedEventArgs());
            else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
                Digit2Button_Click(Digit2Button, new RoutedEventArgs());
            else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
                Digit3Button_Click(Digit3Button, new RoutedEventArgs());
            else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
                Digit4Button_Click(Digit4Button, new RoutedEventArgs());
            else if (e.Key == Key.D5 || e.Key == Key.NumPad5)
                Digit5Button_Click(Digit5Button, new RoutedEventArgs());
            else if (e.Key == Key.D6 || e.Key == Key.NumPad6)
                Digit6Button_Click(Digit6Button, new RoutedEventArgs());
            else if (e.Key == Key.D7 || e.Key == Key.NumPad7)
                Digit7Button_Click(Digit7Button, new RoutedEventArgs());
            else if (e.Key == Key.D8 || e.Key == Key.NumPad8)
                Digit8Button_Click(Digit8Button, new RoutedEventArgs());
            else if (e.Key == Key.D9 || e.Key == Key.NumPad9)
                Digit9Button_Click(Digit9Button, new RoutedEventArgs());
            else if (e.Key == Key.Decimal)
                DotButton_Click(DotButton, new RoutedEventArgs());
            else if (e.Key == Key.Divide)
                DivideButton_Click(DivideButton, new RoutedEventArgs());
            else if (e.Key == Key.Multiply)
                MultiplyButton_Click(MultiplyButton, new RoutedEventArgs());
            else if (e.Key == Key.Subtract)
                SubtractButton_Click(SubtractButton, new RoutedEventArgs());
            else if (e.Key == Key.Add)
                AddButton_Click(AddButton, new RoutedEventArgs());
            else if (e.Key == Key.Enter)
                EqualButton_Click(EqualButton, new RoutedEventArgs());
            else if (e.Key == Key.Back)
                ClearButton_Click(ClearButton, new RoutedEventArgs());

        }

        private void PlusMinusSignButton_Click(object sender, RoutedEventArgs e)
        {
            if (togglePlusMinusSign)
            {
                number = "-" + number.PadLeft(0);
                togglePlusMinusSign = false;
            }
            else if (number.Contains("-"))
            {
                number = number.Trim('-');
                togglePlusMinusSign = true;
            }
            DisplayTextEdit.Text = number;
        }

        private void MemoryAddButton_Click(object sender, RoutedEventArgs e)
        {
            memory += Double.Parse(DisplayTextEdit.Text);
        }

        private void MemoryMinusButton_Click(object sender, RoutedEventArgs e)
        {
            memory -= Double.Parse(DisplayTextEdit.Text);
        }

        private void MemoryClearButton_Click(object sender, RoutedEventArgs e)
        {
            memory = 0;
        }

        private void MemoryRecallButton_Click(object sender, RoutedEventArgs e)
        {
            number = memory.ToString();
            DisplayTextEdit.Text = number;
        }
    }
}
