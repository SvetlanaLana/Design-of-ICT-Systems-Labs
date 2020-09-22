using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    abstract class Progression
    {
        public int First { get; set; }
        public int Last { get; set; }
        public int H { get; set; }
        public List<int> progList;
        public Progression(int first, int last, int h)
        {
            First = first;
            Last = last;
            H = h;
            progList = new List<int>();
        }
        public void TemplateMethod()
        {
            InitializeProgression(First, Last, H);
            Progress();
            Print(progList);
        }
        private void Print(List<int> progList)
        {
            Console.WriteLine("Последовательность:");
            foreach (var item in progList)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }
        private void InitializeProgression(int a, int b, int h)
        {
            First = a;
            Last = b;
            H = h;
        }
        public abstract void Progress();
    }
    class ArithmeticProgression : Progression
    {
        public ArithmeticProgression(int f, int l, int h) : base(f, l, h) { }
        public override void Progress()
        {
            int fF = First;
            do
            {
                progList.Add(fF);
                fF = fF + H;
            }
            while (fF < Last);
        }
    }
    class GeometricProgression : Progression
    {
        public GeometricProgression(int f, int l, int h) : base(f, l, h) { }
        public override void Progress()
        {
            int fF = First;
            do
            {
                progList.Add(fF);
                fF = fF * H;
            }
            while (fF < Last);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Progression val = new ArithmeticProgression(2, 12, 3);
            val.TemplateMethod();

            Progression val1 = new GeometricProgression(2, 98, 3);
            val1.TemplateMethod();
            Console.ReadKey();
        }
    }
}
