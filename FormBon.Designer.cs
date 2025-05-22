namespace Proiect
{
    partial class FormBon
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
            this.labelTotal = new System.Windows.Forms.Label();
            this.listBoxBon = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPlataFinalizata = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Britannic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(13)))), ((int)(((byte)(6)))));
            this.labelTotal.Location = new System.Drawing.Point(23, 90);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(119, 41);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "label1";
            // 
            // listBoxBon
            // 
            this.listBoxBon.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxBon.Font = new System.Drawing.Font("Agency FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxBon.FormattingEnabled = true;
            this.listBoxBon.ItemHeight = 24;
            this.listBoxBon.Location = new System.Drawing.Point(381, 90);
            this.listBoxBon.Name = "listBoxBon";
            this.listBoxBon.Size = new System.Drawing.Size(192, 340);
            this.listBoxBon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(13)))), ((int)(((byte)(6)))));
            this.label1.Location = new System.Drawing.Point(393, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Comanda ta:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(13)))), ((int)(((byte)(6)))));
            this.label2.Location = new System.Drawing.Point(12, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Introdu banii in aparat!";
            // 
            // btnPlataFinalizata
            // 
            this.btnPlataFinalizata.BackColor = System.Drawing.SystemColors.Info;
            this.btnPlataFinalizata.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlataFinalizata.Location = new System.Drawing.Point(245, 405);
            this.btnPlataFinalizata.Name = "btnPlataFinalizata";
            this.btnPlataFinalizata.Size = new System.Drawing.Size(130, 30);
            this.btnPlataFinalizata.TabIndex = 4;
            this.btnPlataFinalizata.Text = "Plata finalizata";
            this.btnPlataFinalizata.UseVisualStyleBackColor = false;
            
            // 
            // FormBon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(585, 439);
            this.Controls.Add(this.btnPlataFinalizata);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxBon);
            this.Controls.Add(this.labelTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormBon";
            this.Text = "FormBon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.ListBox listBoxBon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPlataFinalizata;
    }
}