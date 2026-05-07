using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_C_
{
    public class Player
    {
        private string name;

        private int healthOfPlayer;

        private int actualMana;
        private int maxMana = 10;
        private int manaPerTurn = 3;

        private List<MainCard> deck = new List<MainCard>();
        private List<MainCard> hand = new List<MainCard>();

        public int ActualMana { get => actualMana; set => actualMana = value; }
        public int MaxMana { get => maxMana; set => maxMana = value; }
        public int ManaPerTurn { get => manaPerTurn; set => manaPerTurn = value; }
        public List<MainCard> Hand { get => hand; set => hand = value; }
        public List<MainCard> Deck { get => deck; set => deck = value; }
        public int HealthOfPlayer { get => healthOfPlayer; set => healthOfPlayer = value; }

        public Player(string name, int healthOfPlayer, string wayToDeck)
        {
            this.name = name;
            this.HealthOfPlayer = healthOfPlayer;
            this.ActualMana = ManaPerTurn;
            FileReader fileReader = new FileReader();
            Deck = fileReader.GetCards(wayToDeck);
        }
        public void GetCard()
        {
            if (Deck.Count == 0)
            {
                Console.WriteLine("No cards into the deck");
                return;
            }

            Random rnd = new Random();
            int numm = rnd.Next(Deck.Count);
            MainCard card = Deck[numm];
            Hand.Add(card);
            Deck.RemoveAt(numm);
        }
        public void TakeDamage(int damage)
        {
            HealthOfPlayer -= damage;
            if (HealthOfPlayer <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player {name} is dead");
        }
        public void ShowHand() 
        {
            for (int i = 0; i < Hand.Count; i++) 
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Card Number {i + 1}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Hand[i].ToString());
            }
        }
    }
}
