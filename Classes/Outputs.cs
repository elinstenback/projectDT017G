using System;
namespace expensechecker.Classes
{
    public class Outputs
    {
        public void WriteMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                            ");
            Console.WriteLine("                        UTGIFTSKOLLEN                       ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("\n");
            Console.ResetColor();
            Console.WriteLine("             Lägg till utgift - välj 1                      ");
            Console.WriteLine("                Radera utgift - välj 2                      ");
            Console.WriteLine("        Räkna ut totalkostnad - välj 3                      ");
            Console.WriteLine(" Räkna ut totalkostnad per år - välj 4                      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                      Avsluta - välj x                      ");
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        // Method to print category message
        public void categoryMessage()
        {
            Console.WriteLine("\nVilken kategori tillhör utgiften?");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nHem - välj 1");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Mat - välj 2");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Shopping och tjänster - välj 3");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hälsa och skönhet - välj 4");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Okategoriserad - välj 5");
        }

        // Method to display error message if field is empty
        public void FieldErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("- - - - - - Fältet måste vara ifyllt. - - - - - -");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ResetColor();
        }
        // Method to display error message if field is not number
        public void NotValidErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("- - - - - - Välj en siffra från listan. - - - - -");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ResetColor();
        }
        // Method to display error message if field is not number
        public void NotNumberErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("- - - - - - Fyll i ett numeriskt värde. - - - - -");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ResetColor();
        }

        // Method to display error message if field is empty
        public void EmptyListMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("- Fyll din lista för att räkna ut totalkostnad. -");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ResetColor();
        }

        // Method to display restart message
        public void RestartMessage()
        {
            Console.WriteLine("\nStarta om program - välj 1");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Avsluta program - välj x");
            Console.ResetColor();
        }
    }
}
