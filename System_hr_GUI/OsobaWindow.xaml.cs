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

        //Metoda do czyszczenia pola tekstowego z bledami
        private void ResetujBledy()
        {
            lblError.Text = "";
        }
    }
}
