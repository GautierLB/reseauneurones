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
            this.RecupFichier();
        }
        public void RecupFichier()
        {
            Entree[] listEntree;
            StreamReader fileRead = new StreamReader(@"res_neuron_apprentissage.txt");
            string[] lignes = fileRead.ReadToEnd().Split('\n');
            listEntree = new Entree[lignes.Length];
            for (int i = 0; i < lignes.Length ; i++)
            {
                string[] values = lignes[i].Split(',');
                Entree newEntree = new Entree();
                for (int j = 0; j < 3; j++)
                {
                    newEntree.AgeAnneeGanglions[j] = Int32.Parse(values[j]);
                }
                listEntree[i] = newEntree;
            }
            Systeme sys = new Systeme(listEntree);
            sys.Run();

        }
    }
}
