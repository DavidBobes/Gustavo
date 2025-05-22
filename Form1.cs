using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Proiect
{
    public partial class Form1 : Form
    {
        private const float MARGIN_PERCENT = 0.02f; 
        private const float PRODUCT_WIDTH_PERCENT = 0.45f;
        
        public string NumeUtilizator { get; private set; }

        public int PuncteUtilizator { get; private set; }

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["AccountsDb"].ConnectionString;
        }
        public bool CreeazaCont(string nume, string parola, int puncte)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                   
                    string checkQuery = "SELECT COUNT(*) FROM Accounts WHERE Name = @Name";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", nume);
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("Acest nume de utilizator există deja!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                   

                    string insertQuery = "INSERT INTO Accounts (Name, Password, Points) VALUES (@Name, @Password, @Points)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", nume);
                        cmd.Parameters.AddWithValue("@Password", parola);
                        cmd.Parameters.AddWithValue("@Points", puncte);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la crearea contului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool VerificaLogin(string nume, string parola, out int puncte)
        {
            puncte = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT Points FROM Accounts WHERE Name = @Name AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", nume);
                        cmd.Parameters.AddWithValue("@Password", parola);

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            puncte = Convert.ToInt32(result);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la autentificare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ActualizeazaPuncteInBazaDeDate(string nume, int puncte)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    string query = "UPDATE Accounts SET Points = @Points WHERE Name = @Name";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Points", puncte);
                        cmd.Parameters.AddWithValue("@Name", nume);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea punctelor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Form1()
        {
            InitializeComponent();

            AfiseazaEcranBineAiVenit();


            btnLogin.Click += (s, e) => DeschideFormLogin();

            listViewComanda.View = View.Details;



            btnMancare.Click += (s, e) => AfiseazaProduse(new List<Produs>
            {
                new Produs("Taco (150g)", "taco.jpeg", 30.00m),
                new Produs("Quesadilla (200g)", "quesadilla.jpeg", 20.00m),
                new Produs("Burrito (350g)", "burrito.jpeg", 25.00m),
                new Produs("Nachos (135g)", "nachos.jpeg", 18.50m)
            }, panelProduse);

            btnPuncte.Click += (s, e) => AfiseazaProdusePuncte(new List<Produs>
            {
            new Produs("Meniu Qsdilla", "meniuq.jpeg", 30),
            new Produs("Meniu Diabet", "meniud.jpeg", 25),
            new Produs("Meniu Burrito", "meniub.jpeg", 50),
             new Produs("Meniu Taco", "meniut.jpeg", 25)
            }, panelProduse);

            btnBauturi.Click += (s, e) => AfiseazaProduse(new List<Produs>
            {
                new Produs("Coca-Cola (400ml)", "cocacola.jpeg", 10.00m),
                new Produs("Fanta (400ml)", "fanta.jpeg", 10.00m),
                new Produs("Sprite (400ml)", "sprite.jpeg", 10.00m),
                new Produs("Bere (500ml)", "bere.jpeg", 10.00m)
            }, panelProduse);

            btnDesert.Click += (s, e) => AfiseazaProduse(new List<Produs>
            {
                new Produs("Înghetata", "icecream.jpeg", 15.00m),
                new Produs("Churros", "churros.jpeg", 20.00m),
                new Produs("Mexican Flan", "mexican flan.jpeg", 27.50m)
            }, panelProduse);

            btnSosuri.Click += (s, e) => AfiseazaProduse(new List<Produs>
            {
                new Produs("Ketchup (10g)", "ketchup.jpeg", 5.00m),
                new Produs("Maioneza (10g)", "mayo.jpeg", 5.00m),
                new Produs("BBQ (10g)", "bbqsauce.jpeg", 5.00m),
                new Produs("Cheddar (10g)", "cheddar.jpeg", 5.00m)
            }, panelProduse);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeControls();
        }

        private void AfiseazaProdusePuncte(List<Produs> produse, Panel panel)
        {
            panel.Controls.Clear();
            btnPuncte.Visible = true;  
            panel.Controls.Add(CreateGoBackButton());


            int yOffset = 10; 
            int imageWidth = 175;  
            int imageHeight = 175; 
            int spacing = 20; 
            int columnWidth = panel.Width / 2 - spacing; 
            int leftX = 10; 
            int rightX = leftX + columnWidth + spacing; 

            for (int i = 0; i < produse.Count; i++)
            {
                Produs produs = produse[i];

                
                int xPos = (i % 2 == 0) ? leftX : rightX;
                if (i % 2 == 0 && i > 0)
                    yOffset += imageHeight + 100; 

               
                Label labelProdus = new Label
                {
                    Text = produs.Nume,
                    AutoSize = true,
                    Font = new Font("Britannic bold", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(xPos, yOffset)
                };
                panel.Controls.Add(labelProdus);

                
                PictureBox pictureProdus = new PictureBox
                {
                    ImageLocation = Path.Combine("Resources", produs.Imagine),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(imageWidth, imageHeight),
                    Location = new Point(xPos, yOffset + labelProdus.Height + 10)
                };
                panel.Controls.Add(pictureProdus);

              
                Label labelPuncte = new Label
                {
                    Text = $"{produs.Pret} puncte",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Location = new Point(xPos, yOffset + labelProdus.Height + imageHeight + 10)
                };
                panel.Controls.Add(labelPuncte);

               
                Button btnCumpara = new Button
                {
                    Text = "Cumpără",
                    Size = new Size(75, 30),
                    Location = new Point(xPos, yOffset + labelProdus.Height + imageHeight + 40)
                };
                btnCumpara.Click += (s, e) => CumparaCuPuncte(produs);
                panel.Controls.Add(btnCumpara);
            }
        }

        private void ActualizeazaLabelPuncte()
        {
            labelUtilizator.Text = $"{NumeUtilizator} ({PuncteUtilizator} puncte)";
        }

        private void CumparaCuPuncte(Produs produs)
        {
            
            if (PuncteUtilizator >= produs.Pret)
            {
                
                PuncteUtilizator -= (int)produs.Pret;
                ActualizeazaPuncteInBazaDeDate(NumeUtilizator, PuncteUtilizator);

                ActualizeazaLabelPuncte();
                MessageBox.Show($"Ai cumpărat {produs.Nume} ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DeschideFormBonFinal(produs);
            }
            else
            {
                MessageBox.Show("Nu ai suficiente puncte pentru a cumpăra acest produs.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeschideFormLogin()
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void DeschideFormPlata()
        {
            decimal totalPlata = CalculeazaTotalComanda();
            FormPlata formPlata = new FormPlata(listViewComanda, totalPlata.ToString());
            formPlata.ShowDialog(this);

         
            listViewComanda.Items.Clear();
            txtTotal.Text = "0.00";
        }




        private decimal CalculeazaTotalComanda()
        {
            decimal total = 0;
            foreach (ListViewItem item in listViewComanda.Items)
            {
                total += decimal.Parse(item.SubItems[2].Text);
            }
            return total;
        }

        private void DeschideFormBonFinal(Produs produs)
        {
            using (FormBonFinal formBonFinal = new FormBonFinal())
            {
                formBonFinal.AfiseazaBonPlataCuPuncte(produs.Nume, (int)produs.Pret);
                formBonFinal.ShowDialog(this);

               
                listViewComanda.Items.Clear();
                txtTotal.Text = "0.00";
            }
        }




        private void AfiseazaProduse(List<Produs> produse, Panel panel)
        {
            panel.Controls.Clear();
            btnPuncte.Visible = true; 

            panel.Controls.Add(CreateGoBackButton());
            int yOffset = 10; 
            int imageWidth = 175;  
            int imageHeight = 175; 
            int spacing = 20;
            int columnWidth = panel.Width / 2 - spacing; 
            int leftX = 10;
            int rightX = leftX + columnWidth + spacing; 

            for (int i = 0; i < produse.Count; i++)
            {
                Produs produs = produse[i];
                int xPos = (i % 2 == 0) ? leftX : rightX;
                if (i % 2 == 0 && i > 0)
                    yOffset += imageHeight + 100; 
                Label labelProdus = new Label
                {
                    Text = produs.Nume,
                    AutoSize = true,
                    Font = new Font("Britannic bold", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(xPos, yOffset)
                };
                panel.Controls.Add(labelProdus);

                PictureBox pictureProdus = new PictureBox
                {
                    ImageLocation = Path.Combine("Resources", produs.Imagine),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(imageWidth, imageHeight),
                    Location = new Point(xPos, yOffset + labelProdus.Height + 10)
                };
                panel.Controls.Add(pictureProdus);
                Label labelPret = new Label
                {
                    Text = $"{produs.Pret} lei",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Location = new Point(xPos, yOffset + labelProdus.Height + imageHeight + 10)
                };
                panel.Controls.Add(labelPret);
                Button btnAdauga = new Button
                {
                    Text = "Adaugă",
                    Size = new Size(75, 30),
                    Location = new Point(xPos, yOffset + labelProdus.Height + imageHeight + 40)
                };
                btnAdauga.Click += (s, e) => AdaugaInComanda(produs);
                panel.Controls.Add(btnAdauga);
            }
        }

        private void AdaugaInComanda(Produs produs)
        { 
            ListViewItem item = listViewComanda.Items.Cast<ListViewItem>()
                .FirstOrDefault(i => i.Text == produs.Nume);

            if (item != null)
            { 
                int qty = int.Parse(item.SubItems[1].Text);
                item.SubItems[1].Text = (qty + 1).ToString();

        
                decimal pret = decimal.Parse(item.SubItems[2].Text);
                item.SubItems[2].Text = (pret + produs.Pret).ToString("0.00");
            }
            else
            {
            
                ListViewItem newItem = new ListViewItem(produs.Nume);
                newItem.SubItems.Add("1");
                newItem.SubItems.Add(produs.Pret.ToString("0.00"));
                listViewComanda.Items.Add(newItem);
            }

       
            ActualizeazaTotal();
        }
        private void ActualizeazaTotal()
        {
            decimal total = 0;
            foreach (ListViewItem item in listViewComanda.Items)
            {
                decimal pret = decimal.Parse(item.SubItems[2].Text);
                total += pret;
            }
            txtTotal.Text = total.ToString("0.00"); 
        }

  
        public void UtilizatorLogat(string nume, int puncte)
        {
            NumeUtilizator = nume;
            PuncteUtilizator = puncte;

   
            btnLogin.Visible = false;
            labelUtilizator.Text = $"{nume} ({puncte} puncte)";
            labelUtilizator.Visible = true;
        }
        public void ActualizeazaPuncte(int puncteNoi)
        {
            PuncteUtilizator += puncteNoi;
            labelUtilizator.Text = $"{NumeUtilizator} ({PuncteUtilizator} puncte)";

            ActualizeazaPuncteInBazaDeDate(NumeUtilizator, PuncteUtilizator);
        }

        private void ActualizeazaPuncteInFisier(string nume, int puncte)
        {
            string caleFisier = "conturi.txt";

            if (File.Exists(caleFisier))
            {
                var conturi = File.ReadAllLines(caleFisier);
                var conturiActualizate = new List<string>();

                foreach (var cont in conturi)
                {
                    string[] dateCont = cont.Split('|');
                    if (dateCont[0] == nume)
                    {
                        conturiActualizate.Add($"{dateCont[0]}|{dateCont[1]}|{puncte}");
                    }
                    else
                    {
                        conturiActualizate.Add(cont);
                    }
                }
                File.WriteAllLines(caleFisier, conturiActualizate);
            }
        }
        private void AfiseazaEcranBineAiVenit()
        {
            Point loginLocation = btnLogin.Location;
            Point puncteLocation = btnPuncte.Location;

            panelProduse.Controls.Clear();

            panelProduse.PerformLayout();

            Label labelBineAiVenit = new Label
            {
                Text = "Bine ai venit la Gustavo!",
                Size = new Size(panelProduse.Width - 200, 400),  
                Font = new Font("Britannic Bold", 72f, FontStyle.Italic),
                ForeColor = Color.DarkGoldenrod,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(100, 22),  
                AutoSize = false 
            };

           
            int maxWidth = panelProduse.Width - 20; 
            if (labelBineAiVenit.Width > maxWidth)
            {
                labelBineAiVenit.Width = maxWidth;
            }

            panelProduse.Controls.Add(labelBineAiVenit);

            
            btnLogin.BringToFront();
            btnPuncte.BringToFront();
            btnLogin.Location = loginLocation;
            btnPuncte.Location = puncteLocation;
            panelProduse.Controls.Add(btnLogin);
            panelProduse.Controls.Add(btnPuncte);
        }





        private Button CreateGoBackButton()
        {
            Button btnInapoi = new Button
            {
                Text = "← Înapoi",
                Size = new Size(80, 30),
                Location = new Point(10, panelProduse.Height - 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 192, 128),
                Cursor = Cursors.Hand
            };

            btnInapoi.Click += (s, e) => AfiseazaEcranBineAiVenit();
            return btnInapoi;
        }
        private void ResizeControls()
        {
           
            if (panelProduse.Controls.Count > 0)
            {
               
                var welcomeLabel = panelProduse.Controls.OfType<Label>()
                    .FirstOrDefault(l => l.Text == "Bine ai venit la Gustavo!");
                if (welcomeLabel != null)
                {
                    welcomeLabel.Size = new Size(panelProduse.Width - 200, panelProduse.Height - 100);
                    welcomeLabel.Location = new Point(100, 22);
                   
                    float newSize = Math.Min(72f, panelProduse.Width / 15f);
                    if (newSize > 0)
                    {
                        welcomeLabel.Font = new Font("Britannic Bold", newSize, FontStyle.Italic);
                    }
                }
                else
                {
                   
                    var currentProducts = GetCurrentProducts();
                    if (currentProducts.Any())
                    {
                        AfiseazaProduse(currentProducts, panelProduse);
                    }
                }
            }

            
            if (listViewComanda != null)
            {
                listViewComanda.Columns[0].Width = (int)(listViewComanda.Width * 0.6);
                listViewComanda.Columns[1].Width = (int)(listViewComanda.Width * 0.2); 
                listViewComanda.Columns[2].Width = (int)(listViewComanda.Width * 0.2); 
            }
        }
        private List<Produs> GetCurrentProducts()
        {
          
            var products = new List<Produs>();
            foreach (Control control in panelProduse.Controls)
            {
                if (control is Panel productPanel)
                {
                    var nameLabel = productPanel.Controls.OfType<Label>().FirstOrDefault();
                    var priceLabel = productPanel.Controls.OfType<Label>().LastOrDefault();
                    var pictureBox = productPanel.Controls.OfType<PictureBox>().FirstOrDefault();

                    if (nameLabel != null && priceLabel != null && pictureBox != null)
                    {
                        string price = priceLabel.Text.Replace(" lei", "");
                        if (decimal.TryParse(price, out decimal priceValue))
                        {
                            products.Add(new Produs(
                                nameLabel.Text,
                                Path.GetFileName(pictureBox.ImageLocation),
                                priceValue
                            ));
                        }
                    }
                }
            }
            return products;
        }
        public void ClearComanda()
        {
            listViewComanda.Items.Clear();
            txtTotal.Text = "0.00";
        }



        private void btnPlata_Click(object sender, EventArgs e)
        {
            decimal totalPlata = CalculeazaTotalComanda();
            FormDineOption formDineOption = new FormDineOption(this, listViewComanda, totalPlata);
            formDineOption.ShowDialog();
        }


        public class Produs
        {
            public string Nume { get; set; }
            public string Imagine { get; set; }
            public decimal Pret { get; set; }

            public Produs(string nume, string imagine, decimal pret)
            {
                Nume = nume;
                Imagine = imagine;
                Pret = pret;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}