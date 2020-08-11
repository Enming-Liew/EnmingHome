using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 热水器
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater ht = new Heater();
            Alarm alarm = new Alarm();
            ht.Boiled += alarm.MakeAlert; //注册方法
            ht.Boiled += (new Alarm()).MakeAlert;//给匿名对象注册方法
            ht.Boiled += Display.ShowMsg; //注册静态方法
            ht.BoilWater();//烧水，会自动调用注册过对象的方法
            Console.Read();
        }
    }
}
