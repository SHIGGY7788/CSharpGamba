using System;

namespace CSGamba
{
    class Program
    {
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
                default:
                    Console.WriteLine("Invalid game choice.");
                    break;
            }

            return balance;
        }

        static void Main(string[] args)
        {
            double balance = 0.01;
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
