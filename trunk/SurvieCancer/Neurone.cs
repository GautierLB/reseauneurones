using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvieCancer
{
    class Neurone
    {
        private double[] poids;
        private const int nbInputs = 3;
        private double sortie;

        public Neurone()
        {
            Random rand = new Random();
            this.poids = new double[nbInputs+1];
            for (int i = 0; i <= nbInputs; i++)
            {
                poids[i] = rand.NextDouble();
            }
        }

        public double Evaluer(double[] entree)
        {
            double x = 0.0;
            for (int i = 0; i < entree.Length; i++)
            {
                x += entree[i] * poids[i];
            }
            x += poids[nbInputs];
            this.sortie = 1.0 / (1.0 + Math.Exp(-1.0 * x));
            return (sortie);
        }

        public void setPoids(int pos, double value)
        {
            this.poids[pos] = value;
        }
        public double getPoids(int index)
        {
            return (this.poids[index]);
        }

        public double getOutput()
        {
            return (this.sortie);
        }
    }
}
