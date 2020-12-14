using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Formatting_Practice_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0,-20} {1,5} {2,10} {3,15} {4,20} {5,25} {6,30} {7,35}", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            Console.ReadKey();
        }
    }
}
