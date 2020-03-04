using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class TeamMember
    {
        public string Name { get; set; }
        public int Luck { get; set; }
        public static Random r = new Random();

        public TeamMember()
        {
            Luck = r.Next(0, 100);
        }

        public TeamMember(string name): this()
        {
            Name = name;
        }

        public virtual void Info()
        {
            Console.WriteLine("This team member has lucky rate: {0}}", Luck);
        }
    }
}
