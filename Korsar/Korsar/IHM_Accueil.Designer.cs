namespace Korsar
{
    partial class IHM_Accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_jouer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_jouer
            // 
            this.b_jouer.Location = new System.Drawing.Point(241, 381);
            this.b_jouer.Name = "b_jouer";
            this.b_jouer.Size = new System.Drawing.Size(242, 68);
            this.b_jouer.TabIndex = 0;
            this.b_jouer.Text = "Jouer";
            this.b_jouer.UseVisualStyleBackColor = true;
            this.b_jouer.Click += new System.EventHandler(this.b_jouer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.b_jouer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_jouer;
    }
}

