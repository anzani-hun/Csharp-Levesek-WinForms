using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Levesek_WinForms
{
    class Leves
    {
        //adatbázis szerkezete szerint felvenni a mezőket
        string megnevezes;
        int kaloria;
        decimal feherje;
        decimal zsir;
        decimal szenhidrat;
        decimal hamu;
        decimal rost;



        //encapsulate fields generálása
        public string Megnevezes { get => megnevezes; set => megnevezes = value; }
        public int Kaloria { get => kaloria; set => kaloria = value; }
        public decimal Feherje { get => feherje; set => feherje = value; }
        public decimal Zsir { get => zsir; set => zsir = value; }
        public decimal Szenhidrat { get => szenhidrat; set => szenhidrat = value; }
        public decimal Hamu { get => hamu; set => hamu = value; }
        public decimal Rost { get => rost; set => rost = value; }


        //constructor generálása
        public Leves(string megnevezes = "", int kaloria = 0, decimal feherje = 0, decimal zsir = 0, decimal szenhidrat = 0, decimal hamu = 0, decimal rost = 0)
        {
            this.megnevezes = megnevezes;
            this.kaloria = kaloria;
            this.feherje = feherje;
            this.zsir = zsir;
            this.szenhidrat = szenhidrat;
            this.hamu = hamu;
            this.rost = rost;
        }

        public override string ToString()
        {
            return megnevezes;
        }
    }
}
