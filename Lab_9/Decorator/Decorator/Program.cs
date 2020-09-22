using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class AutoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double CostBase { get; set; }
        public abstract double GetCost();
        public override string ToString()
        {
            string s = String.Format("Ваш автомобиль: \n{0} \nОписание: {1} \nСтоимость {2}\n",
            Name, Description, GetCost());
            return s;
        }
    }
    class Renault : AutoBase
    {
        public Renault(string name, string info, double costbase)
        {
            Name = name;
            Description = info;
            CostBase = costbase;
        }
        public override double GetCost()
        {
            return CostBase * 1.18;
        }
    }
    class DecoratorOptions : AutoBase
    {
        public AutoBase AutoProperty { protected get; set; }
        public string Title { get; set; }
        public DecoratorOptions(AutoBase au, string tit)
        {
            AutoProperty = au;
            Title = tit;
        }
        public override double GetCost()
        {
            throw new NotImplementedException();
        }
    }
    class MediaNAV : DecoratorOptions
    {
        public MediaNAV(AutoBase p, string t) : base(p, t)
        {
            AutoProperty = p;
            Name = p.Name + ". Современный";
            Description = p.Description + ". " + this.Title + ". Обновленная мультимедийная навигационная система";
        }
        public override double GetCost()
        {
            return AutoProperty.GetCost() + 15.99;
        }
    }
    class SystemSecurity : DecoratorOptions
    {
        public SystemSecurity(AutoBase p, string t) : base(p, t)
        {
            AutoProperty = p;
            Name = p.Name + ". Повышенной безопасности";
            Description = p.Description + ". " + this.Title + ". Передние боковые подушки безопасности, ESP - система динамической стабилизации автомобиля";
        }
        public override double GetCost()
        {
            return AutoProperty.GetCost() + 20.99;
        }
    }
    class SatelliteNavigation : DecoratorOptions
    {
        public SatelliteNavigation(AutoBase p, string t) : base(p, t)
        {
            AutoProperty = p;
            Name = p.Name + ". Со спутниковой навигацией";
            Description = p.Description + ". " + this.Title + ". Уникальная система спутниковой навигации, при которой машина едет сама без учатия водителя";
        }
        public override double GetCost()
        {
            return AutoProperty.GetCost() + 2459.00;
        }
    }
    class Mercedes : AutoBase
    {
        public Mercedes(string name, string info, double costbase)
        {
            Name = name;
            Description = info;
            CostBase = costbase;
        }
        public override double GetCost()
        {
            return CostBase * 1.25;
        }
    }
    class Tuning : DecoratorOptions
    {
        public Tuning(AutoBase p, string t) : base(p, t)
        {
            AutoProperty = p;
            Name = p.Name + ". Переработанный дизайн корпуса";
            Description = p.Description + ". " + this.Title + ". Переработанный каркас автомобиля из сверхлегкого и прочнойого металла, и сложная система подсветки, придающие машине футуристический вид";
        }
        public override double GetCost()
        {
            return AutoProperty.GetCost() + 3500.0;
        }
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            Renault reno = new Renault("Рено", "Renault LOGAN Active", 499.0);
            Print(reno);
            AutoBase myreno = new MediaNAV(reno, "Навигация");
            Print(myreno);
            AutoBase newmyReno = new SystemSecurity(new MediaNAV(reno, "Навигация"), "Безопасность");
            Print(newmyReno);
            Mercedes merc = new Mercedes("Mercedes-Benz", "Mercedes-AMG C190 GT S", 15000.0);
            Print(merc);
            AutoBase merc1 = new SatelliteNavigation(merc, "Спутник");
            Print(merc1);
            AutoBase merc2 = new Tuning(new SatelliteNavigation(merc, "Спутник"), "Корпус");
            Print(merc2);
            Console.ReadKey();
        }
        private static void Print(AutoBase av)
        {
            Console.WriteLine(av.ToString());
        }
    }
    //Декоратор представляет структурный шаблон проектирования, который позволяет
    //динамически подключать к объекту дополнительную функциональность, т.е.расширяет
    //поведение объекта во время выполнения, добавляя или изменяя операции, которые будут
    //осуществляться при обработке запроса.

    //В упражнении реализована структура классов, позволяющяя динамически в процессе выполнения
    //программы определять новые возможности объектов комплектации автомобиля
}

