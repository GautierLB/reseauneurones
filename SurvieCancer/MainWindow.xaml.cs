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
            List<Entree> listEntree = new List<Entree>();
            StreamReader fileRead = new StreamReader(@"res_neuron_apprentissage.txt");
            string[] lignes = fileRead.ReadToEnd().Split('\n');
            foreach (string ligne in lignes)
            {
                string[] values = ligne.Split(',');
                Entree newEntree = new Entree();
                for (int i = 0; i < 3; i++)
                {
                    newEntree.AgeAnneeGanglions[i] = Int32.Parse(values[i]);
                }
                listEntree.Add(newEntree);
            }
        }
    }
}
