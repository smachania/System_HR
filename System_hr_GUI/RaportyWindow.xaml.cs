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
using System.Windows.Shapes;
using System_hr;
using System_hr.System_HR;

namespace System_hr_GUI
{

    public partial class RaportyWindow : Window
    {
        private List<Department> wszystkieDzialy;
        public RaportyWindow(List<Department> dzialy)
        {
            InitializeComponent();
            if (dzialy == null)
            {
                MessageBox.Show("Błąd: Brak danych o działach!");
                this.Close();
                return;
            }
            wszystkieDzialy = dzialy;
            CbWyborDzialu.ItemsSource = wszystkieDzialy;
        }
  
        private void CbWyborDzialu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbWyborDzialu.SelectedItem == null) return;
            try
            {
                if (CbWyborDzialu.SelectedItem is Department wybranyDzial)
                {
                    int liczbaPracownikow = wybranyDzial.NumberOfEmployeesByDepart();
                    LblLiczbaPracownikowDzialu.Text = liczbaPracownikow.ToString();
                    decimal budzet = wybranyDzial.TotalDepartmentSalary();
                    LblSumaPlacDzialu.Text = budzet.ToString("N2") + " zł";
                    decimal srednia = liczbaPracownikow > 0 ? budzet / liczbaPracownikow : 0;
                    LblSredniaDzialu.Text = srednia.ToString("N2") + " zł";
                    DgPracownicyDzialu.ItemsSource = null;
                    DgPracownicyDzialu.ItemsSource = wybranyDzial.Employees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania raportu: " + ex.Message);
            }
        }
        

        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
