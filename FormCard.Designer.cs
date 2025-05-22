namespace Proiect
{
    partial class FormCard
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
            this.labelMesaj = new System.Windows.Forms.Label();
            this.btnPlataFinalizata = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMesaj
            // 
            this.labelMesaj.BackColor = System.Drawing.SystemColors.Info;
            this.labelMesaj.Font = new System.Drawing.Font("Britannic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMesaj.Location = new System.Drawing.Point(10, 36);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(309, 62);
            this.labelMesaj.TabIndex = 0;
            this.labelMesaj.Text = "Apropiati cardul:";
            this.labelMesaj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlataFinalizata
            // 
            this.btnPlataFinalizata.BackColor = System.Drawing.SystemColors.Info;
            this.btnPlataFinalizata.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlataFinalizata.Location = new System.Drawing.Point(393, 12);
            this.btnPlataFinalizata.Name = "btnPlataFinalizata";
            this.btnPlataFinalizata.Size = new System.Drawing.Size(123, 39);
            this.btnPlataFinalizata.TabIndex = 2;
            this.btnPlataFinalizata.Text = "Plata finalizata";
            this.btnPlataFinalizata.UseVisualStyleBackColor = false;
            ///this.btnPlataFinalizata.Click += new System.EventHandler(this.btnPlataFinalizata_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proiect.Properties.Resources.apropie;
            this.pictureBox1.Location = new System.Drawing.Point(24, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(478, 318);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(528, 421);
            this.Controls.Add(this.btnPlataFinalizata);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelMesaj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCard";
            this.Text = "FormCard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelMesaj;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPlataFinalizata;
    }
}