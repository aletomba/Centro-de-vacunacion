using Prog3TpFinal.controlers;
using Prog3TpFinal.InputData;
using Prog3TpFinal.models;

namespace Prog3TpFinal.menu
{
    internal class ShowMenu
    {
        RegisterPerson Register = new RegisterPerson();

        private Controller _controller;

        public ShowMenu(Controller controller)
        {
            _controller = controller;
        }


        public void SelectMenu()
        {
            List<Person> persons = _controller.GetPeople();

            string titulo = "Bienvenido al Centro de Vacunacion";
            string[] array = new string[4];
            array[0] = "Registrar Persona";
            array[1] = "Buscar por Dni";
            array[2] = "vacunar persona";
            array[3] = "buscar dosis por fecha";

            MenuGral principal = new MenuGral(titulo, array);

            int seleccion = 0;
            while (seleccion > -1)
            {
                seleccion = principal.MainMenu();

                if (seleccion == 0)
                {
                    Console.Clear();

                    Console.WriteLine($"{array[0].ToUpper()}\n");

                    if (_controller.PersonExist(Register.NumberDoc()))
                    {
                        this.SelectMenu();
                    }
                    else
                    {
                        persons.Add(Register.PersonalData());
                        _controller.AddPerson(persons);
                    }
                }



                //if (seleccion == 1)
                //{
                //    Console.Clear();

                //    Console.WriteLine($"{array[1].ToUpper()}\n");
                //    //MenuInputs menuInputs = new MenuInputs();
                //    menuInputs.BuscarXdni();

                //}

                //if (seleccion == 2)
                //{
                //    Console.WriteLine($"{array[1].ToUpper()}\n");
                //    // MenuInputs menuInputs = new MenuInputs();
                //    menuInputs.vacunar();
                //}

                //if (seleccion == 3)
                //{
                //    Console.WriteLine($"{array[1].ToUpper()}\n");
                //    // MenuInputs menuInputs = new MenuInputs();
                //    menuInputs.BuscarDosisFecha();
                //}

            }
        }

    }
}
