using System;

namespace Task
{
    abstract class StrategyRoute
    {
        public string Title { get; set; }
        public abstract void Route();
    }
    class Highway : StrategyRoute
    {
        public Highway()
        {
            Title = "Маршрут по автодорогам";
        }
        public override string ToString()
        {
            return Title;
        }
        public override void Route()
        {
            Console.WriteLine("Прокладывание маршрута по автодорогам \n *Сделайте вид, что тут показывается маршрут*");
        }
    }
    class WalkingRoute : StrategyRoute
    {
        public WalkingRoute()
        {
            Title = "Пеший маршрут";
        }
        public override string ToString()
        {
            return Title;
        }
        public override void Route()
        {
            Console.WriteLine("Прокладывание пешего маршрута \n *Сделайте вид, что тут показывается маршрут*");
        }
    }
    class PublicTransport : StrategyRoute
    {
        public PublicTransport()
        {
            Title = "Маршрут на общественном транспорте";
        }
        public override string ToString()
        {
            return Title;
        }
        public override void Route()
        {
            Console.WriteLine("Прокладывание маршрута на общественном транспорте \n *Сделайте вид, что тут показывается маршрут*");
        }
    }
    class Landmark : StrategyRoute
    {
        public Landmark()
        {
            Title = "Маршрут по достопримечательностям";
        }
        public override string ToString()
        {
            return Title;
        }
        public override void Route()
        {
            Console.WriteLine("Прокладывание маршрута по достопримечательностям \n *Сделайте вид, что тут показывается маршрут*");
        }
    }
    class Сycle : StrategyRoute
    {
        public Сycle()
        {
            Title = "Маршрут по велодорожкам";
        }
        public override string ToString()
        {
            return Title;
        }
        public override void Route()
        {
            Console.WriteLine("Прокладывание маршрута по велодорожкам \n *Сделайте вид, что тут показывается маршрут*");
        }
    }
    class Map : StrategyRoute
    {
        public Map()
        {
            Title = "Карта";
        }
        public override string ToString()
        {
            return Title;
        }
        public override void Route()
        {
            Console.WriteLine("Открытие карты \n *Сделайте вид, что вы видите карту*");
        }
    }
    class Way
    {
        StrategyRoute strategy;
        public Way(StrategyRoute strategy)
        {
            this.strategy = strategy;
        }
        public void Route()
        {
            strategy.Route();
        }
        public void Print()
        {
            Console.WriteLine(strategy.ToString());
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StrategyRoute map = new Map();
            Way way = new Way(map);
            way.Route();
            way.Print();
            StrategyRoute route = new Highway();
            Way way1 = new Way(route);
            way1.Route();
            way1.Print();
            route = new WalkingRoute();
            Way way2 = new Way(route);
            way2.Route();
            way2.Print();
            route = new PublicTransport();
            Way way3 = new Way(route);
            way3.Route();
            way3.Print();
            route = new Landmark();
            Way way4 = new Way(route);
            way4.Route();
            way4.Print();
            route = new Сycle();
            Way way5 = new Way(route);
            way5.Route();
            way5.Print();

            Console.ReadKey();
        }
    }
    //Стратегия — это поведенческий паттерн проектирования, который определяет семейство
    //схожих алгоритмов и помещает каждый из них в собственный класс.После чего, алгоритмы
    //можно взаимозаменять прямо во время исполнения программы.
    //В контрольном задании реализован прототип сложного навигатор, меняющий
    //способо построения маршрута в зависимости от способа передвижения
}
