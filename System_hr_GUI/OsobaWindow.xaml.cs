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
using System_hr.System_HR;

namespace System_hr_GUI
{
    public partial class OsobaWindow : Window
    {
        public Employee NowyPracownik { get; private set; }

        public OsobaWindow()
        {
            InitializeComponent();
        }
        private void BtnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtImie.Text) ||
                    string.IsNullOrWhiteSpace(TxtNazwisko.Text) ||
                    string.IsNullOrWhiteSpace(TxtPesel.Text))
                {
                    LblBlad.Text = "Wypełnij wszystkie pola tekstowe!";
                    return;
                }

                string imie = TxtImie.Text;
                string nazwisko = TxtNazwisko.Text;
                string pesel = TxtPesel.Text;
                EnumPlec plec = CbPlec.SelectedIndex == 0 ? EnumPlec.K : EnumPlec.M;
                DateTime dataZatrudnienia = DpDataZatrudnienia.SelectedDate ?? DateTime.Now;

                if (!decimal.TryParse(TxtKwotaFinansowa.Text, out decimal kwota))
                {
                    LblBlad.Text = "Błędna kwota finansowa!";
                    return;
                }
                NowyPracownik = new Employee(imie, nazwisko, plec, pesel, dataZatrudnienia);
                Contract umowa = null;
                switch (CbTypUmowy.SelectedIndex)
                {
                    case 0: // Umowa o pracę
                        umowa = new EmployeeContract(dataZatrudnienia, kwota);
                        break;
                    case 1: // B2B
                        umowa = new B2BContract(dataZatrudnienia, kwota, 160);
                        break;
                    case 2: //Staż
                        umowa = new InternshipContract(dataZatrudnienia, "Uczelnia", 3, kwota > 0);
                        break;
                    default:
                        LblBlad.Text = "Wybierz typ umowy!";
                        return;
                }
                NowyPracownik.ChangeContract(umowa);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                LblBlad.Text = ex.Message;
            }
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
