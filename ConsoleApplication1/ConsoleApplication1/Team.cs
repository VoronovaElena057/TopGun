using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Team
    {
        public string TeamName;// имя команды

        public Dictionary<string, TeamMember> spisok = new Dictionary<string, TeamMember>();//список игроков под номерами teamNumber

        public Team(string teamName, string[] teamNumber)//конструктор писваивает имя команде и добавляет разных гроков в команду
        {
            TeamName = teamName;

            for (int i = 0; i < 11; i++)
            {
                spisok.Add(teamNumber[i], MakePlayer(i));
            }

        }

        public TeamMember MakePlayer(int i)
        {
            if (i == 0)
                return new Goalkeeper();
            else if (i > 0 && i <= 4)
                return new Defender();
            else if (i > 4 && i <= 8)
                return new Midfield();
            else if (i > 8 && i <= 10)
                return new Forward();
            else
                return null;
        }

        public void addNames(string[] names)
        {
            int i = 0;
            foreach (TeamMember player in spisok.Values)
            {
                player.Name = names[i++];
            }
        }

        public int Skills(TeamMember t)
        {
            if (t is Goalkeeper)
                return ((Goalkeeper)t).skill;
            else if (t is Defender)
                return ((Defender)t).defence;
            else if (t is Midfield)
                return ((Midfield)t).speed;
            else if (t is Forward)
                return ((Forward)t).attack;
            else return 0;
        }

        public int AverageLuck()//метод вычисляет удачу команды
        {
            int teamLuck = 0;
            foreach (TeamMember s in spisok.Values)
            {
                teamLuck = teamLuck + s.Luck + Skills(s);
            }
            return teamLuck / 11;
        }

        public void Luck()
        {
            Console.WriteLine("Average luck: {0} of team {1} \n", this.AverageLuck(), this.TeamName);
            Console.WriteLine("Team mamber|Number |  Name  |  Luck | Skill ");
            foreach (string teamKey in this.spisok.Keys)
            {
                Console.WriteLine("{0,-11}|{1,4}   | {2,-6} |  {3,-3}  |  {4,3}  ", this.spisok[teamKey].GetType().Name, teamKey, this.spisok[teamKey].Name,
                                  this.spisok[teamKey].Luck, this.Skills(spisok[teamKey]));
            }
            Console.WriteLine("\n");
        }

        /*public void TeamInfo()
        {
            Console.WriteLine("Name of the football team: {0}", TeamName);
         foreach(TeamMember i in spisok.Values)
             i.Info();
            Console.WriteLine("\n");	
        }*/
    }
}
