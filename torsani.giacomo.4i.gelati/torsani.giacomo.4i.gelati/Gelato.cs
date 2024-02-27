using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torsani.giacomo._4i.gelati
{
    public class Gelato
    {
        public Gelato() { }
        public int idGelato { get; set; }
        public string nome { get; set; }
        public string descrizione { get; set; }
        public float prezzo { get; set; }

        public Gelato(string riga)
        {
            string[] campi = riga.Split(';');
            int id = 0;
            int.TryParse(campi[0], out id);
            idGelato = id;
            nome = campi[1];
            descrizione = campi[2];
            float p = 0;
            float.TryParse(campi[3], out p);
            prezzo = p;
        }
    }

    public class Gelati : List<Gelato> 
    {
        public Gelati(){}

        public Gelati(string nomeFile)
        {
            StreamReader fin = new(nomeFile);
            fin.ReadLine();
            while (!fin.EndOfStream)
            {
                base.Add(new Gelato(fin.ReadLine()));
            }
            fin.Close();
        }
    }

}
