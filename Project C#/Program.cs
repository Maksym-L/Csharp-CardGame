using System.Reflection.Metadata.Ecma335;

namespace Project_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();
            
            Player player1 = new Player("Player1", 30, "/DeckFile.txt");
            Player player2 = new Player("Player2", 30, "/DeckFile.txt");
            //Before "/DeckFile.txt" have to be the way where the Deck file is.
            //The file with the Deck for the game is somewhere in the folder with game.
            //PS: Wenn Sie iergendwelche probleme damit haben werden, schreiben Sie mich ainfach an.

            Player playerNow;
            Player playerEnemy;
            int playerNumber;


            Random random = new Random();
            int a = random.Next(2);
            if (a == 0)
            {
                playerNow = player1;
                playerEnemy = player2;
                playerNumber = 1;
            }
            else 
            {
                playerNow = player2;
                playerEnemy = player1;
                playerNumber = 2;
            }
            bool gameOver = false;
            bool turnOver = false;
            int commandNum = 0;
            for (int i = 0; i < 3; i++) 
            {
                player1.GetCard();
                player2.GetCard();
            }
            while (!gameOver) 
            {
                playerNow.ActualMana = playerNow.ManaPerTurn;
                turnOver = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"It's turn of Player Number {playerNumber}");
                playerNow.GetCard();
                foreach (MainCard mainCard in table.FirstCards)
                {
                    mainCard.AlreadyAttacked = false;
                }
                foreach (MainCard mainCard in table.SecondCards)
                {
                    mainCard.AlreadyAttacked = false;
                }
                while (!turnOver) 
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Actual Mana is " + playerNow.ActualMana);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your Health " + playerNow.HealthOfPlayer);
                    Console.WriteLine("Enemies " + playerEnemy.HealthOfPlayer);
                    table.RenderTheTable();
                    Console.WriteLine("Write '1' to Place the card with Number ' '");
                    Console.WriteLine("Write '2' to choose the Card and attack any another Card");
                    Console.WriteLine("Write '3' to choose the Card and attack the Enemy");
                    Console.WriteLine("Write '4' to end the turn");
                    Console.ForegroundColor = ConsoleColor.Red;
                    commandNum = int.Parse(Console.ReadLine());
                    switch (commandNum)
                    { 
                        case 1:
                            PlaceTheCard(playerNow, table, playerNumber);
                            break;
                        case 2:
                            CardAttackCard(table, playerNumber);
                            break;
                        case 3:
                            if (CardAttackEnemy(table, playerEnemy, playerNumber))
                            {
                            gameOver = true;
                                return;
                            }
                            break;
                        case 4:
                            playerNumber = playerNumber == 1 ? 2 : 1;
                            if (playerNumber == 1)
                            {
                                
                                playerNow = player1;
                                playerEnemy = player2;
                            }
                            else 
                            {
                                playerNow = player2;
                                playerEnemy = player1;
                            }
                            turnOver = true;
                            playerNow.ManaPerTurn++;
                            if (playerNow.ManaPerTurn > playerNow.MaxMana) 
                            {
                            playerNow.ManaPerTurn = playerNow.MaxMana;
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("Game Over!");
        }
        static void CardAttackCard(Table table, int playerNumber)
        {
            try
            {

                if (playerNumber == 1)
                {
                    Console.WriteLine("Choose the Card per Number");
                    int i = int.Parse(Console.ReadLine());
                    int j = i;
                    MainCard card123 = table.FirstCards[i - 1];
                    Console.WriteLine("Choose the Card of the Enemy");
                    i = int.Parse(Console.ReadLine());
                    card123.Attack(table.SecondCards[i - 1]);
                    if (table.SecondCards[i - 1].Health <= 0) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Your Card ({table.FirstCards[j - 1].Name}) destroyed the Card of the enemy ({table.SecondCards[i - 1].Name})");
                        table.SecondCards.RemoveAt(i - 1);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Choose the Card per Number");
                    int i = int.Parse(Console.ReadLine());
                    int j = i;
                    MainCard card123 = table.SecondCards[i - 1];
                    Console.WriteLine("Choose the Card of the Enemy");
                    i = int.Parse(Console.ReadLine());
                    card123.Attack(table.FirstCards[i - 1]);
                    if (table.FirstCards[i - 1].Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Your Card ({table.SecondCards[j - 1].Name}) destroyed the Card of the enemy ({table.FirstCards[i - 1].Name})");
                        table.FirstCards.RemoveAt(i - 1);
                    }
                }

            }
            catch{}
        }
        static bool CardAttackEnemy(Table table, Player playerEnemy, int playerNumber) 
        {
            try
            {

                if (playerNumber == 1)
                {
                    Console.WriteLine("Choose the Card per Number");
                    int i = int.Parse(Console.ReadLine());
                    MainCard card123 = table.FirstCards[i - 1];
                    card123.Attack(playerEnemy);
                }
                else
                {
                    Console.WriteLine("Choose the Card per Number");
                    int i = int.Parse(Console.ReadLine());
                    MainCard card123 = table.SecondCards[i];
                    card123.Attack(playerEnemy);
                }
                if (playerEnemy.HealthOfPlayer <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
        static void PlaceTheCard(Player playerNow, Table table, int playerNumber) 
        {
            
            playerNow.ShowHand();
            Console.WriteLine("Take the Card");
            int i = int.Parse(Console.ReadLine());
            if (playerNow.Hand[i - 1].CostOfMana > playerNow.ActualMana)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enough Mana");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            if (table.PlaceCardOnTheSide(playerNumber, playerNow.Hand[i - 1]))
            {
                playerNow.ActualMana -= playerNow.Hand[i - 1].CostOfMana;
                playerNow.Hand.RemoveAt(i - 1);
                return;
            }
            else 
            {
                Console.WriteLine("No place on the Table");
            }
        }
    }
}
