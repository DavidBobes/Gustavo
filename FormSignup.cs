using System;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
            btnSignup.Click += (s, e) => CreeazaCont();
            btnAscundeArata.Click += (s, e) => ComutaVizibilitateParola();
        }

        private void CreeazaCont()
        {
            string nume = textBoxNume.Text;
            string parola = textBoxParola.Text;

            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(parola))
            {
                MessageBox.Show("Numele și parola nu pot fi goale!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form1 formPrincipal = Application.OpenForms["Form1"] as Form1;
            if (formPrincipal != null)
            {
                if (formPrincipal.CreeazaCont(nume, parola, 0))
                {
                    MessageBox.Show("Contul a fost creat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    DeschideFormLogin();
                }
            }
        }

        private void DeschideFormLogin()
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog(this);
        }

        private void ComutaVizibilitateParola()
        {
            if (textBoxParola.PasswordChar == '*')
            {
                textBoxParola.PasswordChar = '\0';
                btnAscundeArata.Text = "Ascunde";
            }
            else
            {
                textBoxParola.PasswordChar = '*';
                btnAscundeArata.Text = "Arată";
            }
        }
    }
}