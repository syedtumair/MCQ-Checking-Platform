using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataget;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            PaperData p = new PaperData();

            foreach(String s in    p.read("1111"))
                Console.WriteLine(s);
        }
    }
}
