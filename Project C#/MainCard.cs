using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_C_
{
    public class MainCard
    {

        private int health;
        private string name;
        private int damage;
        private int width = 20;
        public static int height = 8;
        private int costOfMana;
        private bool alreadyAttacked = false;


        private List<string> picture = new List<string>();

        public int CostOfMana { get => costOfMana; set => costOfMana = value; }
        public int Health { get => health; set => health = value; }
        public int Damage { get => damage; set => damage = value; }
        public string Name { get => name; set => name = value; }
        public bool AlreadyAttacked { get => alreadyAttacked; set => alreadyAttacked = value; }

        public List<string> GetCard()
        {
            int a = (width - Name.Length - 2) / 2;


            string cardTop = new string('-', width);//1,8
            picture.Add(cardTop);//1

            string cardsides = '|' + new string(' ', width - 2) + '|';//2-3,6-7
            picture.Add(cardsides);//2
            picture.Add(cardsides);//3

            string cardName = '|' + new string(' ', a) + Name + new string(' ', width - 2 - Name.Length - a) + '|';//4
            picture.Add(cardName);//4

            string stats = $"| hp{Health}{new string(' ', width - 9 - Health.ToString().Length - Damage.ToString().Length)}dmg{Damage} |";//5
            picture.Add(stats);//5
            picture.Add(cardsides);//6
            picture.Add(cardsides);//7
            picture.Add(cardTop);//8



            return picture;
        }
        public MainCard( string name, int health, int damage, int costOfMana)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.CostOfMana = costOfMana;
        }
        public void Attack(MainCard card)
        {
            if (alreadyAttacked)
            {
                Console.WriteLine("This Card has already attacked");
                return;
            }
            card.TakeDamage(Damage);
            TakeDamage(card.Damage);
            alreadyAttacked = true;
        }
        public void Attack(Player player)
        {
            if (alreadyAttacked)
            {
                Console.WriteLine("This Card has already attacked");
                return;
            }
            player.TakeDamage(Damage);
            alreadyAttacked = true;
        }
        public void TakeDamage(int damage) 
        {
        Health -= damage;
            if (Health <= 0) 
            {
            
            }
        }
        public override string ToString()
        {
            return $"{Name} {Damage} {Health} {CostOfMana}";
        }
    }

}
