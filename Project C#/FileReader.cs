using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_C_
{
    public class FileReader
    {
        public List<MainCard> GetCards(string fileName) 
        {
            List<MainCard> cards = new List<MainCard>();
            
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                for (int i = 0; i < lines.Length; i++) 
                {
                string[] stats = lines[i].Split(' ');
                    MainCard card = new MainCard(stats[0], int.Parse(stats[1]), int.Parse(stats[2]), int.Parse(stats[3]));
                    cards.Add(card);
                }
            }
            else 
            {
                Console.WriteLine("Error 404");
            }
            
            return cards;
        }















    }
}
