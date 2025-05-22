namespace Proiect
{
    partial class FormPlata
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
            this.btnCard = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCard
            // 
            this.btnCard.BackgroundImage = global::Proiect.Properties.Resources.card;
            this.btnCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCard.Location = new System.Drawing.Point(324, 135);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(158, 121);
            this.btnCard.TabIndex = 1;
            this.btnCard.UseVisualStyleBackColor = true;
            // 
            // btnCash
            // 
            this.btnCash.BackgroundImage = global::Proiect.Properties.Resources.bani;
            this.btnCash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCash.Location = new System.Drawing.Point(129, 135);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(158, 121);
            this.btnCash.TabIndex = 0;
            this.btnCash.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alege metoda de plata:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPlata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(609, 423);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnCash);
            this.Name = "FormPlata";
            this.Text = "FormPlata";
            ///this.Load += new System.EventHandler(this.FormPlata_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Label label1;
    }
}