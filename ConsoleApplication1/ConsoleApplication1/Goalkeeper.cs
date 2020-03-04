using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Goalkeeper : TeamMember
    {
        public int skill = r.Next(1, 50);
        public Goalkeeper(string Name) : base(Name) { }
        public Goalkeeper() : base() { }

        public override void Info()
        {
            Console.WriteLine("Goalkeeper Name: {0,-7}, skill:{1}", Name, skill);
        }
    }
}
