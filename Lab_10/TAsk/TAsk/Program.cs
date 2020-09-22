using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk
{
    public abstract class Programming
    {
        public int NumberTasks { get; set; }

        public double time;
        public Programming(int NT)
        {
            NumberTasks = NT;
        }
        public void TemplateMethod()
        {
            InitialTime(NumberTasks);
            programming();
            Print(time+1);
        }
        private void Print(double time)
        {
            Console.WriteLine("На решение задач по программированию уйдет: {0} часов", time);
            Console.WriteLine();
        }
        private void InitialTime(int a)
        {
            NumberTasks = a;
        }
        public abstract void programming();

    }
    public class CSharpProgramming : Programming
    {
        public CSharpProgramming(int a) : base(a) { }
        public override void programming()
        {
            int x = NumberTasks;
            time = 1.5 * x + Math.Sin(3*x*Math.PI/180)+0.15*x;
        }
    }
    public class JavaProgramming : Programming
    {
        public JavaProgramming(int a) : base(a) { }
        public override void programming()
        {
            int x = NumberTasks;
            time = 2.5 * x + Math.Cos(Math.Pow(2,x)* Math.PI / 180) + 0.25 * x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Programming CSharp = new CSharpProgramming(10);
            CSharp.TemplateMethod();
            Programming Java = new JavaProgramming(10);
            Java.TemplateMethod();
            Console.ReadKey();
        }
    }
    //Шаблонный метод — это поведенческий паттерн проектирования, который предлагает
    //разбить алгоритм на последовательность шагов, описать шаги в отдельных методах и вызывать
    //их в одном «шаблонном» методе друг за другом.
    //В контрольном задании спроектирован алгоритм расчета времени в зависимости от 
    //разных языков программирования
}
