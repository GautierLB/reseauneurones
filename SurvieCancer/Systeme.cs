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
        double ErreurMax = 0.005;
        double IterationMax = 100001;

        public Systeme(Entree[] _entrees)
        {
            entrees = new Entree[(int)Math.Ceiling(_entrees.Length * 0.7)];
            entreesVerif = new Entree[(int)Math.Ceiling(_entrees.Length * 0.3)];
            for (int i = 0; i < (int)Math.Ceiling(_entrees.Length * 0.7); i++)
            {
                this.entrees[i] = _entrees[i];
            }
            List<Entree> list = new List<Entree>(entrees);
            this.Shuffle(list);
            entrees = list.ToArray();
            int a =0;
            for (int j = (int)Math.Ceiling(_entrees.Length * 0.7); j < _entrees.Length ; j++)
            {
                this.entreesVerif[a] = _entrees[j];
                a++;
            }
            this.reseau = new ReseauNeurone();
        }

        public void Shuffle<T>(IList<T> list)
        {
            System.Random rng = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public ReseauNeurone Run()
        {
            int i = 0;
            double ErreurTotal = Double.PositiveInfinity;
            Boolean GenralisationEstMeilleur = true;
            double ErreurPrev = Double.PositiveInfinity;
            double ErreurGeneralisationTotal = Double.PositiveInfinity;
            double ErreurGeneralisationPrev = Double.PositiveInfinity;
            

            while (i < IterationMax && ErreurTotal > ErreurMax && GenralisationEstMeilleur)
            {
                ErreurPrev = ErreurTotal;
                ErreurTotal = 0;
                ErreurGeneralisationPrev = ErreurGeneralisationTotal;
                ErreurGeneralisationTotal = 0;

                // Evaluate
                foreach (Entree entree in entrees)
                {
                    double sorties = reseau.Evaluer(entree);
                    double erreur = entree.getSortie() - sorties;
                    ErreurTotal += (erreur * erreur);
                    
                    //retro-propagation
                    reseau.AjusterPoids(entree, tauxApprentissage);
                }

                //Généralisation
                foreach (Entree entree in entreesVerif)
                {
                    double sorties = reseau.Evaluer(entree);
                    double erreur = entree.getSortie() - sorties;
                    ErreurGeneralisationTotal += (erreur * erreur);
                }

                if(ErreurGeneralisationTotal > ErreurGeneralisationPrev)
                {
                    GenralisationEstMeilleur = false;
                }

                //Affinement du taux
                if (ErreurTotal >= ErreurPrev)
                {
                    tauxApprentissage = tauxApprentissage / 2.0;    
                }

                //Console.WriteLine("Iteration n°" + i + " - Erreur Total : " + ErreurTotal + " - Erreur de génération : " + ErreurGeneralisationTotal + " - Taux : " + tauxApprentissage);

                i++;
            }
            return reseau;
        }
    }
}