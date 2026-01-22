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
        private List<Employee> employees = new List<Employee>();
        public HRPanelWindow()
        {
            InitializeComponent();
        }

        //LOGIIKI PRZYCISKOW
        private void MenuWczytaj_Click(object sender, RoutedEventArgs e)  {  }
        private void MenuZapisz_Click(object sender, RoutedEventArgs e) 
        {
        }
        private void BtnDodaj_Click(object sender, RoutedEventArgs e) 
        {
            OsobaWindow oknoDodawania = new OsobaWindow();
            oknoDodawania.Owner = this;
            if (oknoDodawania.ShowDialog() == true)
            {
                employees.Add(oknoDodawania.NowyPracownik);
                DgPracownicy.Items.Refresh();
            }
        }
        private void BtnEdytuj_Click(object sender, RoutedEventArgs e) { }
        private void BtnZwolnij_Click(object sender, RoutedEventArgs e)
        {
            if (DgPracownicy.SelectedItem is Employee wybrany)
            {
                wybrany.Terminate();
                DgPracownicy.Items.Refresh();
            }
        }
        private void BtnSzczegoly_Click(object sender, RoutedEventArgs e) 
        {
            if (DgPracownicy.SelectedItem is not Employee wybrany)
                return;
            var okno = new SzczegolyWindow(wybrany)
            {
                Owner = this
            };
            okno.ShowDialog();
        }

        private void BtnUrlop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRaporty_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
