using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvieCancer
{
    class Entree
    {
        private int agePatient;

        public void SetAgePatient(int age)
        {
            this.agePatient = age;
        }

        private int anneeOperation;

        public void SetAnneeOperation(int annee)
        {
            this.anneeOperation = annee;
        }
        
        private int nbGanglions;

        public void SetNbGanglions(int nombre)
        {
            this.nbGanglions = nombre;
        }

        public Entree()
        {
            this.agePatient = 0;
            this.anneeOperation = 0;
            this.nbGanglions = 0;
        }
    }

}
