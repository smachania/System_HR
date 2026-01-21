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
using System_hr;
using System_hr.System_HR;

namespace System_hr_GUI
{
    public partial class HRPanelWindow : Window
    {
        public HRPanelWindow()
        {
            InitializeComponent();
        }
        //LOGIIKI PRZYCISKOW
        private void MenuWczytaj_Click(object sender, RoutedEventArgs e) { }
        private void MenuZapisz_Click(object sender, RoutedEventArgs e) { }
        private void BtnDodaj_Click(object sender, RoutedEventArgs e) { }
        private void BtnEdytuj_Click(object sender, RoutedEventArgs e) { }
        private void BtnZwolnij_Click(object sender, RoutedEventArgs e)
        {
            if (dgPracownicy.SelectedItem is Employee wybrany)
            {
                wybrany.Terminate();
                dgPracownicy.Items.Refresh();
            }
        }
        private void BtnSzczegoly_Click(object sender, RoutedEventArgs e) { }
    }
}
