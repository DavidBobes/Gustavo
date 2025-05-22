using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormPlata : Form
    {
        private ListView listViewComanda;
        private decimal totalPlata; 

        public FormPlata(ListView listViewComanda, string total)
        {
            InitializeComponent();
            this.listViewComanda = listViewComanda;

            totalPlata = decimal.Parse(total.Replace("Total: ", "").Replace(" lei", ""));
            btnCash.Click += (s, e) => DeschideFormBon();

            btnCard.Click += (s, e) => DeschideFormCard();
        }

        private void DeschideFormBon()
        {
            
            FormBon formBon = new FormBon(listViewComanda, totalPlata.ToString("0.00"));
            formBon.ShowDialog();
            this.Close();
        }


        private void DeschideFormCard()
        {
            FormCard formCard = new FormCard(totalPlata);
            formCard.ShowDialog();
            this.Close();
        }
        
        
    }
}
