using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alicia_Virreira_PRG_III__B__Práctica2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Plato> plateList = new List<Plato>();
        public MainWindow()
        {
            InitializeComponent();

            //Plato 1 PIQUE
            List<Ingrediente> ingredientList1 = new List<Ingrediente>() { new Ingrediente("Papa"), new Ingrediente("Carne"), new Ingrediente("Chorizo"), new Ingrediente("Cebolla"), new Ingrediente("Tomate") };
            plateList.Add(new Plato("Pique macho", 50, ingredientList1));

            //Plato 2 ARROZ LECHE
            List<Ingrediente> ingredientList2 = new List<Ingrediente>() { new Ingrediente("Leche"), new Ingrediente("Arroz"), new Ingrediente("Canela") };
            plateList.Add(new Plato("Arróz con leche", 8, ingredientList2));

            //Plato 3 PUCHERO
            List<Ingrediente> ingredientList3 = new List<Ingrediente>() { new Ingrediente("Papa"), new Ingrediente("Carne"), new Ingrediente("Cebolla"), new Ingrediente("Arroz") };
            plateList.Add(new Plato("Puchero", 50, ingredientList3));
        }
        public void MostrarPlatos()
        {
            foreach (Plato plato in plateList)
            {
                lsbVizualiza.Items.Add("➤ " + plato.NombrePlato.ToUpper() + "\t" + plato.PrecioPlato + "Bs.");
                foreach (Ingrediente ingre in plato.Ingredientes)
                {
                    lsbVizualiza.Items.Add(ingre.nombreIngrediente);
                }
            }
        }
        public void MostrarIngredientes()
        {
            List<Ingrediente> list_aux = new List<Ingrediente>();
            foreach (Plato plato in plateList)
            {
                // lsbVizualiza.Items.Add("➤ " + plato.NombrePlato.ToUpper() + "\t" + plato.PrecioPlato + "Bs.");
                foreach (Ingrediente ingre in plato.Ingredientes)
                {
                    list_aux.Add(ingre);
                    lsbVizualiza_ingredientes.Items.Add(ingre.nombreIngrediente);
                }
            }
        }
        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            lsbVizualiza.Items.Clear();
            MostrarPlatos();
        }
        string plt;
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string ingreBuscado = txtBuscar.Text.Trim();

            if (rbContiene.IsChecked == true)
            {
                txtBuscar.Clear();
                lsbVizualiza.Items.Clear();
                foreach (Plato plato in plateList)
                {
                    foreach (Ingrediente ingre in plato.Ingredientes)
                    {
                        if (ingre.nombreIngrediente.ToUpper() == ingreBuscado.ToUpper())
                        {

                            lsbVizualiza.Items.Add("➤ " + plato.NombrePlato.ToUpper() + "\t" + plato.PrecioPlato + "Bs.");
                            lsbVizualiza.Items.Add(ingre.nombreIngrediente);
                        }
                    }
                }
            }
            else if (rbNOContiene.IsChecked == true)
            {
                txtBuscar.Clear();
                lsbVizualiza.Items.Clear();

                foreach (Plato plato in plateList)
                {

                    foreach (Ingrediente ingre in plato.Ingredientes)
                    {
                        if (ingre.nombreIngrediente.ToUpper() == ingreBuscado.ToUpper())
                        {
                            plt = plato.NombrePlato;
                            foreach (Plato plato2 in plateList)
                            {
                                if (plato2.NombrePlato != plt)
                                {
                                    lsbVizualiza.Items.Add("➤ " + plato2.NombrePlato.ToUpper() + "\t" + plato2.PrecioPlato + "Bs.");
                                    foreach (Ingrediente ingre2 in plato2.Ingredientes)
                                    {
                                        lsbVizualiza.Items.Add(ingre2.nombreIngrediente);
                                    }
                                }

                            }
                        }
                    }
                }


            }
            else
            {
                MessageBox.Show("Eliga una opcion");
                txtBuscar.Clear();
            }
        }

        private void btnMostrar_ingredientes_Click(object sender, RoutedEventArgs e)
        {
            MostrarIngredientes();
        }
        private void btn_comprar_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CompraPlatos vCpmra = new CompraPlatos();
            vCpmra.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
