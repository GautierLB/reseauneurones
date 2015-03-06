using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvieCancer
{
    class entrée
    {
        private int agePatient;

        public int AgePatient
        {
            get { return agePatient; }
            set { agePatient = value; }
        }
        private int anneeOperation;

        public int AnneeOperation
        {
            get { return anneeOperation; }
            set { anneeOperation = value; }
        }
        private int nbGanglions;

        public int NbGanglions
        {
            get { return nbGanglions; }
            set { nbGanglions = value; }
        }
    }
}
