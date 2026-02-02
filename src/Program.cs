using System;
using System.Collections.Generic;

namespace BudgetBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Expense> expenses = new List<Expense>();
            string choice;

            do
            {
                Console.Clear();
                ShowMenu();

                Console.Write("Wybierz opcję: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddExpense(expenses);
                }
                else if (choice == "2")
                {
                    ShowExpenses(expenses);
                }
                else if (choice == "3")
                {
                    CalculateTotalAmount(expenses);
                }
                else if (choice == "4")
                {
                    FindMaxExpense(expenses);
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Zamykanie programu...");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    Pause();
                }
            } while (choice != "5");
        }

        static void ShowMenu()
        {
            Console.WriteLine("===== KALKULATOR WYDATKÓW DOMOWYCH =====");
            Console.WriteLine("1. Dodaj wydatek");
            Console.WriteLine("2. Wyświetl listę wydatków");
            Console.WriteLine("3. Oblicz łączną kwotę wydatków");
            Console.WriteLine("4. Znajdź największy wydatek");
            Console.WriteLine("5. Wyjdź");
            Console.WriteLine("========================================");
        }

        static void AddExpense(List<Expense> expenses)
        {
            Console.Clear();
            Console.WriteLine("=== DODAWANIE WYDATKU ===");

            // Pobieranie nazwy
            string name;
            do
            {
                Console.WriteLine("Podaj nazwę wydatku: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Nazwa wydatku nie może być pusta.");
                }
            } while (string.IsNullOrWhiteSpace(name));

            // Pobieranie i walidacja kwoty
            decimal amount;
            bool isValidAmount;

            do
            {
                Console.Write("Podaj kwotę wydatku: ");
                string input = Console.ReadLine();

                isValidAmount = decimal.TryParse(input, out amount) && amount > 0;

                if (!isValidAmount)
                {
                    Console.WriteLine("Podaj poprawioną dodatnią kwotę.");
                }
            } while (!isValidAmount);

            // Dodanie wydatku do listy
            expenses.Add(new Expense(name, amount));

            Console.WriteLine();
            Console.WriteLine("Wydatek został dodany pomyślnie!");
            Pause();
        }

        static void ShowExpenses(List<Expense> expenses)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA WYDATKÓW ===");

            if (expenses.Count == 0)
            {
                Console.WriteLine("Brak wydatków do wyświetlenia");
                Pause();
                return;
            }

            for (int i = 0; i < expenses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {expenses[i]}");
            }

            Pause();
        }

        static void CalculateTotalAmount(List<Expense> expenses)
        {
            Console.Clear();
            Console.WriteLine("=== ŁĄCZNA KWOTA WYDATKÓW ===");

            if (expenses.Count == 0)
            {
                Console.WriteLine("Brak wydatków do obliczenia.");
                Pause();
                return;
            }

            decimal totalAmount = 0;

            foreach (Expense expense in expenses)
            {
                totalAmount += expense.Amount;
            }

            Console.WriteLine($"Łączna kwota wydatków: {totalAmount:F2} zł");
            Pause();
        }

        static void FindMaxExpense(List<Expense> expenses)
        {
            Console.Clear();
            Console.WriteLine("=== NAJWIĘKSZY WYDATEK ===");

            if (expenses.Count == 0)
            {
                Console.WriteLine("Brak wydatków do analizy.");
                Pause();
                return;
            }

            Expense maxExpense = expenses[0];

            foreach (Expense expense in expenses)
            {
                if ( expense.Amount > maxExpense.Amount )
                {
                    maxExpense = expense;
                }
            }

            Console.WriteLine($"Największy wydatek: {maxExpense.Name}");
            Console.WriteLine($"Kwota: {maxExpense.Amount:F2} zł");

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu...");
            Console.ReadKey();
        }
    }
}