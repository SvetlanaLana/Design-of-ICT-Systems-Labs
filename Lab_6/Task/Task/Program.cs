using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Ingredients
    {
        public event EventHandler AddingIngredients;
        private string adding;
        public string Adding
        {
            get { return adding; }
            set
            {
                adding = value;
                if (AddingIngredients != null)
                    AddingIngredients(this, new EventArgs());
            }
        }
        public void Ingredient()
        {
            Adding = "Добавление ингредиентов";
        }
        public void AddSugar()
        {
            Adding = "Дабавление сахара";
        }
        public void AddCream()
        {
            Adding = "Дабавление сливок";
        }
        public void AddMilk()
        {
            Adding = "Дабавление сухого молока";
        }
        public void AddWater()
        {
            Adding = "Пропускание кипятка";
        }
        public override string ToString()
        {
            string s = String.Format("Процесс: {0}", Adding);
            return s;
        }
    }
    class Coffee
    {
        public event EventHandler coffeeevent;
        private string _coffee;
        public string Drinding
        {
            get { return _coffee; }
            set
            {
                _coffee = value;
                if (coffeeevent != null)
                    coffeeevent(this, new EventArgs());
            }
        }
        public void StartDrinding()
        {
            Drinding = "Начало перемалывания кофе";
        }
        public void StopDrinding()
        {
            Drinding = "Конец перемалывания кофе";
        }
        public override string ToString()
        {
            string s = String.Format("Процесс: {0}", Drinding);
            return s;
        }
    }
    class Time
    {
        public event EventHandler resttime;
        private int _time;
        public int Timing
        {
            get { return _time; }
            set
            {
                _time = value;
                if (resttime != null)
                    resttime(this, new EventArgs());
            }
        }
        public override string ToString()
        {
            string s = String.Format("Остлось ожидать {0} сек.", Timing);
            return s;
        }
    }
    class Notification
    {
        public event EventHandler notificationevent;
        private string mess;
        public string MessageFin
        {
            get { return mess; }
            set
            {
                mess = value;
                if (notificationevent != null)
                    notificationevent(this, new EventArgs());
            }
        }
        public void StartNotification()
        {
            MessageFin = "Операция началась";
        }
        public void RedyCoffee()
        {
            MessageFin = "Кофе готово";
        }
        public void StopNotification()
        {
            MessageFin = "Операция завершена";
        }
        public override string ToString()
        {
            string s = String.Format("Информация: {0}", MessageFin);
            return s;
        }
    }
    class CoffeeMachine
    {
        private Ingredients _ingredients;
        private Coffee _coffee;
        private Notification _notification;
        private Time _time;
        public CoffeeMachine(Ingredients ingredients, Coffee coffee, Notification notification, Time time)
        {
            _ingredients = ingredients;
            _coffee = coffee;
            _notification = notification;
            _time = time;
        }
        public void Making()
        {
            _notification.StartNotification();
            _time.Timing = 45;
            _ingredients.Ingredient();
            _ingredients.AddSugar();
            _ingredients.AddCream();
            _ingredients.AddMilk();
            _time.Timing = 30;
            _coffee.StartDrinding();
            _coffee.StopDrinding();
            _time.Timing = 15;
            _ingredients.AddWater();
            _time.Timing = 0;
            _notification.RedyCoffee();
            _notification.StopNotification();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var ingredient = new Ingredients();
            var coffee = new Coffee();
            var notification = new Notification();
            var time = new Time();
            var coffeemachine = new CoffeeMachine(ingredient, coffee, notification, time);
            coffee.coffeeevent += coffee_coffeeevent;
            ingredient.AddingIngredients += ingredient_ingredientevent;
            notification.notificationevent += notification_notificationevent;
            time.resttime += time_timeevent;

            Console.WriteLine("Приготовление кофе в кофемашине");
            coffeemachine.Making();
            Console.ReadKey();
        }
        static void notification_notificationevent(object sender, EventArgs e)
        {
            Notification n = (Notification)sender;
            Console.WriteLine(n.ToString());
        }
        static void  ingredient_ingredientevent(object sender, EventArgs e)
        {
            Ingredients d = (Ingredients)sender;
            Console.WriteLine(d.ToString());
        }
        private static void coffee_coffeeevent(object sender, EventArgs e)
        {
            Coffee p = (Coffee)sender;
            Console.WriteLine(p.ToString());
        }
        private static void time_timeevent(object sender, EventArgs e)
        {
            Time t = (Time)sender;
            Console.WriteLine(t.ToString());
        }
    }
    //Таким образом, реализован фасадный объект, обеспечивающий общий интерфейс работы с
    //системой и выполняющий обязанность по взаимодействию с её компонентами.
    //Добавлен класс-фасад метод, реализующий приготовление кофе в кофемашине

    //Фасад(Facade) представляет структурный шаблон проектирования, который позволяет
    //скрыть сложность системы с помощью предоставления упрощенного интерфейса для
    //взаимодействия с ней путем сведения всех возможных внешних вызовов к одному объекту,
    //делегирующему их соответствующим объектам системы.
}
