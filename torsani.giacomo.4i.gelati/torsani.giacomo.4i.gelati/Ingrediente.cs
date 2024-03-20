using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torsani.giacomo._4i.gelati
{
    public enum TipoIngrediente { }
    public class Ingrediente
    {
        public int idGelato { get; set; }
        public string tipo { get; set; }
        public string valore { get; set; }

        public Ingrediente() { }
        public Ingrediente(string riga)
        {
            string[] campi = riga.Split(';');
            int id = 0;
            int.TryParse(campi[0], out id);
            idGelato = id;
            tipo = campi[1];
            valore = campi[2];
        }
    }

    public class Ingredienti : List<Ingrediente>
    {
        public Ingredienti() { }
        public Ingredienti(string nomeFile)
        {
            StreamReader fin = new(nomeFile);
            fin.ReadLine();
            while (!fin.EndOfStream)
            {
                string riga = fin.ReadLine();
                if (riga.Split(';')[1] == "Panna")
                {
                    Add(new IngredientePanna(riga));
                }

                else if (riga.Split(';')[1] == "Colorante")
                {
                    Add(new IngredienteColorante(riga));
                } 

                else if (riga.Split(';')[1] == "Latte")
                {
                    Add(new IngredienteLatte(riga));
                }
                else
                {
                    Add(new Ingrediente(riga));
                }
            }
            fin.Close();
        }
    }

    public class IngredientePanna : Ingrediente
    {
        public string calorie { get; set; }
        public IngredientePanna(string riga) : base(riga)
        {
            string[] campi = riga.Split(';');
            calorie = campi[3];
        }
    }

    public class IngredienteColorante : Ingrediente
    {
        public string colore { get; set; }
        public IngredienteColorante(string riga) : base(riga)
        {
            string[] campi = riga.Split(';');
            colore = campi[3];
        }
    }

    public class IngredienteLatte : Ingrediente
    {
        public string lattosio { get; set; }
        public IngredienteLatte(string riga) : base(riga)        {
            string[] campi = riga.Split(';');
            lattosio = campi[3];
        }
    }
}
