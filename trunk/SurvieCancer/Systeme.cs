using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvieCancer
{
    class Systeme
    {
        Entree[] entrees;
        Entree[] entreesVerif;
        ReseauNeurone reseau;


        double tauxApprentissage = 0.3;

        public Systeme(Entree[] _entrees)
        {
            entrees = new Entree[(int)Math.Ceiling(_entrees.Length * 0.7)];
            entreesVerif = new Entree[(int)Math.Ceiling(_entrees.Length * 0.3)];
            for (int i = 0; i < (int)Math.Ceiling(_entrees.Length * 0.7); i++)
            {
                this.entrees[i] = _entrees[i];
            }
            int a =0;
            for (int j = (int)Math.Ceiling(_entrees.Length * 0.7); j < _entrees.Length ; j++)
            {
                this.entreesVerif[a] = _entrees[j];
                a++;
            }
            this.reseau = new ReseauNeurone();
        }

        public void Run()
        {
            int i = 0;

            while (i < 10000)
            {
                // Evaluate
                foreach (Entree entree in entrees)
                {
                    double outputs = reseau.Evaluer(entree);
                }
                i++;
            }
        }
    }
}