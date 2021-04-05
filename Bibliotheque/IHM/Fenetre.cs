using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domaine;
using Service;

namespace IHM
{
    public partial class Fenetre : Form
    {
        ServiceExemplaires  serviceExemplaires;
        ServiceAdherents    serviceAdherents;
        ServiceOuvrages     serviceOuvrages;
        ServicePrets        servicePrets;

        List<Exemplaire> exemplaires;
        List<Adherent>   adherents;
        List<Ouvrage>    ouvrages;
        List<Pret>       prets;

        public Fenetre(ServiceAdherents adherents, ServiceOuvrages ouvrages, ServicePrets prets, ServiceExemplaires exemplaires)
        {
            InitializeComponent();

            InitialiserServices(adherents, ouvrages, prets, exemplaires);
            ActualiserAdherents();
            ActualiserOuvrages();
            ActualiserPrets();
        }

        void InitialiserServices(ServiceAdherents adherents, ServiceOuvrages ouvrages, ServicePrets prets, ServiceExemplaires exemplaires)
        {
            serviceExemplaires = exemplaires;
            serviceAdherents  = adherents;
            serviceOuvrages   = ouvrages;
            servicePrets      = prets;
        }

        void ActualiserAdherents()
        {
            adherents = serviceAdherents.ObtenirListe();
            AfficherListe(adherents, listBoxAdherents);
            ActualiserPrets();
        }

        void ActualiserOuvrages()
        {
            ouvrages = serviceOuvrages.ObtenirListe();
            AfficherListe(ouvrages, listBoxOuvrages);
            ActualiserExemplaires();
        }

        void ActualiserPrets()
        {
            // 1. Recuperer l'identifiant de l'adherent selectionné
            int idx = listBoxAdherents.SelectedIndex;

            // 2. Recuperer la liste des prets associés à l'adherent
            prets = servicePrets.ObtenirListeParAdherent(idx);

            // 3. Afficher la liste des prets
            AfficherListe(prets, listBoxPrets);
        }

        void ActualiserExemplaires()
        {
            // 1. Recuperer l'identifiant de l'ouvrage selectionné
            int idx = listBoxOuvrages.SelectedIndex;

            // 2. Recuperer la liste des exemplaires associés à l'ouvrage
            exemplaires = serviceExemplaires.ObtenirListeParOuvrage(idx);

            // 3. Afficher la liste des exemplaires
            AfficherListe(exemplaires, listBoxExemplaires);
        }

        private void listBoxOuvrages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualiserExemplaires();
        }

        private void listBoxAhderents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualiserPrets();
        }

        void AfficherListe<T>(List<T> items, ListBox box)
        {
            List<string> liste = new List<string>();
            foreach (T a in items)
                liste.Add(a.ToString());
            box.DataSource = liste;
        }

        private void buttonEmprunter_Click(object sender, EventArgs e)
        {
            // 1. Recuperer l'identifiant de l'adherent selectionné
            int idAdherent = listBoxAdherents.SelectedIndex;

            // 2. Recuperer l'identifiant de l'exemplaire selectionné
            int idExemplaire = listBoxExemplaires.SelectedIndex;

            try
            {
                // 3. Execution de l'emprunt
                servicePrets.TraiterEmprunt(idAdherent, idExemplaire);
                // 4. Mis à jour de l'IHM
                ActualiserPrets();

            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message, "Emprunt échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRetourner_Click(object sender, EventArgs e)
        {
            // 1. Recuperer l'identifiant de l'exemplaire selectionné
            int idExemplaire = listBoxExemplaires.SelectedIndex;

            try
            {
                // 2. Execution du retour
                servicePrets.TraiterRetour(idExemplaire);

                // 3. Mis à jour de l'IHM
                ActualiserPrets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Retour échoué", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxExemplaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualiserExemplaires();
        }
    }
}
