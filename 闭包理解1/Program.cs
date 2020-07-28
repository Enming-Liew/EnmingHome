using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetClosureFunction()(30));
            Console.ReadKey();
        }

        static Func<int, int> GetClosureFunction()
        {
            int val = 10;
            Func<int, int> internalAdd = x => x + val;
            Console.WriteLine(internalAdd(10));
            val = 30;
            Console.WriteLine(internalAdd(10));
            return internalAdd;

        }
    }

    public class UserModel
    {
        public string UserName
        {
            get;
            set;
        }

        public int UserAge
        {
            get;
            set;
        }
    }
}
