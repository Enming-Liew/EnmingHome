using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    class Program
    {
        //public delegate bool CompareDelegate(Student first, Student second);
        public static bool Younger(Student s1, Student s2) => s1.Age <= s2.Age;

        public static bool NumSmaller(Student s1, Student s2) => s1.Num <= s2.Num;

        //delegate 委托关键字
        delegate void ShowHi(string str);
        static void Main(string[] args)
        {
            //定义一个委托并把方法以引用类型的形式加进去
            ShowHi sh = new ShowHi(ShowHi2);
            sh("Enming");

            Student s1 = new Student() { Name = "小红", Age = 18, Num = 1001 };
            Student s2 = new Student() { Name = "小黑", Age = 20, Num = 1000 };
            List<Student> list = new List<Student>();
            list.Add(s1);
            list.Add(s2);

            //Func<Student, Student, bool> c = new Func<Student, Student, bool>(Younger); 等价方法 #
            //Func<Student, Student, bool> c = Younger;// 等价方法 #
            //Func<Student, Student, bool> c = delegate (Student s3, Student s4)
            //  {
            //      return s3.Num < s4.Num;
            //  };//匿名委托
            //Func<Student, Student, bool> c = (s4, s5) => s4.Age <= s5.Age;//Lambda表达式
            Func<Student, Student, bool> c = (s4, s5) => { return s4.Age <= s5.Age; };
            SortStudent(list, c);

            //使用委托推断，与上两行等价
            //SortStudent(list, Younger);
            Console.ReadKey();
        }

        public static void SortStudent(List<Student> sList, Func<Student, Student, bool> compareMethod)
        {
            //if (compareMethod(sList[0], sList[1]))
            //{

            //}
            if (compareMethod.Invoke(sList[0], sList[1]))
            {

            }
            else
            {
                sList.Reverse();
            }
            Console.WriteLine($"\r\n按照 {compareMethod.Method.Name} 排名：");
            foreach (Student item in sList)
            {
                Console.WriteLine($"{item.Name} {item.Age} {item.Num} ");
            }
        }



        //定义一个输出你好的方法
        static void ShowHi2(string str)
        {
            Console.WriteLine("你好,{0}", str);

        }

    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Num { get; set; }
    }

}
