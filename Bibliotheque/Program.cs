using Domaine;
using IHM;
using NHibernate;
using Persistance;
using Service;
using System;
using System.Windows.Forms;

namespace Bibliotheque
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            // initialiser la couche de persistance
            ISessionFactory sessionFactory = ORM<Adherent>.CreateSessionFactory();
            IDataAccess dataAccess = new DataAccess(sessionFactory);

            // initialiser la couche applicative
            ServiceExemplaires  serviceExemplaires = new ServiceExemplaires(dataAccess);
            ServiceAdherents    serviceAdherents   = new ServiceAdherents(dataAccess);
            ServiceOuvrages     serviceOuvrages    = new ServiceOuvrages(dataAccess);
            ServicePrets        servicePrets       = new ServicePrets(dataAccess);

            // initializer la couche de presentation
            Fenetre vue = new Fenetre(serviceAdherents, serviceOuvrages, servicePrets, serviceExemplaires);
         
            // demarrer le logiciel
            Application.EnableVisualStyles();
            Application.Run(vue);

            // liberer les ressources
            dataAccess.Dispose();
            sessionFactory.Dispose();
        }
    }
}
