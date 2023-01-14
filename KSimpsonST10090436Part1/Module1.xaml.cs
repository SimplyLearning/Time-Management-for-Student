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

namespace KSimpsonST10090436Part1
{

    /// <summary>
    /// Interaction logic for Module1.xaml
    /// </summary>
    public partial class Module1 : Page
    {
        
        public Module1()
        {
            InitializeComponent();
        }
        public static string moduleVal;
        public static double ssHours;
        public  static modulesLibrary ml = new modulesLibrary(); //a public object 

        // creating the button that holds all functions and stores data
        private void ClickP2(object sender, RoutedEventArgs e)
        {

            try // error handling all the results
            {
              
                moduleVal = Code.Text;
                //Storing the values entered
                //ml.modList.Add(new modulesLibrary()
                //{

                ml.code = Code.Text;
                ml.modules = Name.Text;
                ml.numCredit = int.Parse(numOfCredit.Text);
                ml.hoursWeek = int.Parse(HoursWeek.Text);
                ml.startDate = StartDate.SelectedDate.Value;
                ml.numWeeks = int.Parse(numOfWeeks.Text);
                //});
             
                ssHours = ml.Calculation(int.Parse(numOfCredit.Text), int.Parse(HoursWeek.Text), int.Parse(numOfWeeks.Text));
                // ml.hoursList.Add(ssHours);
                ml.modHours.Add(ml.code, ml.ssHours);

                //If statement
                MessageBoxResult result = MessageBox.Show("Would you like to enter another Module? ", "CHOICE", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    //popup if they chose 'YES'
                    Module1 m1 = new Module1();
                    this.NavigationService.Navigate(m1);

                }
                else
                {
                   // MessageBox.Show("This" + ssHours);
                   ModuleDisplay md = new ModuleDisplay(moduleVal);
                    this.NavigationService.Navigate(md);
                }

                // (Troelsen & Japikse, 2021)

            }
            catch (System.StackOverflowException ex)
            {
                //displaying the error if it occures
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
