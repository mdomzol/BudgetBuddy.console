using System;

namespace BudgetBuddy
{
    /// <summary>
    ///  Klasa reprezentuje pojedyńczy wydatek.
    /// </summary>
    public class Expense
    {
        /// <summary>
        /// Nazwa wydatku
        /// </summary>
        public string Name {  get; set; }

        /// <summary>
        /// Kwota wydatku
        /// </summary>
        public decimal Amount {  get; set; }

        /// <summary>
        /// Konstruktor klasy Expense
        /// </summary>
        /// <param name="name">Nazwa wydatku</param>
        /// <param name="amount">Kwota wydatku</param>
        public Expense(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }

        /// <summary>
        /// Zwraca wydatek
        /// </summary>
        public override string ToString()
        {
            return $"{Name} - {Amount:F2} zł"; 
        }
    }
}