
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace torsani.giacomo._4i.gelati
{
    public partial class MainWindow : Window
    {
        Gelati gelati;
        Ingredienti ingredienti;
        public MainWindow()
        {
            InitializeComponent(); 
            Gelati gelati = new Gelati("Gelati.csv");
            dataGridGelati.ItemsSource = gelati;
            ingredienti = new Ingredienti("Ingredienti.csv");
        }

        private void dataGridGelati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gelato g = e.AddedItems[0] as Gelato;
            Ingredienti ingredientiFiltrati = new Ingredienti();
            if( g != null )
            {
                foreach(Ingrediente item in ingredienti)
                {
                    if(item.idGelato == g.idGelato)
                    {
                        ingredientiFiltrati.Add(item);
                    }
                }
            }
            dataGridIngredienti.ItemsSource = ingredientiFiltrati;
        }
    }
}