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

        ReseauNeurone reseauAppri;

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
            reseauAppri = sys.Run();
            StartButton.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Entree patient = new Entree();
            patient.AgeAnneeGanglions[0] = Int32.Parse(TB_Age.Text);
            patient.AgeAnneeGanglions[1] = Int32.Parse(TB_Annee.Text);
            patient.AgeAnneeGanglions[2] = Int32.Parse(TB_nbGangl.Text);

            double result = reseauAppri.Evaluer(patient);
            double survie = reseauAppri.getSortie().getOutput();
            /*int survie = 3;
            if (result < 0.5)
            {
                survie = 0;
            }
            else
            {
                survie = 1;
            }*/
            BlockSortie.Text = survie.ToString();
            BlockSortie.Text = result.ToString();
        }
    }
}
