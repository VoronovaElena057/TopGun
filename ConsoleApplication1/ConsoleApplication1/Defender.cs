using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Defender : TeamMember
    {
        public int defence = r.Next(1, 10);
        public Defender(string Name) : base(Name) { }
        public Defender() : base() { }

        public override void Info()
        {
            Console.WriteLine("Defender  Name: {0,-7}, defence: {1}", Name, defence);
        }
    }
}
