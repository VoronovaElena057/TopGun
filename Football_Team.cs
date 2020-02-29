using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        
		public class TeamMember
       {
        
            public string Name{get; set;}
            public int Age{get; set;}
			public int Luck{get; set;}
			public Random _age=new Random();// Почему у всех одинаковый возраст если напеменную _age не делать статической?? 
			public static Random r = new Random();
			
            public TeamMember()
            {
			 Luck=r.Next(0, 100);
			 Age=_age.Next(18,45);	
			}

            public TeamMember(string Name):this()
            {
                this.Name = Name;
            }
			
			public virtual void Info()
			{
			 Console.WriteLine("This team member has lucky rate: {0}, and his age: {1}",Luck,Age);
			}
        }


        public class Goalkeeper : TeamMember
        {	
			public int skill=r.Next(1,50);
            public Goalkeeper(string Name):base(Name)  {   }
			public Goalkeeper():base()  {   }
			
			public override void Info()
			{
			 Console.WriteLine("Goalkeeper age: {0}, Name: {1}, skill:{2}",Age,Name,skill);
			}
        }

		public class Defender : TeamMember
        {	
			public int defence=r.Next(1,10);
            public Defender(string Name):base(Name)  {   }
			public Defender():base()  {   }
			
			public override void Info()
			{
			 Console.WriteLine("Defender age: {0}, Name: {1}, defence: {2}",Age,Name,defence);
			}
        }
		
		public class Midfield : TeamMember
        {	
			public int speed=r.Next(1,10);
            public Midfield(string Name):base(Name)  {   }
			public Midfield():base()  {   }
			
			public override void Info()
			{
			 Console.WriteLine("Midfield aga: {0}, Name: {1}, speed: {2}",Age,Name,speed);
			}
        }
		
		public class Forward : TeamMember
        {
			public int attack=r.Next(1,10);
            public Forward(string Name):base(Name)  {   }
			public Forward():base()  {   }
			
			public override void Info()
			{
			 Console.WriteLine("Midfield aga: {0}, Name: {1}, attack: {2}",Age,Name,attack);
			}
        }


        public class Team
        {
           public string TeamName;// имя команды
		   
           public Dictionary<string ,TeamMember> spisok= new Dictionary<string, TeamMember>();//список игроков под номерами teamNumber
			
            public Team(string TeamName, string[] teamNumber)//конструктор писваивает имя команде и добавляет разных гроков в команду
            {
                this.TeamName = TeamName;
				
                for (int i=0; i< 11; i++)
                {
					if(i==0)
                    spisok.Add(teamNumber[i],new Goalkeeper());
					else if(i>0&&i<=4)
					spisok.Add(teamNumber[i],new Defender());
                    else if(i>4&&i<=8)
					spisok.Add(teamNumber[i],new Midfield());
					else if(i>8&&i<=10)
					spisok.Add(teamNumber[i],new Forward());
                }
            }
			
			public void addNames(string [] names)
			{
				int i=0;
				foreach(TeamMember player in spisok.Values)
				{
			     player.Name=names[i++];
				}
			}
			
            public int AverageLuck()//метод вычисляет удачу команды
            {
                int teamLuck = 0;
                foreach(TeamMember s in spisok.Values)
                {
                    teamLuck = teamLuck + s.Luck;
                }
                return teamLuck/11 ; 
            }
			
			public void TeamInfo()
			{
				Console.WriteLine("Name of the football team: {0}", TeamName);
			 foreach(TeamMember i in spisok.Values)
				 i.Info();
			}
        }


        public static void  GameWinner(Team a, Team b)//метод который определяет исход игры
        {
            if (a.AverageLuck() > (b.AverageLuck()*1.1))
                Console.WriteLine("Team \"{0}\" is winner \n",a.TeamName);
            else if ((a.AverageLuck()*1.1) < b.AverageLuck())
                Console.WriteLine("Team \"{0}\" is winner \n", b.TeamName);
            else
                Console.WriteLine("Skore is equal \n");
        }
		
		public static void Luck(Team team)
		{
		  Console.WriteLine("Average luck {0} of team {1} \n",team.AverageLuck(),team.TeamName);
		  Console.WriteLine("Luck of each member of the {0} team:",team.TeamName);	
		  foreach(string teamKey in team.spisok.Keys)
		  {
		   Console.WriteLine("Player number: {0,-3} luck: {1}",teamKey,team.spisok[teamKey].Luck);
		  }
		}
		
		

      public  static void Main(string[] args)
        { 

            string[] a = new string[11] {"11","13","7","4","17","6","16","8","27","23","15" };//номера игроков команды
            Team A = new Team("Arsenal",a);
		    string [] namesA=new string[11]{"Vasja","Vova","Petja","Igor","Dima","Sasha","Misha","Vanja","Kolja","Vlad","Sergej"};
		    A.addNames(namesA);
		    //A.TeamInfo();
            //Program.Luck(A);
		    
		    

            string[] b = new string[11] {"12", "14", "15", "2", "1", "7", "88", "11", "10", "8", "17" };
            Team B = new Team("Chelsea", b);
		    //B.TeamInfo();
            //Program.Luck(B);

            Program.GameWinner(A, B);
		  
            
        }
    }
}
