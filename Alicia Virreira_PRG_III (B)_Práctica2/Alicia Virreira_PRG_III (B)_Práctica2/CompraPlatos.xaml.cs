using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Alicia_Virreira_PRG_III__B__Práctica2
{
    /// <summary>
    /// Lógica de interacción para CompraPlatos.xaml
    /// </summary>
    public partial class CompraPlatos : Window
    {
        List<Plato> plateList = new List<Plato>();

        public CompraPlatos()
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

            cmb_plato.Items.Add("--Seleccione un Plato--");
            cmb_plato.Items.Add("Pique macho");
            cmb_plato.Items.Add("Arróz con leche");
            cmb_plato.Items.Add("Puchero");

        }




        private void cmb_plato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nombre_plato = cmb_plato.SelectedItem.ToString();

            list_ingredientes.Items.Clear();
            foreach (Plato plato in plateList)
            {
                if (plato.NombrePlato.ToUpper() == nombre_plato.ToUpper())
                {
                    foreach (Ingrediente ingre in plato.Ingredientes)
                    {
                        list_ingredientes.Items.Add(ingre.nombreIngrediente);
                    }
                }

            }
        }
        int total;
        private void btnMostrar_ingredientes_Click(object sender, RoutedEventArgs e)
        {
            string nombrePlato = cmb_plato.SelectedItem.ToString();
            int cant = int.Parse(txt_cantidad.Text.Trim());

            foreach (Plato plato in plateList)
            {
                if (plato.NombrePlato.ToUpper() == nombrePlato.ToUpper())
                {
                    list_pedido.Items.Add("➤ " + cant + "\t" + plato.NombrePlato.ToUpper() + "\t" + plato.PrecioPlato + "Bs.");
                    total = total + (plato.PrecioPlato * cant);
                }

            }

            lbTotal.Content = "EL TOTAL DE SU PEDIDO ES: " + total + "Bs.";






        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Su compra ha sido realizada :D");
            this.Close();
        }
    }
}
