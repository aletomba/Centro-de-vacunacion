using Prog3TpFinal.controlers;
using Prog3TpFinal.InputData;
using Prog3TpFinal.models;

namespace Prog3TpFinal.menu
{
    internal class ShowMenu
    {
        RegisterPerson Register = new RegisterPerson();
        CreateVacine createVaccine = new CreateVacine();

        private Controller _controller;
        

        public ShowMenu(Controller controller)
        {
            _controller = controller;
           
        }


        public void SelectMenu()
        {
            List<Person> persons = _controller.GetPeople();

            string titulo = "Bienvenido al Centro de Vacunacion";
            string[] array = new string[5];
            array[0] = "Registrar Persona";
            array[1] = "Buscar por Dni";
            array[2] = "Vacunar persona";
            array[3] = "Buscar dosis por fecha";           

            MenuGral principal = new MenuGral(titulo, array);

            int selection = 0;
            while (true)
            {               
                selection = principal.MainMenu();

                if (selection == 0)
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
                        _controller.AddPersonToList(persons);
                        Console.WriteLine("persona agregada exitosamente!!");
                        Thread.Sleep(2000);
                    }
                                    

                }

                if (selection == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"{array[1].ToUpper()}\n");
                    var doc = Register.NumberDoc();
                    if (_controller.SearchPerson(doc))
                    {
                        this.SelectMenu();
                    }
                    else
                    {
                        _controller.ListOfVaccine(doc, persons);
                    }
                    
                }

                if (selection == 2)
                {
                    Console.WriteLine($"{array[2].ToUpper()}\n");
                    try
                    {
                        var vaccinatedPerson = _controller.VaccinatePerson(persons, Register.NumberDoc(), createVaccine.Seleccionarvacuna());
                        _controller.AddPersonToList(vaccinatedPerson);
                    }
                    catch (ArgumentNullException)
                    {
                        this.SelectMenu();
                    }
                    
                    
                }

                if (selection == 3)
                {
                    try
                    {
                        Console.WriteLine("ingrese fecha de inicio dd/mm/aa");
                        DateTime firstDate = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("ingrese fecha final dd/mm/aa");
                        DateTime secondDate = DateTime.Parse(Console.ReadLine());

                        _controller.searchByDate(persons, firstDate, secondDate);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Formato incorrecto: {ex.Message}");
                    }
                }

            }
        }

    }
}
