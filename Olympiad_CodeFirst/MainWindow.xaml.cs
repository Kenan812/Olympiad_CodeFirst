using Olympiad_CodeFirst.Models;
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

namespace Olympiad_CodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OlympiadDbTool _ot = new OlympiadDbTool();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            _ot.InsertAll();
        }

        private void showSportmenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid.ItemsSource = _ot.GetAllSportmen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showSportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid.ItemsSource = _ot.GetAllSports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showCountriesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid.ItemsSource = _ot.GetAllCountries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showSportmanByIdButton_Click(object sender, RoutedEventArgs e)
        {
            if (sportmanIdTextBox.Text != String.Empty)
            {

            }


        }
    }
}
