using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormBon : Form
    {
        private decimal totalPlata;

        public FormBon(ListView listViewComanda, string total)
        {
            InitializeComponent();

            foreach (ListViewItem item in listViewComanda.Items)
            {
                listBoxBon.Items.Add($"{item.Text} - {item.SubItems[1].Text} x {item.SubItems[2].Text} lei");
            }
            totalPlata = decimal.Parse(total.Replace("Total: ", "").Replace(" lei", ""));
            labelTotal.Text = $"Total: {totalPlata} lei";
            btnPlataFinalizata.Click += (s, e) => FinalizeazaPlata();
        }

        private void FinalizeazaPlata()
        {
            int puncteNoi = (int)(totalPlata / 10);
            Form1 formPrincipal = Application.OpenForms["Form1"] as Form1;
            if (formPrincipal != null)
            {
                formPrincipal.ActualizeazaPuncte(puncteNoi);
                formPrincipal.ClearComanda(); // Add this line to clear the ListView
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