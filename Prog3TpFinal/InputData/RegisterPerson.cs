using Prog3TpFinal.models;
using System.Text.RegularExpressions;

namespace Prog3TpFinal.InputData
{
    internal class RegisterPerson
    {
        Person NewPerson = new Person();  

        public Person PersonalData()
        {
            try
            {

                Console.WriteLine("ingrese nombre");
                NewPerson.Name = Console.ReadLine();


                Console.WriteLine("ingrese apellido");
                NewPerson.LastName = Console.ReadLine();              

                //Console.WriteLine("ingrese nacionalidad");
                //NuevaPersona.Nacionalidad1 = Console.ReadLine();

                //Console.WriteLine("ingrese fecha de nacimiento d/m/a \n");
                //NuevaPersona.FechaDeNacimiento = DateTime.Parse(Console.ReadLine());


            }
            catch (FormatException ex)
            {
                Console.WriteLine($"error al ingresar datos, {ex.Message}");
                Thread.Sleep(2000);
                PersonalData();
            }

            this.InfoContact();

            return NewPerson;

        }

        public int NumberDoc()
        {
            try
            {
                Console.WriteLine($"ingrese {TypeDoc()}");

                NewPerson.Document = int.Parse(Console.ReadLine());               
            }
            catch (FormatException)
            {
                Console.WriteLine($"debe ingresar un numero");
                Thread.Sleep(2000);
                Console.Clear();
                NumberDoc();

            }
            catch (OverflowException)
            {
                Console.WriteLine("Numero incorrecto");
                Thread.Sleep(2000);
                Console.Clear();
                NumberDoc();
            }
            return NewPerson.Document;
        }

        public string TypeDoc()
        {
            try
            {
                string title = "elija una opcion \n";
                Console.WriteLine(title);

                Person.TipeDocument[] valoresPosibles = Enum.GetValues<Person.TipeDocument>();

                foreach (Person.TipeDocument tipo in valoresPosibles)
                {
                    Console.WriteLine($"{(int)tipo}.{tipo}");
                }

                Person.TipeDocument estadoElegido = (Person.TipeDocument)int.Parse(Console.ReadLine());

                if (!NewPerson.validateTypeDni(estadoElegido))
                {
                    Console.Clear();
                    TypeDoc();
                }
                else 
                {
                    NewPerson.TypeSelect = estadoElegido.ToString();
                }               
                
            }
            catch (FormatException)
            {
                Console.WriteLine("debe elegir una opcion correcta");
                Thread.Sleep(2000);
                Console.Clear();
                TypeDoc();
               
            }


            return NewPerson.TypeSelect;

        }

        private void InfoContact()
        {
            try
            {
                Console.WriteLine("ingrese telefono personal");
                NewPerson.InfoContact.CellPhone = double.Parse(Console.ReadLine());

                //Console.WriteLine("ingrese telefono de emergencias Ej: familiar,amigo,etc");
                //NuevaPersona.infoContac.TelefonoEmergencias1 = double.Parse(Console.ReadLine());

                //Console.WriteLine("ingrese direccion de Email");
                //NuevaPersona.infoContac.Email1 = Console.ReadLine();

                this.Direction();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"error al ingresar datos: {ex.Message}");
                Thread.Sleep(2000);
            }


        }

        private void Direction()
        {
            try
            {

                Console.WriteLine("ingrese ciudad");
                NewPerson.Direction.City = Console.ReadLine();

                //Console.WriteLine("ingrese provincia");
                //NuevaPersona.direccion.Provincia1 = Console.ReadLine();

                // Console.WriteLine("ingrese codigo postal");
                // NuevaPersona.direccion.CodigoPostal1 = int.Parse(Console.ReadLine());

                // Console.WriteLine("ingrese calle");
                // NuevaPersona.direccion.Calle1 = Console.ReadLine();

                // Console.WriteLine("ingrese numero");
                //NuevaPersona.direccion.Nmuero1 = int.Parse(Console.ReadLine());

                // Console.WriteLine("otros--> Ej: piso,dpto,etc");
                // NuevaPersona.direccion.Otros1 = Console.ReadLine();


            }
            catch (FormatException ex)
            {
                Console.WriteLine($"error al ingresar datos: {ex.Message}");
                Thread.Sleep(2000);
            }

        }
    }
}
