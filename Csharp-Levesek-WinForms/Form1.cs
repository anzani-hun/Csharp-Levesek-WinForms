using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Csharp_Levesek_WinForms
{
    public partial class Form1 : Form
    {
        Adatbazis adatbazis;
        public Form1()
        {
            adatbazis = new Adatbazis();
            InitializeComponent();
        }

        private void button_LevesHozzaad_Click(object sender, EventArgs e)
        {
            try
            {
                Leves ujLeves = new Leves()
                {
                    Megnevezes = text_Megnevezes.Text,
                    Kaloria = Convert.ToInt32(text_Kaloria.Text),
                    Feherje = Convert.ToDecimal(text_Feherje.Text),
                    Zsir = Convert.ToDecimal(text_Zsir.Text),
                    Szenhidrat = Convert.ToDecimal(text_Szenhidrat.Text),
                    Hamu = Convert.ToDecimal(text_Hamu.Text),
                    Rost = Convert.ToDecimal(text_Rost.Text)
                };

                int hozza_add = adatbazis.LevesHozzaad(ujLeves);
                MessageBox.Show("Sikeres hozzáadás!", "Rögzítés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rögzítés", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //a bevitel után ki kell üríteni a textboxokat
            TextBoxTorles();

        }

        private void TextBoxTorles()
        {
            text_Megnevezes.Text = "";
            text_Kaloria.Text = "";
            text_Feherje.Text = "";
            text_Zsir.Text = "";
            text_Szenhidrat.Text = "";
            text_Hamu.Text = "";
            text_Rost.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            levesLista.Items.Clear();
            List<Leves> levesek = adatbazis.LevesLista();
            foreach (Leves leves in levesek)
            {
                levesLista.Items.Add(leves);
            }
        }
    }
}
