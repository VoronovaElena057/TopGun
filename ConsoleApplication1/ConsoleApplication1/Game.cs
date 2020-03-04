using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Game
    {
        public Team a;
        public Team b;
        public string yourBet;

        public Game(Team a, Team b)
        {
            this.a = a;
            this.b = b;
        }

        public void YourBet(int bet)
        {
            if (bet == 1)
                yourBet = "Arsenal";
            else if (bet == 2)
                yourBet = "Chelsea";
            else
                Console.WriteLine("You enter a wrong character. Your bet on this match will not be accepted.");
        }


        public void GameWinner()//метод который определяет исход игры
        {
            if (a.AverageLuck() > b.AverageLuck())
            {
                Console.WriteLine("Team \"{0}\" is winner \n", a.TeamName);
                if (yourBet == a.TeamName)
                    Console.WriteLine("Your bet won!");
                else
                    Console.WriteLine("Your bet lost(");
            }
            else if (a.AverageLuck() < b.AverageLuck())
            {
                Console.WriteLine("Team \"{0}\" is winner \n", b.TeamName);
                if (yourBet == b.TeamName)
                    Console.WriteLine("Your bet won!");
                else
                    Console.WriteLine("Your bet lost(");
            }
            else
                Console.WriteLine("Skore is equal. \n");
        }
    }
}
