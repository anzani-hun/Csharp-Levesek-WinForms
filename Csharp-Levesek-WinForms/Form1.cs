using System;
using System.Windows.Forms;


namespace Csharp_Levesek_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_LevesHozzaad_Click(object sender, EventArgs e)
        {
            Levesek ujLevesHozzaad = new Levesek
            {
                Megnevezes = Convert.ToString(text_Megnevezes.Text),
                Kaloria = Convert.ToInt32(text_Kaloria.Text),
                Feherje = Convert.ToDecimal(text_Feherje.Text),
                Zsir = Convert.ToDecimal(text_Zsir.Text),
                Szenhidrat = Convert.ToDecimal(text_Szenhidrat.Text),
                Hamu = Convert.ToDecimal(text_Hamu.Text),
                Rost = Convert.ToDecimal(text_Rost.Text)
            };

            Adatbazis adatbazis = new Adatbazis();
            int hozza_add = adatbazis.LevesLista(ujLevesHozzaad);
            MessageBox.Show("A leves rögzítése sikeres!");
            
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

      
    }
}
