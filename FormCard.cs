using System;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormCard : Form
    {
        private decimal totalPlata;

        public FormCard(decimal totalPlata)
        {
            InitializeComponent();
            this.totalPlata = totalPlata;

         
            labelMesaj.Text = "Apropie cardul";

            
            btnPlataFinalizata.Click += (s, e) => FinalizeazaPlata();
        }

        private void FinalizeazaPlata()
        {
            int puncteNoi = (int)(totalPlata / 10);

            Form1 formPrincipal = Application.OpenForms["Form1"] as Form1;
            if (formPrincipal != null)
            {
                formPrincipal.ActualizeazaPuncte(puncteNoi);
            }
            MessageBox.Show($"Plata finalizata! Ai castigat {puncteNoi} puncte.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DeschideFormBonFinal();
            this.Close();
        }

        private void DeschideFormBonFinal()
        {
           
            Random random = new Random();
            int numarComanda = random.Next(0, 100);
            FormBonFinal formBonFinal = new FormBonFinal();
            formBonFinal.AfiseazaBonPlataNormala(numarComanda);
            formBonFinal.Show();
        }
    }
}