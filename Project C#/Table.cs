using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C_
{
    class Table
    {
        private List<MainCard> firstCards = new List<MainCard>();
        private List<MainCard> secondCards = new List<MainCard>();

        private int cardPlaces = 5;

        public List<MainCard> FirstCards { get => firstCards; set => firstCards = value; }
        public List<MainCard> SecondCards { get => secondCards; set => secondCards = value; }

        public bool PlaceCardOnTheSide(int playerNumbersName, MainCard card) 
        {
            if (playerNumbersName == 1)
            {
                if (FirstCards.Count < cardPlaces)
                {
                    FirstCards.Add(card);
                    return true;
                }
                else
                {
                    Console.WriteLine("error");
                    return false;
                }
            }
            else
            {
                if (SecondCards.Count < cardPlaces)
                {
                    SecondCards.Add(card);
                    return true;
                }
                else 
                {
                Console.WriteLine("error");
                    return false;
                }
            }
        }
        public void RenderTheTable() 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < MainCard.height; i++) //8 of lines would be written
            {
                for (int j = 0; j < FirstCards.Count; j++)//all of the lines would be written {all} 
                {
                    List<string> cardLines = FirstCards[j].GetCard();
                    Console.Write(cardLines[i]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < MainCard.height; i++) //8 of lines would be written
            {
                for (int j = 0; j < SecondCards.Count; j++)//all of the lines would be written {all} 
                {
                    List<string> cardLines = SecondCards[j].GetCard();
                    Console.Write(cardLines[i]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ForegroundColor= ConsoleColor.White;
        }






























              

    }
}
