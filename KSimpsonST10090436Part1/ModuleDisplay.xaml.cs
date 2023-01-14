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
using KS_Library;

namespace KSimpsonST10090436Part1
{
    /// <summary>
    /// Interaction logic for ModuleDisplay.xaml
    /// </summary>
    public partial class ModuleDisplay : Page
    {
        String modCode;
        public modulesLibrary mObj = new modulesLibrary();
        public ModuleDisplay(String val)
        {
            // error handling
            try
            {
                modCode = val;

                InitializeComponent();

                //using Linq
                //var module = from m in Module1.ml.modList
                //             select m;
                //foreach (var mod in module)
                //{
                //    listDisplay.Items.Add("\n\rModule Info: " + mod.code);

                //}

                //var hour = from h in Module1.ml.hoursList
                //           select h;
                //foreach(var hou in hour)
                //{
                //    listDisplay.Items.Add("Self Study Hours - " + hou);
                //}

                var values = from value in Module1.ml.modHours
                             select value;

                foreach (KeyValuePair<string, double> keyValue in values)
                {
                    listDisplay.Items.Add("\r Module Code: " + keyValue.Key + "\r Self Study Hours : " + keyValue.Value);
                }

            }

            catch (Exception ex)
            {
                // displaying the error to the user
                MessageBox.Show("The error identified was: " + ex.Message);
            }


        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

                HoursSpent hs = new HoursSpent();
                this.NavigationService.Navigate(hs);

            // (Troelsen & Japikse, 2021)
        }
    }
}
