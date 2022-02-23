using System;
using System.Collections.Generic;
using System.Text;

namespace Alicia_Virreira_PRG_III__B__Práctica2
{
    class Plato
    {
        public string NombrePlato { get; set; }
        public int PrecioPlato { get; set; }

        List<Ingrediente> ingredientList;
        public List<Ingrediente> Ingredientes { get { return ingredientList; } }

        public Plato(string nombre, int precio, List<Ingrediente> ingredientes)
        {
            NombrePlato = nombre;
            PrecioPlato = precio;
            ingredientList = ingredientes;


        }
    }
}
