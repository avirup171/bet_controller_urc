﻿//Avirup Basu
//www.avirupbasu.com
//Developed id: @avirup171
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
using System.IO.Ports;

namespace BET_Controller_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort sp = new SerialPort();
        public MainWindow()
        {
            InitializeComponent();
            Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        /*
         * 1: Fast front
         * 0: Fast back
         * 3: Fast right
         * 4: Fast left
         * 5: STOP
         * 6: Slow front
         * 7: Slow back
         * 8: Slow right
         * 9: Slow left
         * */
        //Keyboard Controls
        private void kbp_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(kbp);
            if (e.Key == Key.W)
            {
                sp.WriteLine("1");
                pbkc.IsIndeterminate = true;
                cmd.Text = "W: fast forward";
            }
            else if (e.Key == Key.S)
            {
                sp.WriteLine("0");
                pbkc.IsIndeterminate = true;
                cmd.Text = "S: fast back";
            }
            else if (e.Key == Key.A)
            {
                sp.WriteLine("4");
                pbkc.IsIndeterminate = true;
                cmd.Text = "A: fast left";
            }
            else if (e.Key == Key.D)
            {
                sp.WriteLine("3");
                pbkc.IsIndeterminate = true;
                cmd.Text = "D: fast right";
            }
            else if (e.Key == Key.NumPad8)
            {
                sp.WriteLine("6");
                pbkc.IsIndeterminate = true;
                cmd.Text = "9: slow front";
            }
            else if (e.Key == Key.NumPad2)
            {
                sp.WriteLine("7");
                pbkc.IsIndeterminate = true;
                cmd.Text = "2: slow back";
            }
            else if (e.Key == Key.NumPad6)
            {
                sp.WriteLine("8");
                pbkc.IsIndeterminate = true;
                cmd.Text = "6: slow right";
            }
            else if (e.Key == Key.NumPad4)
            {
                sp.WriteLine("9");
                pbkc.IsIndeterminate = true;
                cmd.Text = "D: slow left";
            }

        }
        private void Kbp_KeyUp(object sender, KeyEventArgs e)
        {
            sp.WriteLine("5");
            pbkc.IsIndeterminate = false;
            cmd.Text = "STOP";
        }
        //Connect to the hardware
        private void connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String pno = cno.Text;
                sp.PortName = pno;
                sp.BaudRate = 9600;
                sp.Open();
                s.Text = "Connected";
            }
            catch (Exception)
            {

                MessageBox.Show("Please check the com port number or the hardware attached to it");
            }
        }
        //Disconnect from the hardware
        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sp.Close();
                s.Text = "Disconnected";
            }
            catch (Exception)
            {

                MessageBox.Show("Some error occured with the connection");
            }
        }

        private void front_fast_GotMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("1");
            cmd.Text = "Fast Forward";
            pb1.IsIndeterminate = true;
        }

        private void front_fast_LostMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
            pb1.IsIndeterminate = false;
        }

        private void back_fast_GotMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("0");
            cmd.Text = "Fast Backward";
            pb1.IsIndeterminate = true;
        }

        private void back_fast_LostMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
            pb1.IsIndeterminate = false;
        }

        private void left_fast_GotMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("4");
            cmd.Text = "Fast left";
            pb1.IsIndeterminate = true;
        }

        private void left_fast_LostMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
            pb1.IsIndeterminate = false;
        }

        private void activate_Click(object sender, RoutedEventArgs e)
        {
            string s = pswrdbox.Password;
            if(s=="12345")
            {
                MessageBox.Show("Congrats Black e Track Controller V2 is activated");
                front_fast.IsEnabled = true;
                back_fast.IsEnabled = true;
                stop_fast.IsEnabled = true;
                left_fast.IsEnabled = true;
                right_fast.IsEnabled = true;
                front_slow.IsEnabled = true;
                back_slow.IsEnabled = true;
                right_slow.IsEnabled = true;
                left_slow.IsEnabled = true;
                stop_slow.IsEnabled = true;
                rr360.IsEnabled = true;
                lr360.IsEnabled = true;
                rst.IsEnabled = true;
                kbp.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Sorry you have entered wrong password. Please enter the correct credentials or contact your system administrator.");
            }
        }

        private void right_fast_GotMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("3");
            cmd.Text = "Fast Right";
            pb1.IsIndeterminate = true;
        }

        private void right_fast_LostMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
            pb1.IsIndeterminate = false;
        }

        private void front_slow_GotMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("6");
            cmd.Text = "Slow Front";
            pb2.IsIndeterminate = true;
        }


        private void front_slow_LostMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
            pb2.IsIndeterminate = false;
        }
        private void back_slow_LostMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
            pb2.IsIndeterminate = false;
        }


        private void back_slow_GotMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("7");
            cmd.Text = "Slow Back";
            pb2.IsIndeterminate = true;
        }
        private void left_slow_GotMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("9");
            cmd.Text = "Slow Left";
            pb2.IsIndeterminate = true;
        }

        private void left_slow_LostMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
            pb2.IsIndeterminate = false;
        }

        private void right_slow_LostMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
            pb2.IsIndeterminate = false;
        }

        private void right_slow_GotMouseCapture(object sender, MouseEventArgs e)
        {
            sp.WriteLine("8");
            cmd.Text = "Slow Right";
            pb2.IsIndeterminate = true;
        }

        private void stop_fast_Click(object sender, RoutedEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
        }

        private void stop_slow_Click(object sender, RoutedEventArgs e)
        {
            sp.WriteLine("5");
            cmd.Text = "STOP";
        }

        private void rr360_Click(object sender, RoutedEventArgs e)
        {
            sp.WriteLine("4");
            cmd.Text = "360 deg right rotation";
        }

        private void lr360_Click(object sender, RoutedEventArgs e)
        {
            sp.WriteLine("3");
            cmd.Text = "360 deg left rotation";
        }

        private void rst_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The control doesn't exist now");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            front_fast.IsEnabled = false;
            back_fast.IsEnabled = false;
            stop_fast.IsEnabled = false;
            left_fast.IsEnabled = false;
            right_fast.IsEnabled = false;
            front_slow.IsEnabled = false;
            back_slow.IsEnabled = false;
            right_slow.IsEnabled = false;
            left_slow.IsEnabled = false;
            stop_slow.IsEnabled = false;
            rr360.IsEnabled = false;
            lr360.IsEnabled = false;
            rst.IsEnabled = false;
            kbp.IsEnabled = false;
        }

        private void activate_KeyDown(object sender, KeyEventArgs e)
        {            
            if ((e.Key == Key.B) && Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt))
            {
                MessageBox.Show("Password: 12345");
            }

        }

           
    }
}
