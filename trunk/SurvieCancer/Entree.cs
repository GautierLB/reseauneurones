using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvieCancer
{
    class Entree
    {
        public double[] AgeAnneeGanglions = new double[3];
        private double sortie = new double();

        public void setSortie(double sortieRecue)
        {
            this.sortie = sortieRecue;
        }
        public double getSortie()
        {
            return (this.sortie);
        }

        public Entree()
        {
            this.AgeAnneeGanglions[0] = 0;
            this.AgeAnneeGanglions[1] = 0;
            this.AgeAnneeGanglions[2] = 0;
            this.sortie = 0;
        }
    }

}
