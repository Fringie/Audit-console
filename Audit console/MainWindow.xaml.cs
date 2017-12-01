using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Audit_console.Config;
using Audit_console.Logging;
using Catel.Logging;
using MahApps.Metro.Controls;
using Orc.Controls.ViewModels;

namespace Audit_console
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool _startToggled = false;

        public MainWindow()
        {
            InitializeComponent();
            BtnStart.IsChecked = true; // Inverted because of styling 'hack'
            GeneralPanel.MinHeight = BtnStart.Height * 1.2;
            if (!Main.Initialize()) // Run config, disable start btn if fail
            {
                Logger.AddLog(new Logging.LogData("", LogTypes.Default.LogConfigFailed,
                    LogClassificationTypes.Information, "Please resolve the above error(s) then restart the application."));
                BtnStart.IsEnabled = false;
            }
            
        }

        #region Start button styling
        /// <summary>
        /// Audit console on button essentially
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            SetStartBtnColour();
        }


        /// <summary>
        /// Changes the tic arrow colour from white to green and vice versa
        /// </summary>
        private void SetStartBtnColour()
        {
            if (_startToggled)
            {
                _startToggled = false;
                TicArrow.Fill = Brushes.White;
            }
            else
            {
                _startToggled = true;
                TicArrow.Fill = Brushes.Green;
            }
        }

        /// <summary>
        /// Increase button size via animation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_MouseEnter(object sender, MouseEventArgs e)
        {

            // Increase btn size +5px
            var startDa = new DoubleAnimation
            {
                From = 100,
                To = 105,
                Duration = new Duration(TimeSpan.FromMilliseconds(250))
            };
            BtnStart.BeginAnimation(Button.HeightProperty, startDa);
            BtnStart.BeginAnimation(Button.WidthProperty, startDa);
            // Increase tic size + 5px
            var ticDa = new DoubleAnimation
            {
                From = 60,
                To = 65,
                Duration = new Duration(TimeSpan.FromMilliseconds(250))
            };
            TicArrow.BeginAnimation(Button.HeightProperty, ticDa);
            TicArrow.BeginAnimation(Button.WidthProperty, ticDa);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_MouseLeave(object sender, MouseEventArgs e)
        {

            // Decrease btn size -5px
            var startDa = new DoubleAnimation
            {
                From = 105,
                To = 100,
                Duration = new Duration(TimeSpan.FromMilliseconds(200))
            };
            BtnStart.BeginAnimation(Button.HeightProperty, startDa);
            BtnStart.BeginAnimation(Button.WidthProperty, startDa);
            // Decrease tic size -5px
            var ticDa = new DoubleAnimation
            {
                From = 65,
                To = 60,
                Duration = new Duration(TimeSpan.FromMilliseconds(200))
            };
            TicArrow.BeginAnimation(Button.HeightProperty, ticDa);
            TicArrow.BeginAnimation(Button.WidthProperty, ticDa);

        }

        #endregion


    }
}
