using System;
using System.Collections.Generic;
using System.IO;
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
                base.Add(new Ingrediente(fin.ReadLine()));
            }
            fin.Close();
        }
    }

}
