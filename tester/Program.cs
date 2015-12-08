using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Processors;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            doIt();
        }

        static void doIt()
        {
            dynamic p;
            while (toBe())
            {
                p = pBuilder.getProcessors();
                try
                {
                    Console.WriteLine(p);
                    Console.WriteLine(p.Field);
                    Console.WriteLine(p + p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ups... {0}", ex.Message);
                }
            }
        }

        static bool toBe()
        {
            ConsoleKeyInfo cki;
            Console.WriteLine("To be (any key) or not to be (n)");
            cki = Console.ReadKey();
            if (cki.KeyChar == 'n')
            {
                return false;
            }
            return true;
        }
    }
}
