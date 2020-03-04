using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Midfield : TeamMember
    {
        public int speed = r.Next(1, 10);
        public Midfield(string Name) : base(Name) { }
        public Midfield() : base() { }

        public override void Info()
        {
            Console.WriteLine("Midfield  Name: {0,-7}, speed: {1}", Name, speed);
        }
    }
}
