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
                try
                {
                    dataGrid.ItemsSource = _ot.GetSportmanById(Int32.Parse(sportmanIdTextBox.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void showSportbyId_Click(object sender, RoutedEventArgs e)
        {
            if (sportIdTextBox.Text != String.Empty)
            {
                try
                {
                    dataGrid.ItemsSource = _ot.GetSportById(Int32.Parse(sportIdTextBox.Text)); ;

                    dataGrid.Columns[0].Header = "Sport name";
                    dataGrid.Columns[1].Header = "Number of medals";
                    dataGrid.Columns[2].Header = "Number of sportman";
                    dataGrid.Columns[3].Header = "Number of countries";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void showCountrytbyId_Click(object sender, RoutedEventArgs e)
        {
            if (countryIdTextBox.Text != String.Empty)
            {
                try
                {
                    dataGrid.ItemsSource = _ot.GetCountryById(Int32.Parse(countryIdTextBox.Text)); ;

                    dataGrid.Columns[0].Header = "Country name";
                    dataGrid.Columns[1].Header = "Number of medals";
                    dataGrid.Columns[2].Header = "Number of sportman";
                    dataGrid.Columns[3].Header = "Number of sports";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void showTopCountriesbyMedalsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid.ItemsSource = _ot.GetTopCountriesByMedals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showTopSportsbyMedalsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid.ItemsSource = _ot.GetTopSportsByMedals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nStack Trace: " + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
