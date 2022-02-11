using System;

namespace Practica_1_11_02_2022
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("-------- PREGUNTA 1 ----------");
            Console.WriteLine("Cuantas personas?");
            int np = int.Parse(Console.ReadLine());
            Persona[] Personas = new Persona[np];
            int menorI = 0, menorE = 0;
            string menorN = "";
            

            for(int i = 0; i < np; i++)
            {
                int edad;
                string nombre;
                Console.WriteLine($"- Nombre persona {i + 1}");
                nombre = Console.ReadLine();
                Console.WriteLine($"- Edad persona {i + 1}");
                edad = int.Parse(Console.ReadLine());
                Personas[i] = new Persona(nombre, edad);
                
                if(i == 0)
                {
                    menorI = i;
                    menorE = edad;
                    menorN = nombre;
                }

                if(edad< menorE)
                {
                    menorI = i;
                    menorE = edad;
                    menorN = nombre;
                }

            }
            Console.WriteLine("La persona menor es: "+ menorN+ ", "+ menorE);



            Console.ReadKey();

            //-------------------------------------------------------------
            Console.WriteLine("--------- PREGUNTA 2 ----------");
            int tam = 10;
            int[] v = new int[tam];
            Console.WriteLine("Vector SIN ordenar");
            for (int i = 0; i < tam; i++)
            {
                Random r = new Random();
                v[i] = r.Next(0, 10);
                Console.WriteLine(v[i]);
            }

            for (int i = tam - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (v[j] > v[j + 1])
                    {
                        int c;
                        c = v[j];
                        v[j] = v[j + 1];
                        v[j + 1] = c;

                    }
                }
            }
            Console.WriteLine("Vector ORDENADO");
            for (int i = 0; i < tam; i++)
            {
                Console.WriteLine(v[i]);
            }
            Console.ReadKey();

        }
    }

    class Persona
    {
        public Persona(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        string nombre;
        int edad;
    }
}
