using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Adherent
    {
        public virtual int Id { get; set; }

        public virtual String Nom { get; set; }

        public virtual IList<Pret> Prets { get; set; }

        public Adherent()
        {
            this.Prets = new List<Pret>();
        }

        public virtual Pret Emprunte(Exemplaire exemplaire)
        {
            if(exemplaire.EstDisponible())
            {
                Pret pret = new Pret { Exemplaire = exemplaire };
                pret.Exemplaire.Adherent = this;
                this.Prets.Add(pret);
                return pret;
            }
            throw new Exception("Le livre n'est pas disponible !");
        }

        public virtual void Retourne(Exemplaire exemplaire)
        {
            if(exemplaire == Prets[this.Prets.Count-1].Exemplaire)
            {
                Prets[this.Prets.Count - 1].DateRetour = DateTime.Now;
                Prets[this.Prets.Count - 1].Exemplaire.Adherent = null;
            }
            else
            {
                throw new Exception("Vous n'avez pas emprunté ce livre !");
            }
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
