using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvieCancer
{
    class ReseauNeurone
    {
        private Neurone[] neurones;
        private Neurone sortie;
        private const int nbNeurones =3;

        public ReseauNeurone()
        {
            for (int i = 0; i < nbNeurones; i++)
            {
                this.neurones[i] = new Neurone();
            }
            this.sortie = new Neurone();
        }

        internal double Evaluer(Entree entree)
        {
            double[] sortiesNeurones = new double[nbNeurones];
            for (int i = 0; i < nbNeurones; i++)
            {
                sortiesNeurones[i] = neurones[i].Evaluer(entree.AgeAnneeGanglions);
            }
            double resultat = this.sortie.Evaluer(sortiesNeurones);

            return resultat;
        }

    }
}
