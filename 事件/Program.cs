using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件
{
    class Program
    {
        static void Main(string[] args)
        {
            //加事件用+=   取消事件-=
            //事件运行的规则和过程与委托一致  执行的类容依然是委托
            //事件和委托的关联：在定义事件的时候就会有一个委托的定义
            //并且事件的类型就是当前的委托
            Hello he = new Hello();
            China c = new China();

            he.ShowHievent += new Hello.ShowHiDelegate(c.ShowHi);
            //执行事件
            he.ClickShowHievent();

        }
    }

    class Hello
    {
        /// <summary>
        /// 定义事件的委托
        /// </summary>
        public delegate void ShowHiDelegate();

        /// <summary>
        /// 定义你好的事件
        /// </summary>
        public event ShowHiDelegate ShowHievent;

        public void ClickShowHievent()
        {
            if (ShowHievent != null)
            {
                ShowHievent();
            }
        }
    }


    class China
    {
        public void ShowHi()
        {
            Console.WriteLine("中国人说你好");
            Console.ReadKey();
        }

    }


}
