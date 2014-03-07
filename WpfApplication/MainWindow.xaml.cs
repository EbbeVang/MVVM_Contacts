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

namespace WpfApplication
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // my viewmodel
        ViewModelContact viewModelContact = new ViewModelContact();

        public MainWindow()
        {
            InitializeComponent();
            // the magic trick...
            DataContext = viewModelContact;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModelContact.RemoveContact();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewModelContact.AddContact(BtnFirstName.Text, BtnLastName.Text, BtnEmail.Text);
        }
    }
}
