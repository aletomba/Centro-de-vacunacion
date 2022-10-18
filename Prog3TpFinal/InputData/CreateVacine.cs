using Prog3TpFinal.models;

namespace Prog3TpFinal.InputData
{
    internal class CreateVacine
    {
        Vacine vacine = new Vacine();
        public Vacine Seleccionarvacuna()
        {
            try
            {
                string title = "elija una vacuna";
                Console.WriteLine(title);

                Vacine.VacineType[] values = Enum.GetValues<Vacine.VacineType>();

                foreach (Vacine.VacineType type in values)
                {
                    Console.WriteLine($"{(int)type}.{type}");
                }
                Vacine.VacineType choisedValue = (Vacine.VacineType)int.Parse(Console.ReadLine());

                if (!vacine.validateTypeVaccine(choisedValue))
                {
                    Console.Clear();
                    Seleccionarvacuna();
                }
                else
                {
                    vacine.typeOfVacine = choisedValue.ToString();
                }
                vacine.Date = DateTime.Now;

            }
            catch (FormatException)
            {

                Console.WriteLine("debe elegir una opcion correcta");
                Thread.Sleep(2000);
                Console.Clear();
                Seleccionarvacuna();

            }

            return vacine;

        }
    }
}
