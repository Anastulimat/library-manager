using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Pret
    {
        public virtual int Id { get; set; }

        public virtual DateTime DateEmprunt { get; set; }

        public virtual DateTime DateRetour { get; set; }

        public virtual Exemplaire Exemplaire { get; set; }

        public Pret()
        {
            this.DateEmprunt = DateTime.Now;
        }

        public virtual bool EstTermine()
        {
            return this.Exemplaire.Adherent == null;
        }

        public override string ToString()
        {
            return Exemplaire.Ouvrage.Titre + " - DateEmprunt : " + DateEmprunt + " - DateRetour : " + DateRetour;
        }
    }
}
