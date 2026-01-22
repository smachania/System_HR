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

    public partial class SzczegolyWindow : Window
    {
        private Employee pracownik2;
        public SzczegolyWindow()
        {
            InitializeComponent();
        }

        public SzczegolyWindow(Employee pracownik) : this()
        {
            InitializeComponent();
            pracownik2 = pracownik;
 
            LblPelneNazwisko.Text = $"{pracownik.Name} {pracownik.Surname}";
            LblPesel.Text = pracownik.Pesel;
            LblStatus.Text = pracownik.IsActive ? "Aktywny" : "Zwolniony";
            WyswietlDane();
        }
        private void WyswietlDane()
        {
            LblPelneNazwisko.Text = $"{pracownik2.Name} {pracownik2.Surname}";
            LblPesel.Text = pracownik2.Pesel;
            LblPlec.Text = pracownik2.Plec.ToString();
            LblDataZatrudnienia.Text = pracownik2.HireDate.ToShortDateString();
            LblStatus.Text = pracownik2.IsActive ? "Aktywny" : "Zwolniony";

            if (pracownik2.Contract != null)
            {
                LblTypUmowy.Text = pracownik2.Contract.GetContractType();
                decimal pensja = pracownik2.Contract.CalculateSalary();
                LblNetto.Text = pensja.ToString("C2");
                LblWyliczonaWyplata.Text = pensja.ToString("C2");
                LblBrutto.Text = (pensja * 1.23m).ToString("C2");
            }
        }
        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
