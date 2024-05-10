using System;

namespace CSGamba
{
    class Program
    {

        static double Beg(double balance)
        {
            Console.Clear();
            Console.WriteLine("How should we beg today?");
            Console.WriteLine("1: Ask a friend");
            Console.WriteLine("2: Ask Family");
            Console.WriteLine("3: Steal the moner");
            
            int begType = int.Parse(Console.ReadLine());
            Console.Clear();
            
            switch (begType)
            {
                
                case 1:
                    Console.WriteLine("Your call your friend asking for money");
                    System.Threading.Thread.Sleep(1000);
                    Random friendChance = new Random();
                    string[] friendResponse = { "yes", "no" };
                    int friendAnswer = friendChance.Next(0, friendResponse.Length);
                    if (friendAnswer == 0)
                    {
                        Console.WriteLine("he gives you $25");
                        balance = balance + 25;
                        Console.WriteLine($"Your new balance is {balance}");
                    } 
                    if (friendAnswer == 1)
                    {
                        Console.WriteLine("He doesn't like gambaling, no $$");
                    }
                    return (balance);
                
                
                case 2:
                    Console.WriteLine("You approach your family for gambling money");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Your family doesn't support your gambling addiction");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("They kick you out bcz gambling is bad :(");
                    return balance;
                
                case 3:
                    Console.WriteLine("You decide to formulate a heist");
                    Console.WriteLine("Where should we robbery?");
                    Console.WriteLine("1: Gas station");
                    Console.WriteLine("2: Walmart");
                    Console.WriteLine("3: Zumiez");
                    Console.WriteLine("4: The Casino!!!!");
                    
                    int heistChoice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (heistChoice)
                    {
                        case 1:
                            Console.WriteLine("You decide to rob a gas station");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("You ask the man for all the money");
                            System.Threading.Thread.Sleep(1000);
                            Random GasStationRobChance = new Random();

                            int GasStationOutcome = GasStationRobChance.Next(0, 10);

                            if (GasStationOutcome >= 7)
                            {
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine();
                            }
                            
                            
                            
                            
                            
                    }
                    

                    
            }

            return balance;
        }
        static double Slots(double balance)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the slots!");
            string[] symbols = { "CHERRY", "LEMON", "ORANGE", "PLUM", "BELL", "BAR", "7" };
            Console.WriteLine($"Your balance is {balance}");
            Console.WriteLine("What is your bet amount?");
            double stake = double.Parse(Console.ReadLine());

            while (stake > balance || stake <= 0)
            {
                Console.WriteLine("Invalid Bet Amount");
                Console.WriteLine("Enter Bet Amount");
                stake = double.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Your bet is {stake}");

            balance -= stake;

            Random random = new Random();
            int slot1 = random.Next(0, symbols.Length);
            int slot2 = random.Next(0, symbols.Length);
            int slot3 = random.Next(0, symbols.Length);

            Console.WriteLine(symbols[slot1]);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(symbols[slot2]);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(symbols[slot3]);

            if (slot1 == slot2 && slot2 == slot3)
            {
                Console.WriteLine("Max Win!!!!! YAAAAAA");
                balance += stake * 3;
            }
            else if (slot1 == slot2 || slot1 == slot3 || slot2 == slot3)
            {
                Console.WriteLine("Small win!!! 1.25X!!! Yipee");
                balance += stake * 1.25;
            }
            else
            {
                Console.WriteLine("EWWW LOSERRR GO AGAIn!!!!");
            }

            Console.WriteLine($"Your new balance is {balance}");
            return balance;
        }

        static double PickGame(double balance)
        {
            Console.Clear();
            Console.WriteLine("What game do you want to play?");
            Console.WriteLine("1: Slots");
            string choice = Console.ReadLine();
            int option = int.Parse(choice);
            switch (option)
            {
                case 1:
                    Console.WriteLine("You chose slots!!! hooray!");
                    balance = Slots(balance);
                    break;
                
                case 9:
                    Console.WriteLine("Lets go beg!");
                    balance = Beg(balance);
                    break;
                default:
                    Console.WriteLine("Invalid game choice.");
                    break;
            }

            return balance;
        }

        static void Main(string[] args)
        {
            double balance = 500;
            Console.WriteLine("--Welcome To the Casino--");
            Console.WriteLine($"Your initial Balance is {balance}");

            bool running = true;
            while (running)
            {
                balance = PickGame(balance); // Update balance after each game
                Console.WriteLine("Would you like to play again? (y/n)");
                string playAgain = Console.ReadLine().ToLower();
                if (playAgain != "y")
                {
                    running = false; // Exit the loop if the user doesn't want to continue
                }
            }

            Console.WriteLine("Thanks for playing! Goodbye!");
        }
    }
}
