using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Forward : TeamMember
    {
        public int attack = r.Next(1, 10);
        public Forward(string Name) : base(Name) { }
        public Forward() : base() { }

        public override void Info()
        {
            Console.WriteLine("Forward  Name: {0,-7}, attack: {1}", Name, attack);
        }
    }
}
