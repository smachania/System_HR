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

    public partial class UrlopWindow : Window
    {
        private Employee pracownik2;
        public UrlopWindow(Employee pracownik)
        {
            InitializeComponent();

            pracownik2 = pracownik;

            InicjalizujDane();
        }

        private void InicjalizujDane()
        {
            if (pracownik2 != null)
            {
                TxtPracownikDane.Text = $"{pracownik2.Name} {pracownik2.Surname}";
                LblPozostalo.Text = "20";
                LblWykorzystano.Text = "6";

                DpStart.SelectedDate = DateTime.Today;
                DpEnd.SelectedDate = DateTime.Today.AddDays(1);
            }
        }

        private void BtnAkceptuj_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Urlop dla {pracownik2.Surname} został zatwierdzony.");
            this.Close();
        }

        private void BtnZamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
