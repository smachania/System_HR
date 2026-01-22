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
        private Company mojaFirma;
        private List<Employee> employees = new List<Employee>();
        private List<Department> dzialyFirmy = new List<Department>();
        public HRPanelWindow()
        {
            InitializeComponent();
            try
            {
                mojaFirma = Company.ReadFromJson("company.json");

                if (mojaFirma != null)
                {
                    dzialyFirmy = mojaFirma.Departments;
                    foreach (var d in dzialyFirmy)
                    {
                        employees.AddRange(d.Employees);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się wczytać bazy danych: " + ex.Message);
                mojaFirma = new Company("Nowa Firma");
                dzialyFirmy = mojaFirma.Departments;
            }
            DgPracownicy.ItemsSource = employees;
        }
        private void BtnDodaj_Click(object sender, RoutedEventArgs e) 
        {
            OsobaWindow okno = new OsobaWindow();
            okno.Owner = this;
            if (okno.ShowDialog() == true)
            {
                Employee nowy = okno.NowyPracownik;
                employees.Add(nowy);
                DgPracownicy.ItemsSource = null;
                DgPracownicy.ItemsSource = employees;
            }
        }
        private void BtnZwolnij_Click(object sender, RoutedEventArgs e)
        {
            if (DgPracownicy.SelectedItem is Employee wybrany)
            {
                employees.Remove(wybrany);
                DgPracownicy.ItemsSource = null;
                DgPracownicy.ItemsSource = employees;
                MessageBox.Show($"Pracownik {wybrany.Name} {wybrany.Surname} został usunięty.");
            }
            else
            {
                MessageBox.Show("Najpierw wybierz pracownika z listy!", "Brak zaznaczenia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void BtnSzczegoly_Click(object sender, RoutedEventArgs e) 
        {
            if (DgPracownicy.SelectedItem is  Employee wybrany)
            {
                SzczegolyWindow okno = new SzczegolyWindow(wybrany);
                okno.Owner = this;
                okno.ShowDialog();
            }
            else
            {
                MessageBox.Show("Proszę najpierw wybrać pracownika z listy, aby zobaczyć szczegóły.",
                        "Brak zaznaczenia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnUrlop_Click(object sender, RoutedEventArgs e)
        {
            if (DgPracownicy.SelectedItem is Employee wybrany)
            {
                UrlopWindow okno = new UrlopWindow(wybrany);
                okno.Owner = this;
                okno.ShowDialog();
            }
            else
            {
                MessageBox.Show("Najpierw wybierz pracownika z listy!", "Brak zaznaczenia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnRaporty_Click(object sender, RoutedEventArgs e)
        {
            Company firma = Company.ReadFromJson("company.json");
            RaportyWindow okno = new RaportyWindow(dzialyFirmy);
            okno.Owner = this;
            okno.ShowDialog();
        }
    }
}
