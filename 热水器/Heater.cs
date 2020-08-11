using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 热水器
{
    /// <summary>
    /// 热水器
    /// </summary>
    public class Heater
    {
        private int temperature;//水温
        public string type = "RealFire 001";
        public string area = "China Xian";

        public delegate void BoilEventHandler(Object sender, BoiledEventArgs e);  //public delegate void BoilHandler(int param);
        public event BoilEventHandler Boiled;       // public event BoilHandler BoilEvent;

        // 定义BoiledEventArgs类，传递给Observer所感兴趣的信息
        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }

        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            Boiled?.Invoke(this, e);// 调用所有注册对象的方法
        }


        /// <summary>
        /// 烧水
        /// </summary>
        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    //建立BoiledEventArgs 对象。
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);
                    //if (BoilEvent != null)
                    //{
                    //    BoilEvent(temperature);
                    //}
                    ////MakeAlert(temperature);
                    ////ShowMsg(temperature);
                }
            }
        }
    }
    /// <summary>
    ///  警报器
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// 发出语音警报
        /// </summary>
        /// <param name="param"></param>
        public void MakeAlert(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0} 度了：", e.temperature);
            Console.WriteLine();
        }
    }
    /// <summary>
    /// 显示器
    /// </summary>
    public class Display
    {
        /// <summary>
        /// 显示水温
        /// </summary>
        /// <param name="param"></param>
        public static void ShowMsg(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快开了，当前温度：{0}度。", e.temperature);
            Console.WriteLine();
        }
    }
}
