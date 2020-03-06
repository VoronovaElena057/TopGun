using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
  

        public class Program
        {

            public static void Main(string[] args)
            {

                string[] a = new string[11] { "11", "13", "7", "4", "17", "6", "16", "8", "27", "23", "15" };//номера игроков команды
                Team A = new Team("Arsenal", a);
                string[] namesA = new string[11] { "Vasja", "Vova", "Petja", "Igor", "Dima", "Sasha", "Misha", "Vanja", "Kolja", "Vlad", "Sergej" };
                A.addNames(namesA);


                string[] b = new string[11] { "12", "14", "15", "2", "1", "7", "88", "11", "10", "8", "17" };
                Team B = new Team("Chelsea", b);
                string[] namesB = new string[11] { "Andrej", "Jura", "Lesha", "Denis", "Dima", "Pasha", "Slava", "Nikita", "Tima", "Kostja", "Gosha" };
                B.addNames(namesB);


                Console.WriteLine("Two teams are playing today: \"Arsenal\" and \"Chelsea\" \nWhich team are you betting on?");
                Console.WriteLine("Enter nuumber 1 or 2: \n 1)\"Arsenal\"  \n 2)\"Chelsea\" ");
                int bet = Convert.ToInt32(Console.ReadLine());

                Game G = new Game(A, B);
                G.YourBet(bet);
                G.mess += G.MesInfo;
                G.GameWinner();

                Console.WriteLine("\n \n");
                //A.TeamInfo();
                //B.TeamInfo();
                A.Luck();
                B.Luck();

                Console.ReadKey();
            }
    }
}
