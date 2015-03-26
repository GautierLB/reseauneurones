using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvieCancer
{
    class ReseauNeurone
    {    
        private Neurone sortie;
        private const int nbNeuronesCachés =3;
        private Neurone[] neurones = new Neurone[nbNeuronesCachés];
        private const int nbEntree = 3;

        public Neurone getSortie()
        {
            return sortie;
        }

        public ReseauNeurone()
        {
            for (int i = 0; i < nbNeuronesCachés; i++)
            {
                this.neurones[i] = new Neurone();
            }
            this.sortie = new Neurone();
        }

        public int Evaluer(Entree entree)
        {
            int resultat = new Int16();
            double[] sortiesNeurones = new double[nbNeuronesCachés];
            for (int i = 0; i < nbNeuronesCachés; i++)
            {
                sortiesNeurones[i] = neurones[i].Evaluer(entree.AgeAnneeGanglions);
            }
            if (this.sortie.Evaluer(sortiesNeurones) > 0.5)
            {
                resultat = 2;
            }
            else
            {
                resultat = 1;
            }
            //Console.WriteLine(this.sortie.Evaluer(sortiesNeurones).ToString());
            return resultat;
            
        }

        public void AjusterPoids(Entree _critere ,double _TauxAppentissage)
        {
            //Calculer le delta du neurone de sortie
            double sortieReelle = sortie.getOutput();
            double sortieAttendue = _critere.getSortie();
            double deltaSortie = sortieReelle * (1 - sortieReelle) * (sortieAttendue - sortieReelle);

            //Calculer les deltas des neurones cachés
            double[] deltaNeuroneCaches = new double[nbNeuronesCachés];
            for (int i = 0; i < nbNeuronesCachés; i++)
            {
                double sortieDuNeuroneCache = neurones[i].getOutput();
                double sum = 0.0;
                sum += deltaSortie * sortie.getPoids(i);
                deltaNeuroneCaches[i] = sortieDuNeuroneCache * (1 - sortieDuNeuroneCache) * sum;
            }

            //Ajuster les poids du neurone de sortie
            double value;
            Neurone neuroneSortie = sortie;
            for (int i = 0; i < nbNeuronesCachés; i++)
            {
                value = neuroneSortie.getPoids(i) + _TauxAppentissage * deltaSortie * neurones[i].getOutput();
                neuroneSortie.setPoids(i,value);
            }
            //Gestion du Seuil
            value = neuroneSortie.getPoids(nbNeuronesCachés) + _TauxAppentissage * deltaSortie * 1.0;
            neuroneSortie.setPoids(nbNeuronesCachés, value);

            //Ajustement du poids des neurones cachés
            for (int i = 0; i < nbNeuronesCachés; i++)
            {
                Neurone neuroneCache = neurones[i];
                for (int j = 0; j < nbEntree; j++)
                {
                    value = neuroneCache.getPoids(j) + _TauxAppentissage * deltaNeuroneCaches[i] * _critere.AgeAnneeGanglions[j];
                    neuroneCache.setPoids(j, value);
                }
                //Gestion du seuil
                value = neuroneCache.getPoids(nbEntree) + _TauxAppentissage * deltaNeuroneCaches[i] * 1.0;
                neuroneCache.setPoids(nbEntree, value);
            }
        }
    }
}
