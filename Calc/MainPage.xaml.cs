using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;

using System.IO.IsolatedStorage;
using System.Windows;
using System.Linq;
using System.Net;

using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Collections;

namespace Calc
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        public Queue<string> queue = new Queue<string>();
        private char lastDequed;
        private bool isNegative = false;
        private bool reset = false;
        private Color light = Color.FromArgb(255, 255, 255, 255);
        
        private IsolatedStorageSettings appsettings = IsolatedStorageSettings.ApplicationSettings;
        public MainPage()
        {
            InitializeComponent();
            SolidColorBrush bbrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
            if (bbrush.Color == light)
            {
                shiftButton.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b0.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b1.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b2.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b3.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b4.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b5.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b6.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b7.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b8.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                b9.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));
                bdot.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));

                bscientific.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bAC.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bbackspace.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bclear.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bdiv.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bmul.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bminus.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bplus.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bequal.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));

                power10X_Copy.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {            
                shiftButton.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b0.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b1.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b2.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b3.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b4.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b5.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b6.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b7.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b8.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                b9.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                bdot.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));

                bscientific.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bAC.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bbackspace.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bclear.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bdiv.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bmul.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bminus.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bplus.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bequal.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));

                power10X_Copy.Foreground = new SolidColorBrush(Colors.Black);
            }
            if (appsettings.Contains("Equation"))
            {
                string content1 = appsettings["Equation"].ToString();
                textblock1.Text = content1;
            }
            if (appsettings.Contains("Queue"))
            {
                queue = (Queue<string>)appsettings["Queue"];
            }
            if (appsettings.Contains("resetValue"))
            {
                reset = (bool)appsettings["resetValue"];
            }
            if (textblock1.Text.Length > 13)
                textblock1.FontSize = 48.00;

        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "0";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("0");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "1";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("1");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "2";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("2");

            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "3";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("3");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "4";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("4");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "5";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("5");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "6";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("6");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "7";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("7");
            
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "8";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("8");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            chkReset1();
            textblock1.Text = textblock1.Text + "9";
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            queue.Enqueue("9");
        }

        private void Button_Click_CLR(object sender, RoutedEventArgs e)
        {
            reset = false;
            textblock1.Text = "";
            lastDequed = '(';
            
            while (queue.Count != 0)
            {
                queue.Dequeue();                            
            }
            textblock1.FontSize = 60.00;
        }

        private void Button_Click_dot(object sender, RoutedEventArgs e)
        {
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            if (queue.Count!=0 &&  queue.Last()== ".")
            { }
            else
            {
                textblock1.Text = textblock1.Text + ".";
                queue.Enqueue(".");
            }
        }

        void textblock1_LayoutUpdated(object sender, EventArgs e)
        {
            if (textblock1.Text.Length > 13)
            {
                textblock1.TextWrapping = TextWrapping.Wrap;
                textblock1.FontSize = 48.00;

            }
        }

        void textblock1_LayoutUpdated2(object sender, EventArgs e)
        {
            if (textblock1.Text.Length < 14)
            {
                textblock1.TextWrapping = TextWrapping.Wrap;
                textblock1.FontSize = 60.00;

            }
        }

        private void Button_Click_div(object sender, RoutedEventArgs e)
        {
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                lastDequed = '(';
                reset = false;
            }
            if (queue.Count == 0)
            { }
            else
            {
                if (isBasicOperator(queue.Last()))
                {
                    removeOperand();
                }

                textblock1.Text = textblock1.Text + "/";
                queue.Enqueue("/");
            }
        }

        private void Button_Click_plus(object sender, RoutedEventArgs e)
        {
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            if (queue.Count == 0)
            { }
            else
            {
                if (isBasicOperator(queue.Last()))
                {
                    removeOperand();
                }
                textblock1.Text = textblock1.Text + "+";
                queue.Enqueue("+");
            }
        }


        private void Button_Click_minus(object sender, RoutedEventArgs e)
        {
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            if (queue.Count == 0)
            { }
            else
            {
                if (queue.Last() == "+")
                {
                    removeOperand();
                }
                textblock1.Text = textblock1.Text + "-";
                queue.Enqueue("-");
            }
        }

        private void Button_Click_mul(object sender, RoutedEventArgs e)
        {
            textblock1.UpdateLayout();
            textblock1.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                lastDequed = '(';
                reset = false;
            }
            if (queue.Count == 0)
            { }
            else
            {
                if (isBasicOperator(queue.Last()))
                {
                    removeOperand();
                }
                textblock1.Text = textblock1.Text + "X";
                queue.Enqueue("*");
            }
        }


        private void Button_Click_total(object sender, RoutedEventArgs e)
        {
            convertToPostFix();

            if(textblock1.Text.Length<14)
            textblock1.FontSize = 60.00;
        }

        public void convertToPostFix()
        {
            try
            {
                Stack<string> stack = new Stack<string>();
                Queue<string> queuepf = new Queue<string>();
                stack.Push("(");
                queue.Enqueue(")");
                string postFix = string.Empty;
                while (stack.Count != 0 && queue.Count != 0)
                {

                    string current = queue.Dequeue();
                    if (current == "(" || current == "^")
                    {
                        stack.Push(Convert.ToString(current));
                        lastDequed = Convert.ToChar(current);
                    }

                    else if (current == "Sin" || current == "Cos" || current == "Tan" || current == "Log" || current == "aCos" || current == "aTan" || current == "aSin" || current == "Ln" || current == "Sinh" || current == "Cosh" || current == "Tanh")
                    {
                        if ((int)lastDequed >= 48 && (int)lastDequed <= 57)
                        {
                            stack.Push("*");
                        }
                        stack.Push(Convert.ToString(current));
                    }


                    else if (current == "+")
                    {
                        string nextOperandinStack = stack.Peek();
                        if (nextOperandinStack == "(")
                        {
                            stack.Push(Convert.ToString(current));
                        }
                        else
                        {
                            while (nextOperandinStack != "(")
                            {
                                string temp = stack.Pop();
                                queuepf.Enqueue(temp);
                                postFix += temp;
                                nextOperandinStack = stack.Peek();
                            }
                            stack.Push(Convert.ToString(current));
                        }
                        lastDequed = Convert.ToChar(current);
                    }

                    else if (current == "-")
                    {
                        if (!((int)lastDequed >= 48 && (int)lastDequed <= 57) || lastDequed == '(' || Convert.ToString(lastDequed) == "" || lastDequed == '^')
                        {
                            isNegative = true;
                        }
                        else
                        {
                            string nextOperandinStack = stack.Peek();
                            if (nextOperandinStack == "(")
                            {
                                stack.Push(Convert.ToString(current));
                            }
                            else
                            {
                                while (nextOperandinStack != "(")
                                {
                                    string temp = stack.Pop();
                                    queuepf.Enqueue(temp);
                                    postFix += temp;
                                    nextOperandinStack = stack.Peek();
                                }
                                stack.Push(Convert.ToString(current));
                            }
                        }
                    }




                    else if (current == "*" || current == "/")
                    {
                        string nextOperandinStack = stack.Peek();
                        if (nextOperandinStack == "(")
                        {
                            stack.Push(Convert.ToString(current));
                        }
                        else if (nextOperandinStack == "^")
                        {
                            while (nextOperandinStack == "^")
                            {
                                string temp = stack.Pop();
                                queuepf.Enqueue(temp);
                                postFix += temp;

                            }
                        }
                        else if (nextOperandinStack == "*" || nextOperandinStack == "/")
                        {
                            while (nextOperandinStack == "*" || nextOperandinStack == "/")
                            {
                                string temp = stack.Pop();
                                queuepf.Enqueue(temp);
                                postFix += temp;

                                nextOperandinStack = stack.Peek();
                            }
                            stack.Push(Convert.ToString(current));
                        }
                        else
                        {
                            stack.Push(Convert.ToString(current));
                        }
                        lastDequed = Convert.ToChar(current);

                    }

                    else if (current == ")")
                    {
                        string nextOperandinStack = stack.Peek();
                        while (nextOperandinStack != "(")
                        {
                            string temp = stack.Pop();
                            queuepf.Enqueue(temp);
                            postFix += temp;

                            nextOperandinStack = stack.Peek();
                        }
                        stack.Pop();
                        if (stack.Count != 0)
                            nextOperandinStack = stack.Peek();
                        if (nextOperandinStack == "Sin" || nextOperandinStack == "Cos" || nextOperandinStack == "Tan" || nextOperandinStack == "Log" || nextOperandinStack == "aCos" || nextOperandinStack == "aTan" || nextOperandinStack == "aSin" || nextOperandinStack == "Ln" || nextOperandinStack == "Sinh" || nextOperandinStack == "Cosh" || nextOperandinStack == "Tanh")
                        {
                            postFix += stack.Pop();
                            queuepf.Enqueue(nextOperandinStack);
                        }
                    }

                    else if (current == "!")
                    {
                        postFix += current;
                        queuepf.Enqueue(current);

                    }

                    else if ((int)Convert.ToChar(current) >= 48 && (int)Convert.ToChar(current) <= 57 || current == ".")
                    {

                        string currentOperands = string.Empty;

                        if (queue.Count != 0)
                        {
                            char nextVariable = Convert.ToChar(queue.Peek());
                            if (isNegative)
                            {
                                currentOperands += "-";
                                isNegative = false;
                            }
                            currentOperands += current;
                            while ((int)nextVariable >= 48 && (int)nextVariable <= 57 && queue.Count != 0 || nextVariable == '.')
                            {
                                current = queue.Dequeue();
                                currentOperands += current;
                                if (checkForScientific(queue.Peek()))
                                {
                                    break;
                                }
                                else
                                {
                                    nextVariable = Convert.ToChar(queue.Peek());
                                }
                            }
                        }
                        currentOperands += ",";
                        lastDequed = Convert.ToChar(current);
                        postFix += (currentOperands);
                        queuepf.Enqueue(currentOperands);
                    }
                }
                textblock1.Text = postFix;
                solveEquation(postFix, queuepf);
            }
            catch
            {
                reset = false;
                textblock1.Text = "";
                lastDequed = '(';

                while (queue.Count != 0)
                {
                    queue.Dequeue();
                }
                textblock1.FontSize = 60.00;
                MessageBox.Show("Syntax ERROR");
            }
        }

        public void solveEquation(string postFix, Queue<string> queuepf)
        {
            try
            {
                Stack<string> stack = new Stack<string>();
                while (queuepf.Count != 0)
                {

                    while (queuepf.Peek() != "*" && queuepf.Peek() != "/" && queuepf.Peek() != "+" && queuepf.Peek() != "-" && queuepf.Peek() != "Sin" && queuepf.Peek() != "Cos" && queuepf.Peek() != "Tan" && queuepf.Peek() != "Log" && queuepf.Peek() != "aCos" && queuepf.Peek() != "aTan" && queuepf.Peek() != "aSin" && queuepf.Peek() != "Ln" && queuepf.Peek() != "!" && queuepf.Peek() != "^" && queuepf.Peek() != "Tanh" && queuepf.Peek() != "Cosh" && queuepf.Peek() != "Sinh")
                    {
                        string current = queuepf.Dequeue();
                        string temp = current;
                        temp = temp.Replace(",", "");
                        stack.Push(temp);


                    }

                    string a = stack.Peek();
                    string op = queuepf.Dequeue();
                    double first = Convert.ToDouble(stack.Pop());

                    if (op == "+")
                    {
                        double second = Convert.ToDouble(stack.Pop());
                        stack.Push(Convert.ToString(first + second));
                    }
                    else if (op == "-")
                    {
                        double second = Convert.ToDouble(stack.Pop());
                        stack.Push(Convert.ToString(second - first));
                    }
                    else if (op == "*")
                    {
                        double second = Convert.ToDouble(stack.Pop());
                        stack.Push(Convert.ToString(first * second));
                    }
                    else if (op == "/")
                    {
                        double second = Convert.ToDouble(stack.Pop());
                        stack.Push(Convert.ToString(second / first));
                    }
                    else if (op == "Cos")
                    {
                        stack.Push(Convert.ToString(Math.Cos(first)));
                    }
                    else if (op == "Sin")
                    {
                        stack.Push(Convert.ToString(Math.Sin(first)));
                    }
                    else if (op == "aSin")
                    {
                        stack.Push(Convert.ToString(Math.Asin(first)));
                    }
                    else if (op == "aCos")
                    {
                        stack.Push(Convert.ToString(Math.Acos(first)));
                    }
                    else if (op == "Tan")
                    {
                        stack.Push(Convert.ToString(Math.Tan(first)));
                    }
                    else if (op == "aTan")
                    {
                        stack.Push(Convert.ToString(Math.Atan(first)));
                    }
                    else if (op == "Sinh")
                    {
                        stack.Push(Convert.ToString(Math.Sinh(first)));
                    }
                    else if (op == "Cosh")
                    {
                        stack.Push(Convert.ToString(Math.Cosh(first)));
                    }
                    else if (op == "Tanh")
                    {
                        stack.Push(Convert.ToString(Math.Tanh(first)));
                    }
                    else if (op == "Log")
                    {
                        stack.Push(Convert.ToString(Math.Log10(first)));
                    }
                    else if (op == "Ln")
                    {
                        stack.Push(Convert.ToString(Math.Log(first)));
                    }
                    else if (op == "Tan")
                    {
                        stack.Push(Convert.ToString(Math.Tan(first)));
                    }
                    else if (op == "!")
                    {
                        stack.Push(Convert.ToString(findFactorial(first)));
                    }
                    else if (op == "^")
                    {
                        double second = Convert.ToDouble(stack.Pop());
                        stack.Push(Convert.ToString(Math.Pow(second, first)));
                    }

                }
                if (stack.Count != 0)
                {
                    textblock1.Text = stack.Pop();
                }
                reset = true;
                for (int i = 0; i < textblock1.Text.Length; i++)
                {
                    queue.Enqueue(textblock1.Text.Substring(i, 1));
                }
            }
            catch
            {
                reset = false;
                textblock1.Text = "";
                lastDequed = '(';

                while (queue.Count != 0)
                {
                    queue.Dequeue();
                }
                textblock1.FontSize = 60.00;
                MessageBox.Show("Syntax ERROR");
            }
        }

        private bool checkForScientific(string current)
        {
            if (current == "Sin" || current == "Cos" || current == "Tan" || current == "Log" || current == "aCos" || current == "aTan" || current == "aSin" || current == "Ln")
            {
                return true;
            }
            else return false;
        }

        private bool isBasicOperator(string current)
        {
            if (current == "+" || current == "-" || current == "*" || current == "/")
                return true;
            else return false;
        }

        private void removeOperand()
        {
            textblock1.Text = textblock1.Text.Remove(textblock1.Text.Length - 1);
            Queue<string> queueTemp = new Queue<string>();
            int qcount = queue.Count;
            for (int cnt = 1; cnt < qcount; cnt++)
            {
                queueTemp.Enqueue(queue.Dequeue());
            }
            queue = queueTemp;
            
        }
        private void scientific_click(object sender, RoutedEventArgs e)
        {
            if (appsettings.Contains("Queue"))
            {
                appsettings.Remove("Queue");
                appsettings.Add("Queue", queue);
            }
            else
            {
                appsettings.Add("Queue", queue);
            }
            if (appsettings.Contains("Equation"))
            {
                appsettings.Remove("Equation");
                appsettings.Add("Equation", textblock1.Text);
            }
            else
            {
                appsettings.Add("Equation", textblock1.Text);
            }
            if (appsettings.Contains("resetValue"))
            {
                appsettings.Remove("resetValue");
                appsettings.Add("resetValue", reset);
            }
            else
            {
                appsettings.Add("resetValue", reset);
            }
            
            NavigationService.Navigate(new Uri("/scientific.xaml", UriKind.Relative));

        }
 
        public long findFactorial(double first)
        {
            if (first == 0)
                return 1;
            return (long)(first * findFactorial(first - 1));
        }

        private void chkReset1()
        {
            if (reset)
            {
                textblock1.Text = "";
                reset = false;
                while (queue.Count != 0)
                {
                    queue.Dequeue();
                }
            }
        }

        private void Button_Click_DELETE(object sender, RoutedEventArgs e)
        {
            if (reset)
            {
                chkReset1();
            }
            else
            {
                if (queue.Count == 0)
                { }
                else if (queue.ElementAt(queue.Count - 1) == "Log" || queue.ElementAt(queue.Count - 1) == "Sin" || queue.ElementAt(queue.Count - 1) == "Cos" || queue.ElementAt(queue.Count - 1) == "Tan")
                {
                    textblock1.Text = textblock1.Text.Remove(textblock1.Text.Length - 3);
                }
                else if (queue.ElementAt(queue.Count - 1) == "Sinh" || queue.ElementAt(queue.Count - 1) == "Cosh" || queue.ElementAt(queue.Count - 1) == "Tanh")
                {
                    textblock1.Text = textblock1.Text.Remove(textblock1.Text.Length - 4);
                }
                else if (queue.ElementAt(queue.Count - 1) == "aSin" || queue.ElementAt(queue.Count - 1) == "aCos" || queue.ElementAt(queue.Count - 1) == "aTan")
                {
                    textblock1.Text = textblock1.Text.Remove(textblock1.Text.Length - 5);
                }
                else if (queue.ElementAt(queue.Count - 1) == "Ln")
                {
                    textblock1.Text = textblock1.Text.Remove(textblock1.Text.Length - 2);
                }
                else
                {
                    if (textblock1.Text.Length == 0)
                    { }
                    else if (textblock1.Text.Length == 1)
                    {
                        textblock1.Text = string.Empty;
                    }
                    else
                    {
                        textblock1.Text = textblock1.Text.Remove(textblock1.Text.Length - 1);
                    }
                }
                Queue<string> queueTemp = new Queue<string>();
                int qcount = queue.Count;

                for (int cnt = 1; cnt < qcount; cnt++)
                {
                    queueTemp.Enqueue(queue.Dequeue());
                }
                queue = queueTemp;
                textblock1.FontSize = 60.00;
            }
        }

        
        private void allClear(object sender, RoutedEventArgs e)
        {
            reset = false;
            textblock1.Text = "";
            lastDequed = '(';

            while (queue.Count != 0)
            {
                queue.Dequeue();
            }
            textblock1.FontSize = 60.00;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            if (MessageBox.Show("Are you Sure You want to Exit?", "Exit", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                while (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }

            }
            else
            {
                e.Cancel = true;
            }


        }

    }
}