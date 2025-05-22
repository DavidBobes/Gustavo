using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormBonFinal : Form
    {

        public FormBonFinal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ShowInTaskbar = false;  
        }


        public void AfiseazaBonPlataNormala(int numarComanda)
        {
            labelBon.Text = $"Comanda ta este numărul: {numarComanda}";
        }
        public void AfiseazaBonPlataCuPuncte(string numeProdus, int puncteCheltuite)
        {
            labelBon.Text = $"Ai cumparat {numeProdus} cu {puncteCheltuite} puncte.";
        }
        private void FormBonFinal_Load(object sender, EventArgs e)
        {
            
        }

        private void labelBon_Click(object sender, EventArgs e)
        {

        }
    }
}