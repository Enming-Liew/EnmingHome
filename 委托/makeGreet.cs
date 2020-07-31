using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    public delegate void GreetingDelegate(string name);
    public static class makeGreet
    {
        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("\r\nMorning," + name);
        }

        public static void ChineseGreeting(string name)
        {
            Console.WriteLine("\r\n早上好," + name);
        }

        //注意此方法，它接受一个GreetingDelegate类型的方法作为参数
        public static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }


    }
}
