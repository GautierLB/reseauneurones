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
        private const int nbInputs = 4;
        private double output;

        public Neurone()
        {
            Random rand = new Random();
            this.poids = new double[nbInputs];
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
            return 1.0 / (1.0 + Math.Exp(-1.0 * x));
        }

        public void setPoids(int pos, double value)
        {
            this.poids[pos] = value;
        }
    }
}
