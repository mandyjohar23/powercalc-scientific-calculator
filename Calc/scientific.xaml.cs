using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Windows.Media;

namespace Calc
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Queue<string>  queue = new Queue<string>();
        private bool shift = false;
        private bool hyper = false;
        private bool reset = false;
        private IsolatedStorageSettings appsettings = IsolatedStorageSettings.ApplicationSettings;
        private Color light = Color.FromArgb(255, 255, 255, 255);
        public Page1()
        {
            InitializeComponent();
            SolidColorBrush bbrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
            if (bbrush.Color == light)
            {
                shiftButton.Background = new SolidColorBrush(Color.FromArgb(255, 191, 186, 186));

                bback.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bAC.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bbackspace.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                bclear.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                hyperButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                sinButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                cosButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                tanButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                lnButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                logButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                powerOfTenButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                factButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                powerButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                sqrootButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                squareButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                inverseButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                expButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                lparButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                rparButton.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));
                inverseButton2.Background = new SolidColorBrush(Color.FromArgb(255, 168, 167, 167));

                power10X_Copy.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                shiftButton.Background = new SolidColorBrush(Color.FromArgb(255, 77, 73, 73));
                
                bback.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bAC.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bbackspace.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                bclear.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                hyperButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                sinButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                cosButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                tanButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                lnButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                logButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                powerOfTenButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                factButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                powerButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                sqrootButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                squareButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                inverseButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                expButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                lparButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                rparButton.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));
                inverseButton2.Background = new SolidColorBrush(Color.FromArgb(255, 23, 21, 21));

                power10X_Copy.Foreground = new SolidColorBrush(Colors.Black);
            }
            if (appsettings.Contains("Equation"))
            {
                string content=appsettings["Equation"].ToString();
                textblock1Scientific.Text = content;
            }
            if (appsettings.Contains("Queue"))
            {
                queue = (Queue<string>)appsettings["Queue"];
            }
            if (appsettings.Contains("resetValue"))
            {
                reset = (bool)appsettings["resetValue"];
            }
            if (textblock1Scientific.Text.Length > 13)
                textblock1Scientific.FontSize = 48.00;
        }
    
        private void back_click(object sender, RoutedEventArgs e)
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
                appsettings.Add("Equation", textblock1Scientific.Text);
            }
            else
            {
                appsettings.Add("Equation",textblock1Scientific.Text);
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
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Button_Click_pie(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            char p;
            bool s = char.TryParse("\u03a0", out p);
            textblock1Scientific.Text=textblock1Scientific.Text+Convert.ToString(p);
            if (queue.Count >= 3 && checkForScientific(queue.ElementAt(queue.Count - 3)))
            {
                double a = 22/7/180;
                queue.Enqueue(a.ToString());queue.Enqueue("*");
            }
            else
            queue.Enqueue("3"); queue.Enqueue("."); queue.Enqueue("1"); queue.Enqueue("4");
        }

        private void button_click_lpar(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            textblock1Scientific.Text += "(";
            queue.Enqueue("(");
        }
        private void button_click_rpar(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            textblock1Scientific.Text += ")";
            queue.Enqueue(")");
        }

        void textblock1_LayoutUpdated(object sender, EventArgs e)
        {
            if (textblock1Scientific.Text.Length > 13)
            {
                textblock1Scientific.TextWrapping = TextWrapping.Wrap;
                textblock1Scientific.FontSize = 48.00;

            }
        }

        void textblock1_LayoutUpdated2(object sender, EventArgs e)
        {
            if (textblock1Scientific.Text.Length < 14)
            {
                textblock1Scientific.TextWrapping = TextWrapping.Wrap;
                textblock1Scientific.FontSize = 60.00;

            }
        }

        private void Button_Click_sin(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();

            if (shift)
            {
                textblock1Scientific.Text += "sin-1(";
                queue.Enqueue("aSin"); queue.Enqueue("(");
                shift = false;
                hyperButton.IsEnabled = true;
                enableButtons();
                uncolor();
            }

            else if (hyper)
            {
                textblock1Scientific.Text += "sinh(";
                queue.Enqueue("Sinh"); queue.Enqueue("(");
                unHype();
            }

            else
            {
                textblock1Scientific.Text += "sin(";
                queue.Enqueue("Sin"); queue.Enqueue("(");
            }
        }

 

        
        private void Button_Click_cos(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            if (shift)
            {
                
                
                    textblock1Scientific.Text += "cos-1(";
                    queue.Enqueue("aCos"); queue.Enqueue("(");
                    shift = false;
                    hyperButton.IsEnabled = true;
                    enableButtons();
                    uncolor();
                
            }
            else if (hyper)
            {
                textblock1Scientific.Text += "cosh(";
                queue.Enqueue("Cosh"); queue.Enqueue("(");
                unHype();
            }
            else
            {
                textblock1Scientific.Text += "cos(";
                queue.Enqueue("Cos"); queue.Enqueue("(");
            }
        }


        

        private void Button_Click_tan(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            if (shift)
            {
                textblock1Scientific.Text += "tan-1(";
                queue.Enqueue("aTan"); queue.Enqueue("(");
                shift = false;
                hyperButton.IsEnabled = true;
                enableButtons();
                uncolor();

            }
            else if (hyper)
            {
                textblock1Scientific.Text += "tanh(";
                queue.Enqueue("Tanh"); queue.Enqueue("(");
                unHype();
            }

            else
            {
                textblock1Scientific.Text += "tan(";
                queue.Enqueue("Tan"); queue.Enqueue("(");
            }
        }

        private void Button_Click_log(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            textblock1Scientific.Text += "log(";
            queue.Enqueue("Log"); queue.Enqueue("(");

        }
        private void Button_Click_ln(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            textblock1Scientific.Text += "ln(";
            queue.Enqueue("Ln"); queue.Enqueue("(");

        }
        private void Button_Click_fact(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            textblock1Scientific.Text += "!";
            queue.Enqueue("!");

        }
        private void Button_Click_exp(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            chkReset1();
            textblock1Scientific.Text += "2.718";
            queue.Enqueue("2"); queue.Enqueue("."); queue.Enqueue("7"); queue.Enqueue("1"); queue.Enqueue("8");

        }

        private void Button_Click_sqroot(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            if (shift)
            {
                textblock1Scientific.Text += "^(1/3)";
                queue.Enqueue("^"); queue.Enqueue("("); queue.Enqueue("1"); queue.Enqueue("/"); queue.Enqueue("3"); queue.Enqueue(")");
                shift = false;
                hyperButton.IsEnabled = true;
                enableButtons();
                uncolor();
            }
            else
            {
                textblock1Scientific.Text += "^0.5";
                queue.Enqueue("^"); queue.Enqueue("0"); queue.Enqueue("."); queue.Enqueue("5");
            }
        }

        private void button_click_power(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            textblock1Scientific.Text += "^";
            queue.Enqueue("^");
        }

        private void button_click_square(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            if (shift)
            {
                textblock1Scientific.Text += "^3";
                queue.Enqueue("^"); queue.Enqueue("3");
                shift = false;
                hyperButton.IsEnabled = true;
                enableButtons();
                uncolor();
            }
            else
            {
                textblock1Scientific.Text += "^2";
                queue.Enqueue("^"); queue.Enqueue("2");
            }
        }

        private void Button_Click_shift(object sender, RoutedEventArgs e)
        {
            
            if (!shift)
            {
                shift = true;
                shiftButton.Foreground = new SolidColorBrush(Colors.Cyan);
                u1.Foreground = new SolidColorBrush(Colors.Cyan);
                u2.Foreground = new SolidColorBrush(Colors.Cyan);
                u3.Foreground = new SolidColorBrush(Colors.Cyan);
                u4.Foreground = new SolidColorBrush(Colors.Cyan);
                u5.Foreground = new SolidColorBrush(Colors.Cyan);
                u6.Foreground = new SolidColorBrush(Colors.Cyan);
                u7.Foreground = new SolidColorBrush(Colors.Cyan);
                u8.Foreground = new SolidColorBrush(Colors.Cyan);
                u9.Foreground = new SolidColorBrush(Colors.Cyan);
                u10.Foreground = new SolidColorBrush(Colors.Cyan);
                u11.Foreground = new SolidColorBrush(Colors.Cyan);
                u12.Foreground = new SolidColorBrush(Colors.Cyan);
                u13.Foreground = new SolidColorBrush(Colors.Cyan);
                sinButton.Foreground = new SolidColorBrush(Colors.Gray);
                cosButton.Foreground = new SolidColorBrush(Colors.Gray);
                tanButton.Foreground = new SolidColorBrush(Colors.Gray);
                sqrootButton.Foreground = new SolidColorBrush(Colors.Gray);
                power10X.Foreground = new SolidColorBrush(Colors.Gray);
                sqrootLine.Foreground = new SolidColorBrush(Colors.Gray);
                square2.Foreground = new SolidColorBrush(Colors.Gray);
                inverseX.Foreground = new SolidColorBrush(Colors.Gray);
                inverse2x2.Foreground = new SolidColorBrush(Colors.Gray);
                inverse2X.Foreground = new SolidColorBrush(Colors.Gray);
                inverse1.Foreground = new SolidColorBrush(Colors.Gray);
                inverse21.Foreground = new SolidColorBrush(Colors.Gray);
               
                powerX.Foreground = new SolidColorBrush(Colors.Gray);
                sqrootLine3.Foreground = new SolidColorBrush(Colors.Gray);
                sqrootLine2.Foreground = new SolidColorBrush(Colors.Gray);
                squareButton.Foreground = new SolidColorBrush(Colors.Gray);
                hyperButton.IsEnabled = false;
                disableButtons();
            }
            else
            {
                shift = false;
                hyperButton.IsEnabled = true;
                enableButtons();
                uncolor();
            }
        }

        private void disableButtons()
        {
            logButton.IsEnabled=false;
            lnButton.IsEnabled=false;
            factButton.IsEnabled=false;
            expButton.IsEnabled=false;
          
            powerButton.IsEnabled=false;
            inverseButton.IsEnabled=false;
            inverseButton2.IsEnabled = false;
            powerOfTenButton.IsEnabled=false;
            lparButton.IsEnabled=false;
            rparButton.IsEnabled=false;
            if (hyper)
            {
                squareButton.IsEnabled = false;
                sqrootButton.IsEnabled = false;
            }
           
        }

        private void enableButtons()
        {
            logButton.IsEnabled = true;
            lnButton.IsEnabled = true;
            factButton.IsEnabled = true;
            expButton.IsEnabled = true;
            
            powerButton.IsEnabled = true;
            sqrootButton.IsEnabled = true;
            squareButton.IsEnabled = true;
            inverseButton.IsEnabled = true;
            inverseButton2.IsEnabled = true;
            powerOfTenButton.IsEnabled = true;
            lparButton.IsEnabled = true;
            rparButton.IsEnabled = true;
        }

            

        

        private void unHype()
        {
            hyper = false;
            sinButton.Content = "sin";
            cosButton.Content = "cos";
            tanButton.Content = "tan";
            hyperButton.Foreground = new SolidColorBrush(Colors.White);
            sinButton.Foreground = new SolidColorBrush(Colors.White);
            cosButton.Foreground = new SolidColorBrush(Colors.White);
            tanButton.Foreground = new SolidColorBrush(Colors.White);
            power10X.Foreground = new SolidColorBrush(Colors.White);
            sqrootLine.Foreground = new SolidColorBrush(Colors.White);
            square2.Foreground = new SolidColorBrush(Colors.White);
            inverseX.Foreground = new SolidColorBrush(Colors.White);
            inverse2x2.Foreground = new SolidColorBrush(Colors.White);
            inverse2X.Foreground = new SolidColorBrush(Colors.White);
            inverse1.Foreground = new SolidColorBrush(Colors.White);
            inverse21.Foreground = new SolidColorBrush(Colors.White);
            
            powerX.Foreground = new SolidColorBrush(Colors.White);
            sqrootLine3.Foreground = new SolidColorBrush(Colors.White);
            sqrootLine2.Foreground = new SolidColorBrush(Colors.White);
            u7.Foreground = new SolidColorBrush(Colors.White);
            u8.Foreground = new SolidColorBrush(Colors.White);
            u9.Foreground = new SolidColorBrush(Colors.White);
            u10.Foreground = new SolidColorBrush(Colors.White);
            u11.Foreground = new SolidColorBrush(Colors.White);
            u12.Foreground = new SolidColorBrush(Colors.White);
            u13.Foreground = new SolidColorBrush(Colors.White);
 
            
            shiftButton.IsEnabled = true;
            enableButtons();
        }

        private void uncolor()
        {
            shiftButton.Foreground = new SolidColorBrush(Colors.White);
            u1.Foreground = new SolidColorBrush(Colors.White);
            u2.Foreground = new SolidColorBrush(Colors.White);
            u3.Foreground = new SolidColorBrush(Colors.White);
            u4.Foreground = new SolidColorBrush(Colors.White);
            u5.Foreground = new SolidColorBrush(Colors.White);
            u6.Foreground = new SolidColorBrush(Colors.White);
            u7.Foreground = new SolidColorBrush(Colors.White);
            u8.Foreground = new SolidColorBrush(Colors.White);
            u9.Foreground = new SolidColorBrush(Colors.White);
            u10.Foreground = new SolidColorBrush(Colors.White);
            u11.Foreground = new SolidColorBrush(Colors.White);
            u12.Foreground = new SolidColorBrush(Colors.White);
            u13.Foreground = new SolidColorBrush(Colors.White);
            sinButton.Foreground = new SolidColorBrush(Colors.White);
            cosButton.Foreground = new SolidColorBrush(Colors.White);
            tanButton.Foreground = new SolidColorBrush(Colors.White);
            sqrootButton.Foreground = new SolidColorBrush(Colors.White);
            squareButton.Foreground = new SolidColorBrush(Colors.White);
            power10X.Foreground = new SolidColorBrush(Colors.White);
            sqrootLine.Foreground = new SolidColorBrush(Colors.White);
            square2.Foreground = new SolidColorBrush(Colors.White);
            inverseX.Foreground = new SolidColorBrush(Colors.White);
            inverse2X.Foreground = new SolidColorBrush(Colors.White);
            inverse2x2.Foreground = new SolidColorBrush(Colors.White);
            inverse1.Foreground = new SolidColorBrush(Colors.White);
            inverse21.Foreground = new SolidColorBrush(Colors.White);
            
            powerX.Foreground = new SolidColorBrush(Colors.White);
            sqrootLine3.Foreground = new SolidColorBrush(Colors.White);
            sqrootLine2.Foreground = new SolidColorBrush(Colors.White);
        }
        private void Button_Click_CLR(object sender, RoutedEventArgs e)
        {
            reset = false;
            textblock1Scientific.Text = "";

            while (queue.Count != 0)
            {
                queue.Dequeue();
            }
            textblock1Scientific.FontSize = 60.00;
        }

        private void button_click_hyper(object sender, RoutedEventArgs e)
        {
            if (!hyper)
            {
                hyper = true;
                hyperButton.Foreground = new SolidColorBrush(Colors.Cyan);
                sinButton.Content += "h";
                cosButton.Content += "h";
                tanButton.Content += "h";
                sinButton.Foreground=new SolidColorBrush(Colors.Cyan);
                cosButton.Foreground = new SolidColorBrush(Colors.Cyan);
                tanButton.Foreground = new SolidColorBrush(Colors.Cyan);
                power10X.Foreground = new SolidColorBrush(Colors.Gray);
                sqrootLine.Foreground = new SolidColorBrush(Colors.Gray);
                square2.Foreground = new SolidColorBrush(Colors.Gray);
                inverseX.Foreground = new SolidColorBrush(Colors.Gray);
                inverse2x2.Foreground = new SolidColorBrush(Colors.Gray);
                inverse2X.Foreground = new SolidColorBrush(Colors.Gray);
                inverse1.Foreground = new SolidColorBrush(Colors.Gray);
                inverse21.Foreground = new SolidColorBrush(Colors.Gray);
                
                powerX.Foreground = new SolidColorBrush(Colors.Gray);
                sqrootLine3.Foreground = new SolidColorBrush(Colors.Gray);
                sqrootLine2.Foreground = new SolidColorBrush(Colors.Gray);
                u7.Foreground = new SolidColorBrush(Colors.Gray);
                u8.Foreground = new SolidColorBrush(Colors.Gray);
                u9.Foreground = new SolidColorBrush(Colors.Gray);
                u10.Foreground = new SolidColorBrush(Colors.Gray);
                u11.Foreground = new SolidColorBrush(Colors.Gray);
                u12.Foreground = new SolidColorBrush(Colors.Gray);
                u13.Foreground = new SolidColorBrush(Colors.Gray);
                shiftButton.IsEnabled = false;
                disableButtons();
            }

            else
            {
                unHype();
            }
        }

        private void Button_Click_inverse(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            textblock1Scientific.Text += "^-1";
            queue.Enqueue("^"); queue.Enqueue("-"); queue.Enqueue("1");
        }

        private void chkReset1()
        {
            if (reset)
            {
                textblock1Scientific.Text = "";
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
                    textblock1Scientific.Text = textblock1Scientific.Text.Remove(textblock1Scientific.Text.Length - 3);
                }
                else if (queue.ElementAt(queue.Count - 1) == "Sinh" || queue.ElementAt(queue.Count - 1) == "Cosh" || queue.ElementAt(queue.Count - 1) == "Tanh")
                {
                    textblock1Scientific.Text = textblock1Scientific.Text.Remove(textblock1Scientific.Text.Length - 4);
                }
                else if (queue.ElementAt(queue.Count - 1) == "aSin" || queue.ElementAt(queue.Count - 1) == "aCos" || queue.ElementAt(queue.Count - 1) == "aTan")
                {
                    textblock1Scientific.Text = textblock1Scientific.Text.Remove(textblock1Scientific.Text.Length - 5);
                }
                else if (queue.ElementAt(queue.Count - 1) == "Ln")
                {
                    textblock1Scientific.Text = textblock1Scientific.Text.Remove(textblock1Scientific.Text.Length - 2);
                }
                else
                {
                    if (textblock1Scientific.Text.Length == 0)
                    { }
                    else if (textblock1Scientific.Text.Length == 1)
                    {
                        textblock1Scientific.Text = string.Empty;
                    }
                    else
                    {
                        textblock1Scientific.Text = textblock1Scientific.Text.Remove(textblock1Scientific.Text.Length - 1);
                    }
                }
                Queue<string> queueTemp = new Queue<string>();
                int qcount = queue.Count;

                for (int cnt = 1; cnt < qcount; cnt++)
                {
                    queueTemp.Enqueue(queue.Dequeue());
                }
                queue = queueTemp;
                textblock1Scientific.FontSize = 60.00;
            }
        }

        private void powerOf10(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            textblock1Scientific.Text += "X10^";
            queue.Enqueue("*"); queue.Enqueue("1"); queue.Enqueue("0"); queue.Enqueue("^");
        }

        private bool checkForScientific(string current)
        {
            if (current == "Sin" || current == "Cos" || current == "Tan" || current == "Log" || current == "aCos" || current == "aTan" || current == "aSin" || current == "Ln")
            {
                return true;
            }
            else return false;
        }

        private void allclear(object sender, RoutedEventArgs e)
        {
            reset = false;
            textblock1Scientific.Text = "";

            while (queue.Count != 0)
            {
                queue.Dequeue();
            }
            textblock1Scientific.FontSize = 60.00;
        }

        private void Button_Click_inverse2(object sender, RoutedEventArgs e)
        {
            textblock1Scientific.UpdateLayout();
            textblock1Scientific.LayoutUpdated += textblock1_LayoutUpdated;
            if (reset)
            {
                reset = false;
            }
            textblock1Scientific.Text += "^-2";
            queue.Enqueue("^"); queue.Enqueue("-"); queue.Enqueue("2");
        }
        
    }
}
