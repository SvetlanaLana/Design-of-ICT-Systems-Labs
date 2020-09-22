using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    abstract class Command
    {
        protected ArithmeticUnit unit;
        protected double operand;
        public abstract void Execute();
        public abstract void UnExecute();
    }
    class ArithmeticUnit
    {
        public double Register { get; private set; }
        public void Run(char operationCode, double operand)
        {
            switch (operationCode)
            {
                case '+':
                    Register += operand;
                    break;
                case '-':
                    Register -= operand;
                    break;
                case '*':
                    Register *= operand;
                    break;
                case '/':
                    Register /= operand;
                    break;
            }
        }
    }
    class ControlUnit
    {
        private List<Command> commands = new List<Command>();
        private int current = 0;
        public void StoreCommand(Command command)
        {
            commands.Add(command);
        }
        public void ExecuteCommand()
        {
            commands[current].Execute();
            current++;
        }
        public void Undo(int j)
        {
            for (int i = 1; i <= j; i++)
            {
                commands[current - 1].UnExecute();
            }
        }
        public void Redo(int j)
        {
            for (int i = 1; i <= j; i++)
            {
                commands[current - 1].Execute();
            }
            
        }
    }
    class Add : Command
    {
        public Add(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('+', operand);
        }
        public override void UnExecute()
        {
            unit.Run('-', operand);
        }
    }
    class Sub : Command
    {
        public Sub(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('-', operand);

        }
        public override void UnExecute()
        {
            unit.Run('+', operand);
        }
    }
    class Div : Command
    {
        public Div(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('/', operand);

        }
        public override void UnExecute()
        {
            unit.Run('*', operand);
        }
    }
    class Mul : Command
    {
        public Mul(ArithmeticUnit unit, double operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('*', operand);

        }
        public override void UnExecute()
        {
            unit.Run('/', operand);
        }
    }

    class Calculator
    {
        ArithmeticUnit arithmeticUnit;
        ControlUnit controlUnit;
        public Calculator()
        {
            arithmeticUnit = new ArithmeticUnit();
            controlUnit = new ControlUnit();
        }
        private double Run(Command command)
        {
            controlUnit.StoreCommand(command);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.Register;
        }
        public double Add(double operand)
        {
            return Run(new Add(arithmeticUnit, operand));
        }
        public double Sub(double operand)
        {
            return Run(new Sub(arithmeticUnit, operand));
        }
        public double Div(double operand)
        {
            return Run(new Div(arithmeticUnit, operand));
        }
        public double Mul(double operand)
        {
            return Run(new Mul(arithmeticUnit, operand));
        }
        public double Redo(int i)
        {
            controlUnit.Redo(i);
            return arithmeticUnit.Register;

        }
        public double Undo(int i)
        {
            controlUnit.Undo(i);
            return arithmeticUnit.Register;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            double result = 0;
            /*result = calculator.Add(5);
            Console.WriteLine(result);
            result = calculator.Add(4);
            Console.WriteLine(result);
            result = calculator.Add(3);
            Console.WriteLine(result);
            result = calculator.Redo(2);
            Console.WriteLine(result);
            result = calculator.Undo(1);
            Console.WriteLine(result);
            result = calculator.Mul(3);
            Console.WriteLine(result);
            result = calculator.Div(2);
            Console.WriteLine(result);
            result = calculator.Sub(3);
            Console.WriteLine(result);
            result = calculator.Add(5);
            Console.WriteLine(result);
            result = calculator.Undo(2);
            Console.WriteLine(result);*/
            result = calculator.Add(5);
            Console.WriteLine(result);
            result = calculator.Mul(6);
            Console.WriteLine(result);
            result = calculator.Sub(6);
            Console.WriteLine(result);
            result = calculator.Div(2);
            Console.WriteLine(result);
            result = calculator.Redo(2);
            Console.WriteLine(result);
            result = calculator.Undo(1);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
    //Шаблон команда –  шаблон проектирования, представляющий действие.
    //Объект команды будет заключать в себе само действие и его параметры.
    //Команда — это поведенческий паттерн проектирования, который превращает запросы в объекты,
    //позволяя передавать их как аргументы при вызове методов
    
    //В этом упражнении вы реализован программный калькулятор с простыми арифметическими
    //операциями и операциями отмены и повтора

    //Убирает прямую зависимость между объектами, вызывающими операции, и объектами, которые их непосредственно выполняют.
    //Позволяет реализовать простую отмену и повтор операций.
    //Позволяет реализовать отложенный запуск операций.
    //Позволяет собирать сложные команды из простых.
    //Реализует принцип открытости/закрытости.
}
