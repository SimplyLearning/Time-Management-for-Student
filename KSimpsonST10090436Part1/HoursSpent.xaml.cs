using System;
using System.Collections.Generic;
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
using KS_Library;
using System.Linq;

namespace KSimpsonST10090436Part1
{
    /// <summary>
    /// Interaction logic for HoursSpent.xaml
    /// </summary>
    public partial class HoursSpent : Page
    {
        public HoursSpent()
        {
            InitializeComponent();
           
        }

        public void doingSomthing()
        {
            try
            {
                Module1.ml.certainDate = CurrenttDate.SelectedDate.Value;
                Module1.ml.hourSpent = int.Parse(txt_hours.Text);
                Module1.ml.moduleStudied = txt_code.Text;

                var values = from value in Module1.ml.modHours
                             select value;

                foreach (KeyValuePair<string, double> keyValue in Module1.ml.modHours)
                {
                    if (txt_code.Text == keyValue.Key)
                    //compare the current date and make sure it's within the week
                    {
                        //Module1.ml.ssHours = keyValue.Value - double.Parse(txt_hours.Text);
                        //MessageBox.Show("hours remaining: " + Module1.ml.ssHours);
                        remainingHours.Items.Add("\r Self Study Hours Remaining: " + (keyValue.Value - double.Parse(txt_hours.Text)) + "  for Module: " + keyValue.Key);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("The error identified was: " + ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            doingSomthing();
        }

        private void btn_exit(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
