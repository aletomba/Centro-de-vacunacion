using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3TpFinal.menu
{
    internal class MenuGral
    {
        private string titulo;
        private string[] array;

        public MenuGral(string _titulo, string[] _array)
        {
            this.titulo = _titulo;
            this.array = _array;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string[] Array { get => array; set => array = value; }


        public virtual int MainMenu()
        {
            int seleccionado = 0;
            ConsoleKey tecla = 0;
            while (tecla != ConsoleKey.Enter && tecla != ConsoleKey.Escape)
            {
                this.Dibujar(seleccionado);

                tecla = Console.ReadKey().Key;

                if (tecla == ConsoleKey.UpArrow && seleccionado > 0) seleccionado--;
                if (tecla == ConsoleKey.DownArrow && seleccionado < this.array.Length - 1) seleccionado++;
            }

            return tecla == ConsoleKey.Enter ? seleccionado : -1;
        }

        public void Dibujar(int seleccionado)
        {
            Console.Clear();
            ConsoleColor baseBackgroundColor = Console.BackgroundColor;

            Console.WriteLine($"={this.Titulo.ToUpper()}=");

            for (int i = 0; i < this.array.Length; i++)
            {
                if (seleccionado == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                Console.WriteLine(array[i]);

                Console.BackgroundColor = baseBackgroundColor;
            }
        }
    }
}

