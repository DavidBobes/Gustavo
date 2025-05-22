using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormDineOption : Form
    {
        private Form1 mainForm;
        private decimal totalPlata;
        private ListView listViewComanda;

        public FormDineOption(Form1 mainForm, ListView listViewComanda, decimal totalPlata)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.listViewComanda = listViewComanda;
            this.totalPlata = totalPlata;

            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Alegeti optiunea de servire";

            Label lblQuestion = new Label
            {
                Text = "Unde doriti sa serviti comanda?",
                Font = new Font("Britannic Bold", 24, FontStyle.Bold),
                AutoSize = true
            };
            lblQuestion.Location = new Point((this.ClientSize.Width - lblQuestion.PreferredWidth) / 2, 30);
            this.Controls.Add(lblQuestion);

            
            Button btnDineIn = new Button
            {
                Size = new Size(250, 250),
                Location = new Point(100, 100),
                FlatStyle = FlatStyle.Flat
            };

            PictureBox picDineIn = new PictureBox
            {
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ImageLocation = Path.Combine("C:\\Users\\Davidd\\Downloads\\Casa-Self-Pay-Gustavo---Aplicatie-main\\Casa-Self-Pay-Gustavo---Aplicatie-main\\Resources", "restaurant.jpg"),
                Location = new Point(25, 25)
            };
            btnDineIn.Controls.Add(picDineIn);

            Label lblDineIn = new Label
            {
                Text = "Servire în restaurant",
                Font = new Font("Britannic Bold", 12, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblDineIn.Location = new Point(100 + (250 - lblDineIn.PreferredWidth) / 2, 360);
            this.Controls.Add(lblDineIn);
            this.Controls.Add(btnDineIn);

            
            Button btnTakeOut = new Button
            {
                Size = new Size(250, 250),
                Location = new Point(450, 100),
                FlatStyle = FlatStyle.Flat
            };

            PictureBox picTakeOut = new PictureBox
            {
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.StretchImage,
                ImageLocation = Path.Combine("C:\\Users\\Davidd\\Downloads\\Casa-Self-Pay-Gustavo---Aplicatie-main\\Casa-Self-Pay-Gustavo---Aplicatie-main\\Resources", "takeout.jpg"), 
                Location = new Point(25, 25)
            };
            btnTakeOut.Controls.Add(picTakeOut);

            Label lblTakeOut = new Label
            {
                Text = "La pachet",
                Font = new Font("Britannic Bold", 12, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblTakeOut.Location = new Point(450 + (250 - lblTakeOut.PreferredWidth) / 2, 360);
            this.Controls.Add(lblTakeOut);
            this.Controls.Add(btnTakeOut);

            btnDineIn.Click += (s, e) =>
            {
                this.Hide();
                FormPlata formPlata = new FormPlata(listViewComanda, totalPlata.ToString());
                formPlata.ShowDialog();
                this.Close();
            };

            btnTakeOut.Click += (s, e) =>
            {
                this.Hide();
                FormPlata formPlata = new FormPlata(listViewComanda, totalPlata.ToString());
                formPlata.ShowDialog(); 
                this.Close();
            };

        }
    }
}
