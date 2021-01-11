using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using expensechecker.Classes;
using System.Linq;

namespace expensechecker
{
    class Program
    {
        static void Main()
        {

            // Read to JSON and deserializes
            List<Expenses> inputExpenses = new List<Expenses>();

            // Get directory and create file
            string directory = Directory.GetCurrentDirectory();
            string filename = @"../../../expenses.json";
            string path = Path.GetFullPath(Path.Combine(directory, filename));

            if (!File.Exists(path))
            {
                using (var myFile = File.Create(path))
                {
                    // Do nothing, only create file
                }
            }
            else
            {
                string allExpenses = File.ReadAllText(path);
                inputExpenses = JsonConvert.DeserializeObject<List<Expenses>>(allExpenses);

            }

            // Instance of classes
            ExpenseList expenselist = new ExpenseList();
            Outputs outputs = new Outputs();

            // Program start
        start:
            outputs.WriteMenu();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Dina utgifter:");
            Console.ResetColor();
            if (new FileInfo(path).Length > 0) {
                expenselist.WriteExpenses(inputExpenses);
            } else {
                Console.WriteLine("Din lista är tom, välj alternativ 1 för att lägga till utgifter.");
            }

        // Read user input and execute method depending on anwser
        startInput:
            Console.WriteLine("\nVälj vilken uppgift du vill utföra:");
            string input = Console.ReadLine().ToLower();
            switch(input)
            {
                case "1":

                    string itemInput;
                    string categoryInput;
                    int costInput;

                    Console.WriteLine("\nVad är din utgift?");
                itemStart:
                    itemInput = Console.ReadLine();

                    // Check string, call method if nog valid and send user back to input
                    if (String.IsNullOrEmpty(itemInput))
                    {
                        outputs.FieldErrorMessage();
                        goto itemStart;
                    }
                
                    outputs.categoryMessage();
                categoryStart:
                    categoryInput = Console.ReadLine();

                    // Check length and that user picked valid number - if so, add category. If not, give error message.
                    if (String.IsNullOrEmpty(categoryInput)) { outputs.FieldErrorMessage(); goto categoryStart; }
                    if (categoryInput == "1") { categoryInput = "Hem"; }
                    else if (categoryInput == "2") { categoryInput = "Mat"; }
                    else if (categoryInput == "3") { categoryInput = "Shopping och tjänster"; }
                    else if (categoryInput == "4") { categoryInput = "Hälsa och skönhet"; }
                    else if (categoryInput == "5") { categoryInput = "Okategoriserad"; }
                    else { outputs.NotValidErrorMessage(); goto categoryStart; }

                    
                    Console.WriteLine("\nVad är kostnaden för din utgift?");
                costStart:
                    string string1 = Console.ReadLine();

                    // Check that input is number - if not, give error message.
                    bool parseSuccessful;
                    parseSuccessful = int.TryParse(string1, out costInput);
                    if (parseSuccessful == false)
                    {

                        outputs.NotNumberErrorMessage();
                        goto costStart;

                    } 
                    
                    // Call method to add item to list
                    expenselist.AddToList(inputExpenses, itemInput, categoryInput, costInput, path);
                    goto start;

                case "2":

                    Console.WriteLine("\nVälj utgift som du vill radera från listan.");
                    int delID = Convert.ToInt32(Console.ReadLine());

                    // Call method to delete from list
                    expenselist.DeleteFromList(delID, inputExpenses, path);
                    goto start;

                case "3":

                    // Method to calc monthly cost
                    int monthTotal = inputExpenses.Sum(expenses => expenses.Cost);

                    // If list is empty, tell user to fill list with expenses. Else, give total.
                    if (monthTotal == 0)
                    {
                        outputs.EmptyListMessage();
                    } else { 
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nTotala utgifter per månad:");
                    Console.ResetColor();
                    Console.WriteLine(monthTotal + ":-");
                    }

                   options:
                    // Give user option to restart app
                    outputs.RestartMessage();
                    string case3Input = Console.ReadLine().ToLower();
                    if (case3Input == "1") { goto start; }
                    else if(case3Input == "x") { Environment.Exit(0); }
                    else { outputs.NotValidErrorMessage(); goto options; }
                    break;

                case "4":

                
                // Method to calc annual cost
                int sumOfTotal = inputExpenses.Sum(expenses => expenses.Cost);
                int annualTotal = sumOfTotal * 12;

                // If list is empty, tell user to fill list with expenses. Else, give total.
                if (sumOfTotal == 0)
                {
                    outputs.EmptyListMessage();
                } else { 

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nTotala utgifter per år:");
                Console.ResetColor();
                Console.WriteLine(annualTotal + ":-");
                }

            restartOption:
                // Give user option to restart app
                outputs.RestartMessage();
                string case4Input = Console.ReadLine().ToLower();
                if (case4Input == "1") { goto start; }
                else if (case4Input == "x") { Environment.Exit(0); }
                else { outputs.NotValidErrorMessage(); goto restartOption; }
                break;
                

                case "x":

                    // Display message and exit program
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ses snart igen.");
                    Environment.Exit(0);
                    break;

                default:
                    outputs.NotValidErrorMessage();
                    goto startInput;
            }

        }
    }
}
