using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SurvieCancer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Entree> listEntree = new List<Entree>();
            StreamReader fileRead = new StreamReader(@"res_neuron_apprentissage.txt");
            string[] lignes = fileRead.ReadToEnd().Split('\n');
            foreach (string ligne in lignes)
            {
                string[] values = ligne.Split(',');
                Entree newEntree = new Entree();
                for (int i=0; i<3 ; i++){
                    switch(i){
                        case 0 :
                            newEntree.SetAgePatient(Int32.Parse(values[i]));
                            break;
                        case 1 :
                            newEntree.SetAnneeOperation(Int32.Parse(values[i]));
                            break;
                        case 3 :
                            newEntree.SetNbGanglions(Int32.Parse(values[i]));
                            break;
                        default :
                            break;
                    }
                }
                listEntree.Add(newEntree);
            }
        }
    }
}
