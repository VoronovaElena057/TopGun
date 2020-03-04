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
                spisok.Add(teamNumber[i], Factory(i));
            }

        }

        public TeamMember Factory(int i)
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

        public int AverageLuck()//метод вычисляет удачу команды
        {
            int teamLuck = 0;
            foreach (TeamMember s in spisok.Values)
            {
                teamLuck = teamLuck + s.Luck;
            }
            return teamLuck / 11;
        }

        public void Luck()
        {
            Console.WriteLine("Average luck {0} of team {1} \n", this.AverageLuck(), this.TeamName);
            Console.WriteLine("Luck of each member of the {0} team:", this.TeamName);
            foreach (string teamKey in this.spisok.Keys)
            {
                Console.WriteLine("Player number: {0,-3} luck: {1}", teamKey, this.spisok[teamKey].Luck);
            }
        }

        public void TeamInfo()
        {
            Console.WriteLine("Name of the football team: {0}", TeamName);
            foreach (TeamMember i in spisok.Values)
                i.Info();
        }
    }
}
