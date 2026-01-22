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
        public SzczegolyWindow()
        {
            InitializeComponent();
        }
        private Employee _pracownik;

        public SzczegolyWindow(Employee pracownik) : this()
        {
            _pracownik = pracownik;

            LblPelneNazwisko.Text = $"{pracownik.Name} {pracownik.Surname}";
            LblPesel.Text = pracownik.Pesel;
            LblStatus.Text = pracownik.IsActive ? "Aktywny" : "Zwolniony";
        }

        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
