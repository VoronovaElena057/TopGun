using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{

    class Game
    {
        Team a;
        Team b;
        public string yourBet;
        public delegate void Message(bool b);
        public event Message mess;

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
            if (a.AverageLuck() > (b.AverageLuck()*1.01))
			{
               Console.WriteLine("Team \"{0}\" is winner \n",a.TeamName);
               mess(yourBet == a.TeamName);	//mess?.Invoke(yourBet==a.TeamName);-должно быть 
			}
            else if ((a.AverageLuck()*1.01) < b.AverageLuck())
			{
                Console.WriteLine("Team \"{0}\" is winner \n", b.TeamName);
				mess(yourBet==b.TeamName);	//mess?.Invoke(yourBet==a.TeamName);-должно быть
			}
            else
                Console.WriteLine("Skore is equal. \n");
		}

        public void MesInfo(bool b)
        {
            
            if (b)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your bet won!");
                Console.ResetColor();
            }
            else
                Console.WriteLine("Your bet lost(");
            
        }
    }	
}
