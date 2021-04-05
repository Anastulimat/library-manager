using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Ouvrage
    {
        public virtual int Id { get; set; }

        public virtual String Auteur { get; set; }

        public virtual String Titre { get; set; }

        public Ouvrage()
        {

        }

        public override string ToString()
        {
            return Titre;
        }
    }
}
