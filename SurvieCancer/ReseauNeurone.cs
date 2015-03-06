$using System;
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

        public ReseauNeurone()
        {
            this.neurones = new Neurone[4];
            this.sortie = new Neurone();
        }
    }
}
