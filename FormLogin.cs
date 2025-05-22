using System;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            btnLogin.Click += (s, e) => Login();
            linkLabelCreeazaCont.Click += (s, e) => DeschideFormSignUp();
            btnAscundeArata.Click += (s, e) => ComutaVizibilitateParola();
        }

        private void Login()
        {
            string nume = textBoxNume.Text;
            string parola = textBoxParola.Text;

            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(parola))
            {
                MessageBox.Show("Vă rugăm completați toate câmpurile!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form1 formPrincipal = Application.OpenForms["Form1"] as Form1;
            if (formPrincipal != null)
            {
                int puncte;
                if (formPrincipal.VerificaLogin(nume, parola, out puncte))
                {
                    formPrincipal.UtilizatorLogat(nume, puncte);
                    MessageBox.Show("Login reușit!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nume sau parolă incorecte!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeschideFormSignUp()
        {
            FormSignUp formSignUp = new FormSignUp();
            this.Hide();
            formSignUp.ShowDialog();
            this.Close();
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
