using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Program
    {
        
		public class TeamMember
       {   
            public string Name{get; set;}
			public int Luck{get; set;}
			public static Random r = new Random();
			
            public TeamMember()
            {
			 Luck=r.Next(0, 100);
			}

            public TeamMember(string name):this()
            {
                Name = name;
            }
			
			public virtual void Info()
			{
			 Console.WriteLine("This team member has lucky rate: {0}}",Luck);
			}
        }


        public class Goalkeeper : TeamMember
        {	
			public int skill=r.Next(1,50);
            public Goalkeeper(string Name):base(Name)  {   }
			public Goalkeeper():base()  {   }
			
			public override void Info()
			{
			 Console.WriteLine("Goalkeeper Name: {0,7}, skill:{1,5}",Name,skill);
			}
        }

		public class Defender : TeamMember
        {	
			public int defence=r.Next(1,10);
            public Defender(string Name):base(Name)  {   }
			public Defender():base()  {   }
			
			public override void Info()
			{
			 Console.WriteLine("Defender  Name: {0,7}, defence: {1,5}",Name,defence);
			}
        }
		
		public class Midfield : TeamMember
        {	
			public int speed=r.Next(1,10);
            public Midfield(string Name):base(Name)  {   }
			public Midfield():base()  {   }
			
			public override void Info()
			{
			 Console.WriteLine("Midfield  Name: {0,7}, speed: {1,5}",Name,speed);
			}
        }
		
		public class Forward : TeamMember
        {
			public int attack=r.Next(1,10);
            public Forward(string Name):base(Name)  {   }
			public Forward():base()  {   }
			
			public override void Info()
			{
			 Console.WriteLine("Forward   Name: {0,7}, attack: {1,5}",Name,attack);
			}
        }


        public class Team
        {
           public string TeamName;// имя команды
		   
           public Dictionary<string ,TeamMember> spisok= new Dictionary<string, TeamMember>();//список игроков под номерами teamNumber
			
            public Team(string teamName, string[] teamNumber)//конструктор писваивает имя команде и добавляет разных гроков в команду
            {
                TeamName = teamName;
				
				for (int i=0; i< 11; i++)
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
			
			public void addNames(string [] names)
			{
				int i=0;
				foreach(TeamMember player in spisok.Values)
				{
			     player.Name=names[i++];
				}
			}
			
			public int Skills(TeamMember t)
			{
			 if(t is Goalkeeper)
				 return ((Goalkeeper)t).skill;
			 else if(t is Defender)
				 return ((Defender)t).defence;
			 else if(t is Midfield)	
				 return ((Midfield)t).speed;
			 else if(t is Forward)
				 return ((Forward)t).attack;
			 else return 0;	
			}
			
            public int AverageLuck()//метод вычисляет удачу команды
            {
                int teamLuck = 0;
                foreach(TeamMember s in spisok.Values)
                {
                    teamLuck = teamLuck + s.Luck+Skills(s);
                }
                return teamLuck/11 ; 
            }
			
		public  void Luck()
		{
		  Console.WriteLine("Average luck: {0} of team {1} \n",this.AverageLuck(),this.TeamName);
		  Console.WriteLine("Team mamber|Number |  Name  |  Luck | Skill ");	
		  foreach(string teamKey in this.spisok.Keys)
		  {
		   Console.WriteLine("{0,-11}|{1,4}   | {2,-6} |  {3,-3}  |  {4,3}  ", this.spisok[teamKey].GetType().Name,teamKey,this.spisok[teamKey].Name,
							 this.spisok[teamKey].Luck,this.Skills(spisok[teamKey]));
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

       class Game
      {
	    Team a;
	    Team b;
		public string yourBet;
		public delegate void Message(bool b);  
		public event Message mess;
		   
		   public Game(Team a, Team b)
		   {
		    this.a=a;
			this.b=b;   
		   }
		   
		   public void YourBet(int bet)
		   {
		    if (bet==1)
			     yourBet="Arsenal"; 	
			else if(bet==2)
			     yourBet="Chelsea";
		    else
			Console.WriteLine("You enter a wrong character. Your bet on this match will not be accepted.");	
		   }		   		 
	
        public  void  GameWinner()//метод который определяет исход игры
        {
            if (a.AverageLuck() > (b.AverageLuck()*1.01))
			{
               Console.WriteLine("Team \"{0}\" is winner \n",a.TeamName);	
				mess?.Invoke(yourBet==a.TeamName);	
			}
            else if ((a.AverageLuck()*1.01) < b.AverageLuck())
			{
                Console.WriteLine("Team \"{0}\" is winner \n", b.TeamName);
				mess?.Invoke(yourBet==b.TeamName);	
			}
            else
                Console.WriteLine("Skore is equal. \n");
		}
		   
		   public void MesInfo(bool b)
		   {  
			   if(b)
				Console.WriteLine("Your bet won!");
			   else
				Console.WriteLine("Your bet lost(");
		   }
      }	
		
     
	
      public  static void Main(string[] args)
        { 

            string[] a = new string[11] {"11","13","7","4","17","6","16","8","27","23","15" };//номера игроков команды
            Team A = new Team("Arsenal",a);
		    string [] namesA=new string[11]{"Vasja","Vova","Petja","Igor","Dima","Sasha","Misha","Vanja","Kolja","Vlad","Sergej"};
		    A.addNames(namesA);
		    

            string[] b = new string[11] {"12", "14", "15", "2", "1", "7", "88", "11", "10", "8", "17" };
            Team B = new Team("Chelsea", b);
		    string [] namesB=new string[11]{"Andrej","Jura","Lesha","Denis","Dima","Pasha","Slava","Nikita","Tima","Kostja","Gosha"};
		    B.addNames(namesB);
		    
             
		    Console.WriteLine("Two teams are playing today: \"Arsenal\" and \"Chelsea\" \nWhich team are you betting on?");
		    Console.WriteLine("Enter nuumber 1 or 2: \n 1)\"Arsenal\"  \n 2)\"Chelsea\" ");
		    int bet=Convert.ToInt32(Console.ReadLine());
		    
		    Game G=new Game(A,B);
		    G.YourBet(bet);
		    G.mess+=G.MesInfo;
            G.GameWinner();
		   
		  Console.WriteLine("\n \n");
		  //A.TeamInfo();
		  //B.TeamInfo();
		  A.Luck();
		  B.Luck();
        }
    }
}
