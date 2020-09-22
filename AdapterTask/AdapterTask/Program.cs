using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTask
{
    interface Itemp
    {
        int Temperature();
    } 
class Sensor
    {
        public string Name { get; set; }
        public Sensor(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
        public int Exp(Itemp ig)
        {
            return ig.Temperature();
        }
    } 
class Far : Itemp
    {
        Random r;
        public Far()
        {
            r = new Random();
        }
        public int Temperature()
        {
            int res = r.Next(100) + 1;
            return res;
        }
    } 
class Cels
    {
        Random r;
        public Cels()
        {
            r = new Random();
            
        }
        public int MeasureC()
        {
            int res = r.Next(100) + 1;
            //Console.WriteLine(res);
            return (res-30)/2;
        }
    } 
class Adapter : Itemp
    {
        Cels t1;
        public Adapter(Cels t2)
        {
            t1 = t2;
        }
        public int Temperature()
        {
            return t1.MeasureC();
        }
    } 
class MainClass
    {
        public static void Main(string[] args)
        {
            Far degr1 = new Far();
            Sensor c1 = new Sensor("Фаренгейту");
            Console.WriteLine("температура по {1} равна {0}", c1.Exp(degr1), c1.ToString());

            Cels degr2 = new Cels();
            Itemp be2 = new Adapter(degr2);
            Console.WriteLine("температура по Цельсию равна {0}", c1.Exp(be2), c1.ToString());
            Console.ReadKey();
        }
    }
   //Таким образом, с помощью паттерна адаптер создан класс-посредник
   //для датчиков измеряющих градусы в разлчиных единицах 
   //для климат-контроля авто
    
}
