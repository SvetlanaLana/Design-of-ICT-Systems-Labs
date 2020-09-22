using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    abstract class CarFactory
    {
        public abstract AbstractCar CreateCar();
        public abstract AbstractEngine CreateEngine();
        public abstract AbstractBodywork CreateBodywork();
    }
    abstract class AbstractCar
    {
        public string Name { get; set; }
        public abstract int MaxSpeed(AbstractEngine engine);
        public abstract string Type(AbstractBodywork body);
    }
    abstract class AbstractEngine
    {
        public int max_speed { get; set; }
    }
    abstract class AbstractBodywork
    {
        public string Type { get; set; }
    }
    class FordFactory : CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new FordCar("Форд");
        }
        public override AbstractEngine CreateEngine()
        {
            return new FordEngine();
        }
        public override AbstractBodywork CreateBodywork()
        {
            return new FordBodywork();
        }
    }
    class FordCar : AbstractCar
    {
        public FordCar(string name)
        {
            Name = name;
        }
        public override int MaxSpeed(AbstractEngine engine)
        {
            int ms = engine.max_speed;
            return ms;
        }
        public override string ToString()
        {
            return "Автомобиль " + Name;
        }
        public override string Type(AbstractBodywork body)
        {
            string tp = body.Type;
            return tp;
        }
    }
    class FordEngine : AbstractEngine
    {
        public FordEngine()
        {
            max_speed = 220;
        }
    }
    class FordBodywork : AbstractBodywork
    {
        public FordBodywork()
        {
            Type = "Хетчбэк";
        }
    }
    class Client
    {
        private AbstractCar abstractCar;
        private AbstractEngine abstractEngine;
        private AbstractBodywork abstractBodywork;
        public Client(CarFactory car_factory)
        {
            abstractCar = car_factory.CreateCar();
            abstractEngine = car_factory.CreateEngine();
            abstractBodywork = car_factory.CreateBodywork();
        }
        public int RunMaxSpeed()
        {
            return abstractCar.MaxSpeed(abstractEngine);
        }
        public override string ToString()
        {
            return abstractCar.ToString();
        }
        public string TypeBodywork()
        {
            return abstractCar.Type(abstractBodywork);
        }
    }
    class AudiFactory : CarFactory
    {
        AudiFactory() { }
        static AudiFactory myAudi = null;
        public static AudiFactory MyAudi
        {
            get
            {
                if (myAudi == null)
                {
                    myAudi = new AudiFactory();
                }
                return myAudi;
            }
        }
        public override AbstractCar CreateCar()
        {
            return new AudiCar("Ауди");
        }
        public override AbstractEngine CreateEngine()
        {
            return new AudiEngine();
        }
        public override AbstractBodywork CreateBodywork()
        {
            return new AudiBodywork();
        }
    }
    class AudiCar : AbstractCar
    {
        public AudiCar(string name)
        {
            Name = name;
        }
        public override int MaxSpeed(AbstractEngine engine)
        {
            int ms = engine.max_speed;
            return ms;
        }
        public override string ToString()
        {
            return "Автомобиль " + Name;
        }
        public override string Type(AbstractBodywork body)
        {
            string tp = body.Type;
            return tp;
        }
    }
    class AudiEngine : AbstractEngine
    {
        public AudiEngine()
        {
            max_speed = 270;
        }
    }
    class AudiBodywork : AbstractBodywork
    {
        public AudiBodywork()
        {
            Type = "Cедан";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CarFactory ford_car = new FordFactory();
            Client c1 = new Client(ford_car);
            Console.WriteLine("Максимальная скорость {0} в типе кузова {2} составляет {1} км/час", c1.ToString(), c1.RunMaxSpeed(), c1.TypeBodywork());

            CarFactory audi_car = AudiFactory.MyAudi;
            Client c2 = new Client(audi_car);
            Console.WriteLine("Максимальная скорость {0} в типе кузова {2} составляет {1} км/час", c2.ToString(), c2.RunMaxSpeed(), c2.TypeBodywork());
            Console.ReadKey();
        }
    }
    //Одиночка(Singleton, Синглтон) - порождающий паттерн, который гарантирует, что для
    //определенного класса будет создан только один объект, а также предоставит к этому объекту
    //точку доступа.Сам класс контролирует то, что у него есть только один экземпляр, может
    //запретить создание дополнительных экземпляров, перехватывая запросы на создание новых
    //объектов и он же способен предоставить доступ к своему экземпляру.
}
