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
        ReseauNeurone reseau;


        double tauxApprentissage = 0.3;

        public Systeme(Entree[] _entrees)
        {
            this.entrees = _entrees;
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