namespace IHM
{
    partial class Fenetre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonModifierOuvrage = new System.Windows.Forms.Button();
            this.buttonSupprimerOuvrage = new System.Windows.Forms.Button();
            this.listBoxOuvrages = new System.Windows.Forms.ListBox();
            this.listBoxPrets = new System.Windows.Forms.ListBox();
            this.labelPrets = new System.Windows.Forms.Label();
            this.labelOuvrages = new System.Windows.Forms.Label();
            this.listBoxAdherents = new System.Windows.Forms.ListBox();
            this.labelAdherent = new System.Windows.Forms.Label();
            this.buttonAjouterAdherent = new System.Windows.Forms.Button();
            this.buttonModifierAdherent = new System.Windows.Forms.Button();
            this.buttonSupprimerAdherent = new System.Windows.Forms.Button();
            this.buttonAjouterOuvrage = new System.Windows.Forms.Button();
            this.listBoxExemplaires = new System.Windows.Forms.ListBox();
            this.labelExemplaires = new System.Windows.Forms.Label();
            this.buttonEmprunter = new System.Windows.Forms.Button();
            this.buttonRetourner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonModifierOuvrage
            // 
            this.buttonModifierOuvrage.Location = new System.Drawing.Point(263, 71);
            this.buttonModifierOuvrage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonModifierOuvrage.Name = "buttonModifierOuvrage";
            this.buttonModifierOuvrage.Size = new System.Drawing.Size(100, 28);
            this.buttonModifierOuvrage.TabIndex = 1;
            this.buttonModifierOuvrage.Text = "Modifier";
            this.buttonModifierOuvrage.UseVisualStyleBackColor = true;
            // 
            // buttonSupprimerOuvrage
            // 
            this.buttonSupprimerOuvrage.Location = new System.Drawing.Point(263, 107);
            this.buttonSupprimerOuvrage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSupprimerOuvrage.Name = "buttonSupprimerOuvrage";
            this.buttonSupprimerOuvrage.Size = new System.Drawing.Size(100, 28);
            this.buttonSupprimerOuvrage.TabIndex = 2;
            this.buttonSupprimerOuvrage.Text = "Supprimer";
            this.buttonSupprimerOuvrage.UseVisualStyleBackColor = true;
            // 
            // listBoxOuvrages
            // 
            this.listBoxOuvrages.FormattingEnabled = true;
            this.listBoxOuvrages.ItemHeight = 16;
            this.listBoxOuvrages.Location = new System.Drawing.Point(16, 36);
            this.listBoxOuvrages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxOuvrages.Name = "listBoxOuvrages";
            this.listBoxOuvrages.Size = new System.Drawing.Size(223, 100);
            this.listBoxOuvrages.TabIndex = 4;
            this.listBoxOuvrages.SelectedIndexChanged += new System.EventHandler(this.listBoxOuvrages_SelectedIndexChanged);
            // 
            // listBoxPrets
            // 
            this.listBoxPrets.FormattingEnabled = true;
            this.listBoxPrets.ItemHeight = 16;
            this.listBoxPrets.Location = new System.Drawing.Point(385, 191);
            this.listBoxPrets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxPrets.Name = "listBoxPrets";
            this.listBoxPrets.Size = new System.Drawing.Size(343, 100);
            this.listBoxPrets.TabIndex = 5;
            // 
            // labelPrets
            // 
            this.labelPrets.AutoSize = true;
            this.labelPrets.Location = new System.Drawing.Point(381, 170);
            this.labelPrets.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrets.Name = "labelPrets";
            this.labelPrets.Size = new System.Drawing.Size(49, 17);
            this.labelPrets.TabIndex = 6;
            this.labelPrets.Text = "Prets :";
            // 
            // labelOuvrages
            // 
            this.labelOuvrages.AutoSize = true;
            this.labelOuvrages.Location = new System.Drawing.Point(12, 15);
            this.labelOuvrages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOuvrages.Name = "labelOuvrages";
            this.labelOuvrages.Size = new System.Drawing.Size(78, 17);
            this.labelOuvrages.TabIndex = 7;
            this.labelOuvrages.Text = "Ouvrages :";
            // 
            // listBoxAdherents
            // 
            this.listBoxAdherents.FormattingEnabled = true;
            this.listBoxAdherents.ItemHeight = 16;
            this.listBoxAdherents.Location = new System.Drawing.Point(385, 36);
            this.listBoxAdherents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxAdherents.Name = "listBoxAdherents";
            this.listBoxAdherents.Size = new System.Drawing.Size(223, 100);
            this.listBoxAdherents.TabIndex = 8;
            this.listBoxAdherents.SelectedIndexChanged += new System.EventHandler(this.listBoxAhderents_SelectedIndexChanged);
            // 
            // labelAdherent
            // 
            this.labelAdherent.AutoSize = true;
            this.labelAdherent.Location = new System.Drawing.Point(381, 15);
            this.labelAdherent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAdherent.Name = "labelAdherent";
            this.labelAdherent.Size = new System.Drawing.Size(81, 17);
            this.labelAdherent.TabIndex = 9;
            this.labelAdherent.Text = "Adhèrents :";
            // 
            // buttonAjouterAdherent
            // 
            this.buttonAjouterAdherent.Location = new System.Drawing.Point(629, 36);
            this.buttonAjouterAdherent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAjouterAdherent.Name = "buttonAjouterAdherent";
            this.buttonAjouterAdherent.Size = new System.Drawing.Size(100, 28);
            this.buttonAjouterAdherent.TabIndex = 10;
            this.buttonAjouterAdherent.Text = "Ajouter";
            this.buttonAjouterAdherent.UseVisualStyleBackColor = true;
            // 
            // buttonModifierAdherent
            // 
            this.buttonModifierAdherent.Location = new System.Drawing.Point(629, 71);
            this.buttonModifierAdherent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonModifierAdherent.Name = "buttonModifierAdherent";
            this.buttonModifierAdherent.Size = new System.Drawing.Size(100, 28);
            this.buttonModifierAdherent.TabIndex = 11;
            this.buttonModifierAdherent.Text = "Modifier";
            this.buttonModifierAdherent.UseVisualStyleBackColor = true;
            // 
            // buttonSupprimerAdherent
            // 
            this.buttonSupprimerAdherent.Location = new System.Drawing.Point(629, 107);
            this.buttonSupprimerAdherent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSupprimerAdherent.Name = "buttonSupprimerAdherent";
            this.buttonSupprimerAdherent.Size = new System.Drawing.Size(100, 28);
            this.buttonSupprimerAdherent.TabIndex = 12;
            this.buttonSupprimerAdherent.Text = "Supprimer";
            this.buttonSupprimerAdherent.UseVisualStyleBackColor = true;
            // 
            // buttonAjouterOuvrage
            // 
            this.buttonAjouterOuvrage.Location = new System.Drawing.Point(263, 36);
            this.buttonAjouterOuvrage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAjouterOuvrage.Name = "buttonAjouterOuvrage";
            this.buttonAjouterOuvrage.Size = new System.Drawing.Size(100, 28);
            this.buttonAjouterOuvrage.TabIndex = 13;
            this.buttonAjouterOuvrage.Text = "Ajouter";
            this.buttonAjouterOuvrage.UseVisualStyleBackColor = true;
            // 
            // listBoxExemplaires
            // 
            this.listBoxExemplaires.FormattingEnabled = true;
            this.listBoxExemplaires.ItemHeight = 16;
            this.listBoxExemplaires.Location = new System.Drawing.Point(16, 191);
            this.listBoxExemplaires.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxExemplaires.Name = "listBoxExemplaires";
            this.listBoxExemplaires.Size = new System.Drawing.Size(223, 100);
            this.listBoxExemplaires.TabIndex = 14;
            this.listBoxExemplaires.SelectedIndexChanged += new System.EventHandler(this.listBoxExemplaires_SelectedIndexChanged);
            // 
            // labelExemplaires
            // 
            this.labelExemplaires.AutoSize = true;
            this.labelExemplaires.Location = new System.Drawing.Point(16, 170);
            this.labelExemplaires.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExemplaires.Name = "labelExemplaires";
            this.labelExemplaires.Size = new System.Drawing.Size(92, 17);
            this.labelExemplaires.TabIndex = 15;
            this.labelExemplaires.Text = "Exemplaires :";
            // 
            // buttonEmprunter
            // 
            this.buttonEmprunter.Location = new System.Drawing.Point(263, 191);
            this.buttonEmprunter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEmprunter.Name = "buttonEmprunter";
            this.buttonEmprunter.Size = new System.Drawing.Size(100, 28);
            this.buttonEmprunter.TabIndex = 16;
            this.buttonEmprunter.Text = "Emprunter";
            this.buttonEmprunter.UseVisualStyleBackColor = true;
            this.buttonEmprunter.Click += new System.EventHandler(this.buttonEmprunter_Click);
            // 
            // buttonRetourner
            // 
            this.buttonRetourner.Location = new System.Drawing.Point(263, 226);
            this.buttonRetourner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRetourner.Name = "buttonRetourner";
            this.buttonRetourner.Size = new System.Drawing.Size(100, 28);
            this.buttonRetourner.TabIndex = 17;
            this.buttonRetourner.Text = "Retourner";
            this.buttonRetourner.UseVisualStyleBackColor = true;
            this.buttonRetourner.Click += new System.EventHandler(this.buttonRetourner_Click);
            // 
            // Fenetre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 305);
            this.Controls.Add(this.buttonRetourner);
            this.Controls.Add(this.buttonEmprunter);
            this.Controls.Add(this.labelExemplaires);
            this.Controls.Add(this.listBoxExemplaires);
            this.Controls.Add(this.buttonAjouterOuvrage);
            this.Controls.Add(this.buttonSupprimerAdherent);
            this.Controls.Add(this.buttonModifierAdherent);
            this.Controls.Add(this.buttonAjouterAdherent);
            this.Controls.Add(this.labelAdherent);
            this.Controls.Add(this.listBoxAdherents);
            this.Controls.Add(this.labelOuvrages);
            this.Controls.Add(this.labelPrets);
            this.Controls.Add(this.listBoxPrets);
            this.Controls.Add(this.listBoxOuvrages);
            this.Controls.Add(this.buttonSupprimerOuvrage);
            this.Controls.Add(this.buttonModifierOuvrage);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Fenetre";
            this.Text = "Bibliothèque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonModifierOuvrage;
        private System.Windows.Forms.Button buttonSupprimerOuvrage;
        private System.Windows.Forms.ListBox listBoxOuvrages;
        private System.Windows.Forms.ListBox listBoxPrets;
        private System.Windows.Forms.Label labelPrets;
        private System.Windows.Forms.Label labelOuvrages;
        private System.Windows.Forms.Label labelAdherent;
        private System.Windows.Forms.Button buttonModifierAdherent;
        private System.Windows.Forms.Button buttonSupprimerAdherent;
        private System.Windows.Forms.Button buttonAjouterAdherent;
        private System.Windows.Forms.ListBox listBoxAdherents;
        private System.Windows.Forms.Button buttonAjouterOuvrage;
        private System.Windows.Forms.ListBox listBoxExemplaires;
        private System.Windows.Forms.Label labelExemplaires;
        private System.Windows.Forms.Button buttonEmprunter;
        private System.Windows.Forms.Button buttonRetourner;
    }
}

