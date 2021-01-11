using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace expensechecker.Classes
{
    // Class Expenses
    public class Expenses : object
    {
        public string Item { get; set; }
        public string Category { get; set; }
        public int Cost { get; set; }
    }

    public class ExpenseList
    {
        // Method to write expenselist
        public void WriteExpenses(List<Expenses> expenselist)
        {
                for (int i = 0; i < expenselist.Count; i++)
                {
                Expenses expenses = expenselist[i];
                Console.WriteLine("[" + i + "] " + expenses.Item + "(" + expenses.Category + ")" + " - " + expenses.Cost + ":-");
                
            }
        }

        // Method to add item to expenselist
        public void AddToList(List<Expenses> expenselist, string itemInput, string categoryInput, int costInput, string path)
        {
            Expenses expense = new Expenses() { Item = itemInput, Category = categoryInput, Cost = costInput };
            expenselist.Add(expense);
            string json = JsonConvert.SerializeObject(expenselist);
            File.WriteAllText(path, json);
        }

        // Method to delete item from expenselist
        public void DeleteFromList(int id, List<Expenses> expenselist, string path)
        {
            expenselist.RemoveAt(id);
            string json = JsonConvert.SerializeObject(expenselist);
            File.WriteAllText(path, json);
        }
    }
}